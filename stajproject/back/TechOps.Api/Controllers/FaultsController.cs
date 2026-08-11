using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel,Operatör")]
[Route("api/faults")]
public sealed class FaultsController(AppDbContext dbContext) : ControllerBase
{
    private const string AdminManagerRoles = "Admin,Yönetici";
    private const string TechnicalOperationRoles = "Admin,Yönetici,Teknik Personel";
    private const string TechnicianRole = "Teknik Personel";

    [HttpGet]
    public async Task<IActionResult> GetFaults(
        [FromQuery] string? search,
        [FromQuery] string? status,
        [FromQuery] string? priority,
        [FromQuery] string? source,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] Guid? equipmentId,
        [FromQuery] Guid? assignedToUserId,
        [FromQuery] DateTime? createdFrom,
        [FromQuery] DateTime? createdTo,
        CancellationToken cancellationToken)
    {
        var query = dbContext.Faults
            .Include(x => x.Equipment)
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .Include(x => x.CreatedByUser)
            .Include(x => x.AssignedToUser)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lookup = search.Trim().ToLowerInvariant();
            query = query.Where(x =>
                x.FaultNo.ToLower().Contains(lookup) ||
                x.Description.ToLower().Contains(lookup) ||
                x.Equipment.Code.ToLower().Contains(lookup) ||
                x.Equipment.Name.ToLower().Contains(lookup));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (!TryParseStatus(status, out var parsedStatus))
            {
                return BadRequest(new { message = "Geçersiz arıza durumu." });
            }

            query = query.Where(x => x.Status == parsedStatus);
        }

        if (!string.IsNullOrWhiteSpace(priority))
        {
            if (!TryParsePriority(priority, out var parsedPriority))
            {
                return BadRequest(new { message = "Geçersiz arıza önceliği." });
            }

            query = query.Where(x => x.Priority == parsedPriority);
        }

        if (!string.IsNullOrWhiteSpace(source))
        {
            if (!TryParseSource(source, out var parsedSource))
            {
                return BadRequest(new { message = "Geçersiz arıza kaynağı." });
            }

            query = query.Where(x => x.Source == parsedSource);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.TechnicalSystemId == technicalSystemId.Value);
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (assignedToUserId.HasValue)
        {
            query = query.Where(x => x.AssignedToUserId == assignedToUserId.Value);
        }

        if (createdFrom.HasValue)
        {
            var from = NormalizeQueryDateTime(createdFrom.Value);
            query = query.Where(x => x.CreatedAt >= from);
        }

        if (createdTo.HasValue)
        {
            var to = NormalizeQueryDateTime(createdTo.Value);
            query = query.Where(x => x.CreatedAt <= to);
        }

        var faults = await query
            .OrderByDescending(x => x.CreatedAt)
            .ThenBy(x => x.FaultNo)
            .Select(x => MapListItem(x))
            .ToListAsync(cancellationToken);

        return Ok(faults);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFault(Guid id, CancellationToken cancellationToken)
    {
        var fault = await FaultDetailQuery()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return fault is null ? NotFound(new { message = "Arıza bulunamadı." }) : Ok(MapDetail(fault));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFault(CreateFaultRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        if (request.EquipmentId == Guid.Empty)
        {
            return BadRequest(new { message = "Ekipman seçimi zorunludur." });
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            return BadRequest(new { message = "Arıza açıklaması zorunludur." });
        }

        if (!TryParseSource(request.Source, out var source))
        {
            return BadRequest(new { message = "Geçersiz arıza kaynağı." });
        }

        if (!TryParsePriority(request.Priority, out var priority))
        {
            return BadRequest(new { message = "Geçersiz arıza önceliği." });
        }

        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == request.EquipmentId, cancellationToken);

        if (equipment is null)
        {
            return BadRequest(new { message = "Seçilen ekipman bulunamadı." });
        }

        if (!equipment.IsActive || equipment.Status != EquipmentStatus.Active || !equipment.Location.IsActive || !equipment.TechnicalSystem.IsActive)
        {
            return BadRequest(new { message = "Arıza yalnızca aktif ekipman için oluşturulabilir." });
        }

        var now = DateTime.UtcNow;
        var fault = new Fault
        {
            Id = Guid.NewGuid(),
            FaultNo = await GenerateFaultNo(now.Year, cancellationToken),
            EquipmentId = equipment.Id,
            LocationId = equipment.LocationId,
            TechnicalSystemId = equipment.TechnicalSystemId,
            CreatedByUserId = currentUserId,
            Source = source,
            Priority = priority,
            Status = FaultStatus.New,
            Description = request.Description.Trim(),
            CreatedAt = now
        };

        dbContext.Faults.Add(fault);
        dbContext.FaultActions.Add(CreateAction(
            fault.Id,
            currentUserId,
            "Created",
            null,
            FaultStatus.New,
            "Arıza kaydı oluşturuldu.",
            now));

        await dbContext.SaveChangesAsync(cancellationToken);

        var created = await FaultDetailQuery()
            .SingleAsync(x => x.Id == fault.Id, cancellationToken);

        return CreatedAtAction(nameof(GetFault), new { id = created.Id }, MapDetail(created));
    }

    [Authorize(Roles = AdminManagerRoles)]
    [HttpPost("{id:guid}/assign")]
    public async Task<IActionResult> AssignFault(Guid id, AssignFaultRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var fault = await dbContext.Faults.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (fault is null)
        {
            return NotFound(new { message = "Arıza bulunamadı." });
        }

        if (fault.Status is FaultStatus.Resolved or FaultStatus.Closed)
        {
            return BadRequest(new { message = "Çözülmüş veya kapatılmış arızaya personel atanamaz." });
        }

        if (request.AssignedToUserId == Guid.Empty)
        {
            return BadRequest(new { message = "Atanacak teknik personel seçilmelidir." });
        }

        var assignee = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == request.AssignedToUserId && x.IsActive, cancellationToken);

        if (assignee is null || assignee.Role.Name != TechnicianRole)
        {
            return BadRequest(new { message = "Arıza yalnızca aktif teknik personele atanabilir." });
        }

        var now = DateTime.UtcNow;
        var oldStatus = fault.Status;
        fault.AssignedToUserId = assignee.Id;
        fault.AssignedAt = now;
        fault.Status = fault.Status == FaultStatus.New ? FaultStatus.Assigned : fault.Status;
        fault.WaitingReason = fault.Status == FaultStatus.Waiting ? fault.WaitingReason : null;
        fault.UpdatedAt = now;

        dbContext.FaultActions.Add(CreateAction(
            fault.Id,
            currentUserId,
            "Assigned",
            oldStatus,
            fault.Status,
            NormalizeOptional(request.Note) ?? $"{assignee.FullName} kullanıcısına atandı.",
            now));

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await FaultDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [Authorize(Roles = TechnicalOperationRoles)]
    [HttpPost("{id:guid}/actions")]
    public async Task<IActionResult> AddFaultAction(Guid id, AddFaultActionRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var fault = await dbContext.Faults.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (fault is null)
        {
            return NotFound(new { message = "Arıza bulunamadı." });
        }

        if (fault.Status == FaultStatus.Closed)
        {
            return BadRequest(new { message = "Kapatılmış arıza üzerinde işlem yapılamaz." });
        }

        if (string.IsNullOrWhiteSpace(request.Note))
        {
            return BadRequest(new { message = "İşlem notu zorunludur." });
        }

        var now = DateTime.UtcNow;
        fault.UpdatedAt = now;

        dbContext.FaultActions.Add(CreateAction(
            fault.Id,
            currentUserId,
            "NoteAdded",
            fault.Status,
            fault.Status,
            request.Note.Trim(),
            now));

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await FaultDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [Authorize(Roles = TechnicalOperationRoles)]
    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateFaultStatus(Guid id, UpdateFaultStatusRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        if (!TryParseStatus(request.Status, out var targetStatus))
        {
            return BadRequest(new { message = "Geçersiz arıza durumu." });
        }

        if (targetStatus == FaultStatus.Assigned)
        {
            return BadRequest(new { message = "Atama işlemi için assign endpointi kullanılmalıdır." });
        }

        if (targetStatus == FaultStatus.Resolved)
        {
            return BadRequest(new { message = "Çözüm işlemi için resolve endpointi kullanılmalıdır." });
        }

        if (targetStatus == FaultStatus.Closed)
        {
            return BadRequest(new { message = "Kapatma işlemi için close endpointi kullanılmalıdır." });
        }

        var fault = await dbContext.Faults.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (fault is null)
        {
            return NotFound(new { message = "Arıza bulunamadı." });
        }

        if (fault.Status == FaultStatus.Closed)
        {
            return BadRequest(new { message = "Kapatılmış arıza üzerinde işlem yapılamaz." });
        }

        if (fault.Status == targetStatus)
        {
            return BadRequest(new { message = "Yeni durum mevcut durumdan farklı olmalıdır." });
        }

        if (!IsAllowedTransition(fault.Status, targetStatus))
        {
            return BadRequest(new { message = $"{fault.Status} durumundan {targetStatus} durumuna geçiş yapılamaz." });
        }

        if (targetStatus == FaultStatus.Waiting && string.IsNullOrWhiteSpace(request.WaitingReason))
        {
            return BadRequest(new { message = "Bekleme durumuna geçerken bekleme nedeni zorunludur." });
        }

        var now = DateTime.UtcNow;
        var oldStatus = fault.Status;
        fault.Status = targetStatus;
        fault.WaitingReason = targetStatus == FaultStatus.Waiting ? request.WaitingReason!.Trim() : null;
        fault.UpdatedAt = now;

        if (oldStatus == FaultStatus.Resolved)
        {
            fault.ResolvedByUserId = null;
            fault.ResolvedAt = null;
            fault.ResolutionDescription = null;
        }

        dbContext.FaultActions.Add(CreateAction(
            fault.Id,
            currentUserId,
            "StatusChanged",
            oldStatus,
            targetStatus,
            NormalizeOptional(request.Note) ?? $"Arıza durumu {oldStatus} -> {targetStatus} olarak güncellendi.",
            now));

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await FaultDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [Authorize(Roles = TechnicalOperationRoles)]
    [HttpPost("{id:guid}/resolve")]
    public async Task<IActionResult> ResolveFault(Guid id, ResolveFaultRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        if (string.IsNullOrWhiteSpace(request.ResolutionDescription))
        {
            return BadRequest(new { message = "Çözüm açıklaması zorunludur." });
        }

        var fault = await dbContext.Faults.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (fault is null)
        {
            return NotFound(new { message = "Arıza bulunamadı." });
        }

        if (fault.Status == FaultStatus.Closed)
        {
            return BadRequest(new { message = "Kapatılmış arıza üzerinde işlem yapılamaz." });
        }

        if (fault.Status == FaultStatus.Resolved)
        {
            return BadRequest(new { message = "Arıza zaten çözüldü durumunda." });
        }

        if (!IsAllowedTransition(fault.Status, FaultStatus.Resolved))
        {
            return BadRequest(new { message = $"{fault.Status} durumundan Resolved durumuna geçiş yapılamaz." });
        }

        var now = DateTime.UtcNow;
        var oldStatus = fault.Status;
        fault.Status = FaultStatus.Resolved;
        fault.ResolvedByUserId = currentUserId;
        fault.ResolvedAt = now;
        fault.ResolutionDescription = request.ResolutionDescription.Trim();
        fault.WaitingReason = null;
        fault.UpdatedAt = now;

        dbContext.FaultActions.Add(CreateAction(
            fault.Id,
            currentUserId,
            "Resolved",
            oldStatus,
            FaultStatus.Resolved,
            fault.ResolutionDescription,
            now));

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await FaultDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [Authorize(Roles = AdminManagerRoles)]
    [HttpPost("{id:guid}/close")]
    public async Task<IActionResult> CloseFault(Guid id, CloseFaultRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var fault = await dbContext.Faults.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (fault is null)
        {
            return NotFound(new { message = "Arıza bulunamadı." });
        }

        if (fault.Status == FaultStatus.Closed)
        {
            return BadRequest(new { message = "Arıza zaten kapatılmış durumda." });
        }

        if (fault.Status != FaultStatus.Resolved)
        {
            return BadRequest(new { message = "Arıza kapatılmadan önce çözüldü durumuna alınmalıdır." });
        }

        var now = DateTime.UtcNow;
        var oldStatus = fault.Status;
        fault.Status = FaultStatus.Closed;
        fault.ClosedByUserId = currentUserId;
        fault.ClosedAt = now;
        fault.UpdatedAt = now;

        dbContext.FaultActions.Add(CreateAction(
            fault.Id,
            currentUserId,
            "Closed",
            oldStatus,
            FaultStatus.Closed,
            NormalizeOptional(request.Note) ?? "Arıza kapatıldı.",
            now));

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await FaultDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    private IQueryable<Fault> FaultDetailQuery() => dbContext.Faults
        .Include(x => x.Equipment)
        .Include(x => x.Location)
        .Include(x => x.TechnicalSystem)
        .Include(x => x.CreatedByUser)
        .Include(x => x.AssignedToUser)
        .Include(x => x.ResolvedByUser)
        .Include(x => x.ClosedByUser)
        .Include(x => x.Actions)
        .ThenInclude(x => x.User);

    private async Task<string> GenerateFaultNo(int year, CancellationToken cancellationToken)
    {
        var prefix = $"ARZ-{year}-";
        var sequence = await dbContext.Faults.CountAsync(x => x.FaultNo.StartsWith(prefix), cancellationToken) + 1;
        string faultNo;

        do
        {
            faultNo = $"{prefix}{sequence:0000}";
            sequence++;
        }
        while (await dbContext.Faults.AnyAsync(x => x.FaultNo == faultNo, cancellationToken));

        return faultNo;
    }

    private bool TryGetCurrentUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(userIdClaim, out userId);
    }

    private static FaultAction CreateAction(
        Guid faultId,
        Guid userId,
        string actionType,
        FaultStatus? oldStatus,
        FaultStatus? newStatus,
        string? note,
        DateTime createdAt) => new()
        {
            Id = Guid.NewGuid(),
            FaultId = faultId,
            UserId = userId,
            ActionType = actionType,
            OldStatus = oldStatus,
            NewStatus = newStatus,
            Note = note,
            CreatedAt = createdAt
        };

    private static bool IsAllowedTransition(FaultStatus currentStatus, FaultStatus targetStatus) => currentStatus switch
    {
        FaultStatus.New => targetStatus is FaultStatus.Assigned or FaultStatus.InReview or FaultStatus.Waiting,
        FaultStatus.Assigned => targetStatus is FaultStatus.InReview or FaultStatus.InProgress or FaultStatus.Waiting,
        FaultStatus.InReview => targetStatus is FaultStatus.InProgress or FaultStatus.Waiting or FaultStatus.Resolved,
        FaultStatus.InProgress => targetStatus is FaultStatus.Waiting or FaultStatus.Resolved,
        FaultStatus.Waiting => targetStatus is FaultStatus.InReview or FaultStatus.InProgress or FaultStatus.Resolved,
        FaultStatus.Resolved => targetStatus is FaultStatus.Closed or FaultStatus.InProgress,
        FaultStatus.Closed => false,
        _ => false
    };

    private static bool TryParseStatus(string? status, out FaultStatus parsedStatus)
    {
        return Enum.TryParse(status?.Trim(), ignoreCase: true, out parsedStatus) && Enum.IsDefined(parsedStatus);
    }

    private static bool TryParsePriority(string? priority, out FaultPriority parsedPriority)
    {
        return Enum.TryParse(priority?.Trim(), ignoreCase: true, out parsedPriority) && Enum.IsDefined(parsedPriority);
    }

    private static bool TryParseSource(string? source, out FaultSource parsedSource)
    {
        return Enum.TryParse(source?.Trim(), ignoreCase: true, out parsedSource) && Enum.IsDefined(parsedSource);
    }

    private static DateTime NormalizeQueryDateTime(DateTime value) => value.Kind switch
    {
        DateTimeKind.Local => value.ToUniversalTime(),
        DateTimeKind.Utc => value,
        _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
    };

    private static FaultListItemDto MapListItem(Fault fault) => new()
    {
        Id = fault.Id,
        FaultNo = fault.FaultNo,
        EquipmentId = fault.EquipmentId,
        EquipmentCode = fault.Equipment.Code,
        EquipmentName = fault.Equipment.Name,
        LocationId = fault.LocationId,
        LocationName = fault.Location.Name,
        TechnicalSystemId = fault.TechnicalSystemId,
        TechnicalSystemName = fault.TechnicalSystem.Name,
        Source = fault.Source.ToString(),
        Priority = fault.Priority.ToString(),
        Status = fault.Status.ToString(),
        CreatedByUserId = fault.CreatedByUserId,
        CreatedByUserName = fault.CreatedByUser.FullName,
        AssignedToUserId = fault.AssignedToUserId,
        AssignedToUserName = fault.AssignedToUser?.FullName,
        CreatedAt = fault.CreatedAt,
        UpdatedAt = fault.UpdatedAt
    };

    private static FaultDetailDto MapDetail(Fault fault) => new()
    {
        Id = fault.Id,
        FaultNo = fault.FaultNo,
        EquipmentId = fault.EquipmentId,
        LocationId = fault.LocationId,
        TechnicalSystemId = fault.TechnicalSystemId,
        EquipmentCode = fault.Equipment.Code,
        EquipmentName = fault.Equipment.Name,
        LocationName = fault.Location.Name,
        TechnicalSystemName = fault.TechnicalSystem.Name,
        Source = fault.Source.ToString(),
        Priority = fault.Priority.ToString(),
        Status = fault.Status.ToString(),
        Description = fault.Description,
        ResolutionDescription = fault.ResolutionDescription,
        WaitingReason = fault.WaitingReason,
        CreatedByUserId = fault.CreatedByUserId,
        CreatedByUserName = fault.CreatedByUser.FullName,
        AssignedToUserId = fault.AssignedToUserId,
        AssignedToUserName = fault.AssignedToUser?.FullName,
        ResolvedByUserId = fault.ResolvedByUserId,
        ResolvedByUserName = fault.ResolvedByUser?.FullName,
        ClosedByUserId = fault.ClosedByUserId,
        ClosedByUserName = fault.ClosedByUser?.FullName,
        CreatedAt = fault.CreatedAt,
        UpdatedAt = fault.UpdatedAt,
        AssignedAt = fault.AssignedAt,
        ResolvedAt = fault.ResolvedAt,
        ClosedAt = fault.ClosedAt,
        Actions = fault.Actions
            .OrderBy(x => x.CreatedAt)
            .Select(x => new FaultActionDto
            {
                Id = x.Id,
                ActionType = x.ActionType,
                UserId = x.UserId,
                UserName = x.User.FullName,
                OldStatus = x.OldStatus?.ToString(),
                NewStatus = x.NewStatus?.ToString(),
                Note = x.Note,
                CreatedAt = x.CreatedAt
            })
            .ToList()
    };

    private static string? NormalizeOptional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
