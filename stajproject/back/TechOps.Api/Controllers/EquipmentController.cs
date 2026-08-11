using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel")]
[Route("api/equipment")]
public sealed class EquipmentController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEquipment(
        [FromQuery] string? search,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] string? status,
        [FromQuery] bool? isActive,
        CancellationToken cancellationToken)
    {
        var query = dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lookup = search.Trim().ToLowerInvariant();
            query = query.Where(x =>
                x.Code.ToLower().Contains(lookup) ||
                x.Name.ToLower().Contains(lookup) ||
                (x.Brand != null && x.Brand.ToLower().Contains(lookup)) ||
                (x.Model != null && x.Model.ToLower().Contains(lookup)) ||
                (x.SerialNo != null && x.SerialNo.ToLower().Contains(lookup)));
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.TechnicalSystemId == technicalSystemId.Value);
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (!TryParseStatus(status, out var parsedStatus))
            {
                return BadRequest(new { message = "Geçersiz ekipman durumu." });
            }

            query = query.Where(x => x.Status == parsedStatus);
        }

        if (isActive.HasValue)
        {
            query = query.Where(x => x.IsActive == isActive.Value);
        }

        var equipment = await query
            .OrderBy(x => x.Code)
            .Select(x => MapListItem(x))
            .ToListAsync(cancellationToken);

        return Ok(equipment);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEquipmentDetail(Guid id, CancellationToken cancellationToken)
    {
        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return equipment is null ? NotFound(new { message = "Ekipman bulunamadı." }) : Ok(MapDetail(equipment));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEquipment(CreateEquipmentRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateEquipmentRequest(
            request.LocationId,
            request.TechnicalSystemId,
            request.Code,
            request.Name,
            request.Status,
            null,
            cancellationToken);

        if (validationResult is not null)
        {
            return validationResult;
        }

        TryParseStatus(request.Status, out var status);

        var equipment = new Equipment
        {
            Id = Guid.NewGuid(),
            LocationId = request.LocationId,
            TechnicalSystemId = request.TechnicalSystemId,
            Code = request.Code.Trim(),
            Name = request.Name.Trim(),
            Brand = NormalizeOptional(request.Brand),
            Model = NormalizeOptional(request.Model),
            SerialNo = NormalizeOptional(request.SerialNo),
            Status = status,
            CommissionedAt = request.CommissionedAt,
            Description = NormalizeOptional(request.Description),
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Equipment.Add(equipment);
        await dbContext.SaveChangesAsync(cancellationToken);

        var created = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleAsync(x => x.Id == equipment.Id, cancellationToken);

        return CreatedAtAction(nameof(GetEquipmentDetail), new { id = created.Id }, MapDetail(created));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEquipment(Guid id, UpdateEquipmentRequest request, CancellationToken cancellationToken)
    {
        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (equipment is null)
        {
            return NotFound(new { message = "Ekipman bulunamadı." });
        }

        var validationResult = await ValidateEquipmentRequest(
            request.LocationId,
            request.TechnicalSystemId,
            request.Code,
            request.Name,
            request.Status,
            id,
            cancellationToken);

        if (validationResult is not null)
        {
            return validationResult;
        }

        TryParseStatus(request.Status, out var status);

        equipment.LocationId = request.LocationId;
        equipment.TechnicalSystemId = request.TechnicalSystemId;
        equipment.Code = request.Code.Trim();
        equipment.Name = request.Name.Trim();
        equipment.Brand = NormalizeOptional(request.Brand);
        equipment.Model = NormalizeOptional(request.Model);
        equipment.SerialNo = NormalizeOptional(request.SerialNo);
        equipment.Status = status;
        equipment.CommissionedAt = request.CommissionedAt;
        equipment.Description = NormalizeOptional(request.Description);
        equipment.IsActive = request.IsActive;
        equipment.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleAsync(x => x.Id == id, cancellationToken);

        return Ok(MapDetail(updated));
    }

    [Authorize(Roles = "Admin,Yönetici")]
    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateEquipmentStatus(Guid id, UpdateEquipmentStatusRequest request, CancellationToken cancellationToken)
    {
        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (equipment is null)
        {
            return NotFound(new { message = "Ekipman bulunamadı." });
        }

        if (!TryParseStatus(request.Status, out var status))
        {
            return BadRequest(new { message = "Geçersiz ekipman durumu." });
        }

        equipment.Status = status;
        equipment.IsActive = request.IsActive;
        equipment.UpdatedAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(MapDetail(equipment));
    }

    private async Task<IActionResult?> ValidateEquipmentRequest(
        Guid locationId,
        Guid technicalSystemId,
        string code,
        string name,
        string status,
        Guid? currentEquipmentId,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new { message = "Ekipman kodu ve adı zorunludur." });
        }

        if (!TryParseStatus(status, out _))
        {
            return BadRequest(new { message = "Geçersiz ekipman durumu." });
        }

        var locationExists = await dbContext.Locations.AnyAsync(x => x.Id == locationId && x.IsActive, cancellationToken);
        if (!locationExists)
        {
            return BadRequest(new { message = "Geçerli ve aktif bir lokasyon seçilmelidir." });
        }

        var technicalSystemExists = await dbContext.TechnicalSystems.AnyAsync(x => x.Id == technicalSystemId && x.IsActive, cancellationToken);
        if (!technicalSystemExists)
        {
            return BadRequest(new { message = "Geçerli ve aktif bir teknik sistem seçilmelidir." });
        }

        var codeLookup = code.Trim().ToLowerInvariant();
        var duplicateCodeExists = await dbContext.Equipment.AnyAsync(x =>
            (!currentEquipmentId.HasValue || x.Id != currentEquipmentId.Value) &&
            x.Code.ToLower() == codeLookup,
            cancellationToken);

        return duplicateCodeExists ? Conflict(new { message = "Ekipman kodu zaten kullanılıyor." }) : null;
    }

    private static bool TryParseStatus(string status, out EquipmentStatus parsedStatus)
    {
        return Enum.TryParse(status.Trim(), ignoreCase: true, out parsedStatus) && Enum.IsDefined(parsedStatus);
    }

    private static EquipmentListItemDto MapListItem(Equipment equipment) => new()
    {
        Id = equipment.Id,
        Code = equipment.Code,
        Name = equipment.Name,
        Brand = equipment.Brand,
        Model = equipment.Model,
        SerialNo = equipment.SerialNo,
        LocationId = equipment.LocationId,
        LocationName = equipment.Location.Name,
        TechnicalSystemId = equipment.TechnicalSystemId,
        TechnicalSystemName = equipment.TechnicalSystem.Name,
        Status = equipment.Status.ToString(),
        IsActive = equipment.IsActive
    };

    private static EquipmentDetailDto MapDetail(Equipment equipment) => new()
    {
        Id = equipment.Id,
        LocationId = equipment.LocationId,
        TechnicalSystemId = equipment.TechnicalSystemId,
        Code = equipment.Code,
        Name = equipment.Name,
        Brand = equipment.Brand,
        Model = equipment.Model,
        SerialNo = equipment.SerialNo,
        Status = equipment.Status.ToString(),
        CommissionedAt = equipment.CommissionedAt,
        Description = equipment.Description,
        IsActive = equipment.IsActive,
        Location = new LocationDto
        {
            Id = equipment.Location.Id,
            ParentLocationId = equipment.Location.ParentLocationId,
            Code = equipment.Location.Code,
            Name = equipment.Location.Name,
            Type = equipment.Location.Type,
            Description = equipment.Location.Description,
            IsActive = equipment.Location.IsActive
        },
        TechnicalSystem = new TechnicalSystemDto
        {
            Id = equipment.TechnicalSystem.Id,
            Code = equipment.TechnicalSystem.Code,
            Name = equipment.TechnicalSystem.Name,
            Description = equipment.TechnicalSystem.Description,
            IsActive = equipment.TechnicalSystem.IsActive
        }
    };

    private static string? NormalizeOptional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
