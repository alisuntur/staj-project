using System.Security.Claims;
using System.Text.Json;
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
[Route("api/maintenance")]
public sealed class MaintenanceController(AppDbContext dbContext) : ControllerBase
{
    private static readonly string[] ResponsibleRoles = ["Admin", "Yönetici", "Teknik Personel"];

    [HttpGet("plans")]
    public async Task<IActionResult> GetPlans(
        [FromQuery] string? search,
        [FromQuery] string? status,
        [FromQuery] Guid? equipmentId,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] Guid? responsibleUserId,
        [FromQuery] string? maintenanceType,
        [FromQuery] DateOnly? plannedFrom,
        [FromQuery] DateOnly? plannedTo,
        CancellationToken cancellationToken)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var query = PlanQuery();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lookup = search.Trim().ToLowerInvariant();
            query = query.Where(x =>
                x.PlanNo.ToLower().Contains(lookup) ||
                x.MaintenanceType.ToLower().Contains(lookup) ||
                (x.Description != null && x.Description.ToLower().Contains(lookup)) ||
                x.Equipment.Code.ToLower().Contains(lookup) ||
                x.Equipment.Name.ToLower().Contains(lookup));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (status.Trim().Equals("Delayed", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(x => x.Status != MaintenanceStatus.Completed && x.PlannedDate < today);
            }
            else
            {
                if (!TryParseMaintenanceStatus(status, out var parsedStatus))
                {
                    return BadRequest(new { message = "Geçersiz bakım durumu." });
                }

                query = query.Where(x => x.Status == parsedStatus);
            }
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.Equipment.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        }

        if (responsibleUserId.HasValue)
        {
            query = query.Where(x => x.ResponsibleUserId == responsibleUserId.Value);
        }

        if (!string.IsNullOrWhiteSpace(maintenanceType))
        {
            var typeLookup = maintenanceType.Trim().ToLowerInvariant();
            query = query.Where(x => x.MaintenanceType.ToLower().Contains(typeLookup));
        }

        if (plannedFrom.HasValue)
        {
            query = query.Where(x => x.PlannedDate >= plannedFrom.Value);
        }

        if (plannedTo.HasValue)
        {
            query = query.Where(x => x.PlannedDate <= plannedTo.Value);
        }

        var planEntities = await query
            .OrderBy(x => x.Status == MaintenanceStatus.Completed)
            .ThenBy(x => x.PlannedDate)
            .ThenBy(x => x.PlanNo)
            .ToListAsync(cancellationToken);
        var plans = planEntities.Select(x => MapListItem(x, today)).ToList();

        return Ok(plans);
    }

    [HttpGet("plans/{id:guid}")]
    public async Task<IActionResult> GetPlan(Guid id, CancellationToken cancellationToken)
    {
        var plan = await PlanDetailQuery().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return plan is null ? NotFound(new { message = "Bakım planı bulunamadı." }) : Ok(MapDetail(plan));
    }

    [HttpPost("plans")]
    public async Task<IActionResult> CreatePlan(CreateMaintenancePlanRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var validation = await ValidatePlanRequest(request.EquipmentId, request.ResponsibleUserId, request.MaintenanceType, request.PlannedDate, request.Priority, cancellationToken);
        if (validation.Error is not null)
        {
            return validation.Error;
        }

        var now = DateTime.UtcNow;
        var plan = new MaintenancePlan
        {
            Id = Guid.NewGuid(),
            PlanNo = await GeneratePlanNo(now.Year, cancellationToken),
            EquipmentId = validation.Equipment!.Id,
            ResponsibleUserId = validation.ResponsibleUser!.Id,
            CreatedByUserId = currentUserId,
            MaintenanceType = request.MaintenanceType.Trim(),
            PlannedDate = request.PlannedDate,
            Frequency = NormalizeOptional(request.Frequency),
            Priority = validation.Priority,
            Status = MaintenanceStatus.Planned,
            Description = NormalizeOptional(request.Description),
            CreatedAt = now
        };

        dbContext.MaintenancePlans.Add(plan);
        await dbContext.SaveChangesAsync(cancellationToken);

        var created = await PlanDetailQuery().SingleAsync(x => x.Id == plan.Id, cancellationToken);
        return CreatedAtAction(nameof(GetPlan), new { id = created.Id }, MapDetail(created));
    }

    [HttpPut("plans/{id:guid}")]
    public async Task<IActionResult> UpdatePlan(Guid id, UpdateMaintenancePlanRequest request, CancellationToken cancellationToken)
    {
        var plan = await dbContext.MaintenancePlans.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (plan is null)
        {
            return NotFound(new { message = "Bakım planı bulunamadı." });
        }

        if (plan.Status != MaintenanceStatus.Planned)
        {
            return BadRequest(new { message = "Başlamış veya tamamlanmış bakım planı güncellenemez." });
        }

        var validation = await ValidatePlanRequest(request.EquipmentId, request.ResponsibleUserId, request.MaintenanceType, request.PlannedDate, request.Priority, cancellationToken);
        if (validation.Error is not null)
        {
            return validation.Error;
        }

        plan.EquipmentId = validation.Equipment!.Id;
        plan.ResponsibleUserId = validation.ResponsibleUser!.Id;
        plan.MaintenanceType = request.MaintenanceType.Trim();
        plan.PlannedDate = request.PlannedDate;
        plan.Frequency = NormalizeOptional(request.Frequency);
        plan.Priority = validation.Priority;
        plan.Description = NormalizeOptional(request.Description);
        plan.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await PlanDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [HttpPost("plans/{id:guid}/start")]
    public async Task<IActionResult> StartPlan(Guid id, StartMaintenancePlanRequest request, CancellationToken cancellationToken)
    {
        var plan = await dbContext.MaintenancePlans
            .Include(x => x.Equipment)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (plan is null)
        {
            return NotFound(new { message = "Bakım planı bulunamadı." });
        }

        if (plan.Status != MaintenanceStatus.Planned)
        {
            return BadRequest(new { message = "Yalnızca planlandı durumundaki bakım başlatılabilir." });
        }

        var now = DateTime.UtcNow;
        plan.Status = MaintenanceStatus.Started;
        plan.StartedAt = now;
        plan.UpdatedAt = now;

        if (plan.Equipment.Status == EquipmentStatus.Active)
        {
            plan.Equipment.Status = EquipmentStatus.Maintenance;
            plan.Equipment.UpdatedAt = now;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await PlanDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [HttpPost("plans/{id:guid}/complete")]
    public async Task<IActionResult> CompletePlan(Guid id, CompleteMaintenancePlanRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            return BadRequest(new { message = "Bakım tamamlama açıklaması zorunludur." });
        }

        if (!TryParseResultStatus(request.ResultStatus, out var resultStatus))
        {
            return BadRequest(new { message = "Geçersiz bakım sonucu." });
        }

        var plan = await dbContext.MaintenancePlans
            .Include(x => x.Equipment)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (plan is null)
        {
            return NotFound(new { message = "Bakım planı bulunamadı." });
        }

        if (plan.Status != MaintenanceStatus.Started)
        {
            return BadRequest(new { message = "Yalnızca başladı durumundaki bakım tamamlanabilir." });
        }

        var now = DateTime.UtcNow;
        var completedAt = request.CompletedAt.HasValue ? NormalizeDateTime(request.CompletedAt.Value) : now;
        var checklistItems = NormalizeChecklist(request.ChecklistItems);

        plan.Status = MaintenanceStatus.Completed;
        plan.CompletedAt = completedAt;
        plan.UpdatedAt = now;

        if (plan.Equipment.Status == EquipmentStatus.Maintenance)
        {
            plan.Equipment.Status = EquipmentStatus.Active;
            plan.Equipment.UpdatedAt = now;
        }

        dbContext.MaintenanceRecords.Add(new MaintenanceRecord
        {
            Id = Guid.NewGuid(),
            MaintenancePlanId = plan.Id,
            EquipmentId = plan.EquipmentId,
            PerformedByUserId = currentUserId,
            MaintenanceType = plan.MaintenanceType,
            StartedAt = plan.StartedAt,
            CompletedAt = completedAt,
            ResultStatus = resultStatus,
            Description = request.Description.Trim(),
            UsedMaterials = NormalizeOptional(request.UsedMaterials),
            ChecklistJson = checklistItems.Count > 0 ? JsonSerializer.Serialize(checklistItems) : null,
            CreatedAt = now
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await PlanDetailQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapDetail(updated));
    }

    [HttpGet("records")]
    public async Task<IActionResult> GetRecords(
        [FromQuery] Guid? equipmentId,
        [FromQuery] Guid? responsibleUserId,
        [FromQuery] string? maintenanceType,
        [FromQuery] string? resultStatus,
        [FromQuery] DateTime? completedFrom,
        [FromQuery] DateTime? completedTo,
        CancellationToken cancellationToken)
    {
        var query = RecordQuery();

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (responsibleUserId.HasValue)
        {
            query = query.Where(x => x.PerformedByUserId == responsibleUserId.Value || (x.MaintenancePlan != null && x.MaintenancePlan.ResponsibleUserId == responsibleUserId.Value));
        }

        if (!string.IsNullOrWhiteSpace(maintenanceType))
        {
            var typeLookup = maintenanceType.Trim().ToLowerInvariant();
            query = query.Where(x => x.MaintenanceType.ToLower().Contains(typeLookup));
        }

        if (!string.IsNullOrWhiteSpace(resultStatus))
        {
            if (!TryParseResultStatus(resultStatus, out var parsedResultStatus))
            {
                return BadRequest(new { message = "Geçersiz bakım sonucu." });
            }

            query = query.Where(x => x.ResultStatus == parsedResultStatus);
        }

        if (completedFrom.HasValue)
        {
            var from = NormalizeDateTime(completedFrom.Value);
            query = query.Where(x => x.CompletedAt >= from);
        }

        if (completedTo.HasValue)
        {
            var to = NormalizeDateTime(completedTo.Value);
            query = query.Where(x => x.CompletedAt <= to);
        }

        var recordEntities = await query
            .OrderByDescending(x => x.CompletedAt)
            .ToListAsync(cancellationToken);
        var records = recordEntities.Select(MapRecord).ToList();

        return Ok(records);
    }

    [HttpGet("responsible-users")]
    public async Task<IActionResult> GetResponsibleUsers(CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .Include(x => x.Role)
            .Where(x => x.IsActive && ResponsibleRoles.Contains(x.Role.Name))
            .OrderBy(x => x.FullName)
            .Select(x => new UserListItemDto
            {
                Id = x.Id,
                RoleId = x.RoleId,
                FullName = x.FullName,
                Username = x.Username,
                Email = x.Email,
                Role = x.Role.Name,
                Title = x.Title,
                Department = x.Department,
                IsActive = x.IsActive,
                LastLoginAt = x.LastLoginAt
            })
            .ToListAsync(cancellationToken);

        return Ok(users);
    }

    private IQueryable<MaintenancePlan> PlanQuery() => dbContext.MaintenancePlans
        .Include(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
        .Include(x => x.ResponsibleUser)
        .Include(x => x.CreatedByUser);

    private IQueryable<MaintenancePlan> PlanDetailQuery() => dbContext.MaintenancePlans
        .Include(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
        .Include(x => x.ResponsibleUser)
        .Include(x => x.CreatedByUser)
        .Include(x => x.Records).ThenInclude(x => x.PerformedByUser)
        .Include(x => x.Records).ThenInclude(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Records).ThenInclude(x => x.Equipment).ThenInclude(x => x.TechnicalSystem);

    private IQueryable<MaintenanceRecord> RecordQuery() => dbContext.MaintenanceRecords
        .Include(x => x.MaintenancePlan)
        .Include(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
        .Include(x => x.PerformedByUser);

    private async Task<(IActionResult? Error, Equipment? Equipment, User? ResponsibleUser, FaultPriority Priority)> ValidatePlanRequest(
        Guid equipmentId,
        Guid responsibleUserId,
        string maintenanceType,
        DateOnly plannedDate,
        string priority,
        CancellationToken cancellationToken)
    {
        if (equipmentId == Guid.Empty)
        {
            return (BadRequest(new { message = "Hedef ekipman seçimi zorunludur." }), null, null, default);
        }

        if (responsibleUserId == Guid.Empty)
        {
            return (BadRequest(new { message = "Sorumlu kişi seçimi zorunludur." }), null, null, default);
        }

        if (string.IsNullOrWhiteSpace(maintenanceType))
        {
            return (BadRequest(new { message = "Bakım türü zorunludur." }), null, null, default);
        }

        if (plannedDate == default)
        {
            return (BadRequest(new { message = "Planlanan tarih zorunludur." }), null, null, default);
        }

        if (!TryParsePriority(priority, out var parsedPriority))
        {
            return (BadRequest(new { message = "Geçersiz bakım kritiklik seviyesi." }), null, null, default);
        }

        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == equipmentId, cancellationToken);

        if (equipment is null || !equipment.IsActive || !equipment.Location.IsActive || !equipment.TechnicalSystem.IsActive)
        {
            return (BadRequest(new { message = "Geçerli ve aktif bir ekipman seçilmelidir." }), null, null, default);
        }

        var responsibleUser = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == responsibleUserId && x.IsActive, cancellationToken);

        if (responsibleUser is null || !ResponsibleRoles.Contains(responsibleUser.Role.Name))
        {
            return (BadRequest(new { message = "Sorumlu kişi aktif yönetici veya teknik personel olmalıdır." }), null, null, default);
        }

        return (null, equipment, responsibleUser, parsedPriority);
    }

    private async Task<string> GeneratePlanNo(int year, CancellationToken cancellationToken)
    {
        var start = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var end = start.AddYears(1);
        var sequence = await dbContext.MaintenancePlans.CountAsync(x => x.CreatedAt >= start && x.CreatedAt < end, cancellationToken) + 1;
        string planNo;

        do
        {
            planNo = $"BKM-{year}-{sequence:000}";
            sequence++;
        }
        while (await dbContext.MaintenancePlans.AnyAsync(x => x.PlanNo == planNo, cancellationToken));

        return planNo;
    }

    private bool TryGetCurrentUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(userIdClaim, out userId);
    }

    private static MaintenancePlanListItemDto MapListItem(MaintenancePlan plan, DateOnly today) => new()
    {
        Id = plan.Id,
        PlanNo = plan.PlanNo,
        EquipmentId = plan.EquipmentId,
        EquipmentCode = plan.Equipment.Code,
        EquipmentName = plan.Equipment.Name,
        LocationId = plan.Equipment.LocationId,
        LocationName = plan.Equipment.Location.Name,
        TechnicalSystemId = plan.Equipment.TechnicalSystemId,
        TechnicalSystemName = plan.Equipment.TechnicalSystem.Name,
        ResponsibleUserId = plan.ResponsibleUserId,
        ResponsibleUserName = plan.ResponsibleUser.FullName,
        MaintenanceType = plan.MaintenanceType,
        PlannedDate = plan.PlannedDate,
        Frequency = plan.Frequency,
        Priority = plan.Priority.ToString(),
        Status = plan.Status.ToString(),
        DisplayStatus = GetDisplayStatus(plan.Status, plan.PlannedDate, today),
        Description = plan.Description,
        StartedAt = plan.StartedAt,
        CompletedAt = plan.CompletedAt,
        CreatedAt = plan.CreatedAt,
        UpdatedAt = plan.UpdatedAt
    };

    private static MaintenancePlanDetailDto MapDetail(MaintenancePlan plan)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        return new MaintenancePlanDetailDto
        {
            Id = plan.Id,
            PlanNo = plan.PlanNo,
            EquipmentId = plan.EquipmentId,
            EquipmentCode = plan.Equipment.Code,
            EquipmentName = plan.Equipment.Name,
            LocationId = plan.Equipment.LocationId,
            LocationName = plan.Equipment.Location.Name,
            TechnicalSystemId = plan.Equipment.TechnicalSystemId,
            TechnicalSystemName = plan.Equipment.TechnicalSystem.Name,
            ResponsibleUserId = plan.ResponsibleUserId,
            ResponsibleUserName = plan.ResponsibleUser.FullName,
            ResponsibleUserTitle = plan.ResponsibleUser.Title,
            ResponsibleUserDepartment = plan.ResponsibleUser.Department,
            CreatedByUserId = plan.CreatedByUserId,
            CreatedByUserName = plan.CreatedByUser.FullName,
            MaintenanceType = plan.MaintenanceType,
            PlannedDate = plan.PlannedDate,
            Frequency = plan.Frequency,
            Priority = plan.Priority.ToString(),
            Status = plan.Status.ToString(),
            DisplayStatus = GetDisplayStatus(plan.Status, plan.PlannedDate, today),
            Description = plan.Description,
            StartedAt = plan.StartedAt,
            CompletedAt = plan.CompletedAt,
            CreatedAt = plan.CreatedAt,
            UpdatedAt = plan.UpdatedAt,
            Records = plan.Records.OrderBy(x => x.CompletedAt).Select(MapRecord).ToList()
        };
    }

    private static MaintenanceRecordDto MapRecord(MaintenanceRecord record) => new()
    {
        Id = record.Id,
        MaintenancePlanId = record.MaintenancePlanId,
        PlanNo = record.MaintenancePlan?.PlanNo,
        EquipmentId = record.EquipmentId,
        EquipmentCode = record.Equipment.Code,
        EquipmentName = record.Equipment.Name,
        LocationId = record.Equipment.LocationId,
        LocationName = record.Equipment.Location.Name,
        TechnicalSystemId = record.Equipment.TechnicalSystemId,
        TechnicalSystemName = record.Equipment.TechnicalSystem.Name,
        PerformedByUserId = record.PerformedByUserId,
        PerformedByUserName = record.PerformedByUser.FullName,
        MaintenanceType = record.MaintenanceType,
        StartedAt = record.StartedAt,
        CompletedAt = record.CompletedAt,
        ResultStatus = record.ResultStatus.ToString(),
        Description = record.Description,
        UsedMaterials = record.UsedMaterials,
        ChecklistItems = ParseChecklist(record.ChecklistJson),
        CreatedAt = record.CreatedAt
    };

    private static string GetDisplayStatus(MaintenanceStatus status, DateOnly plannedDate, DateOnly today)
    {
        return status != MaintenanceStatus.Completed && plannedDate < today ? "Delayed" : status.ToString();
    }

    private static bool TryParseMaintenanceStatus(string? status, out MaintenanceStatus parsedStatus)
    {
        return Enum.TryParse(status?.Trim(), ignoreCase: true, out parsedStatus) && Enum.IsDefined(parsedStatus);
    }

    private static bool TryParsePriority(string? priority, out FaultPriority parsedPriority)
    {
        return Enum.TryParse(priority?.Trim(), ignoreCase: true, out parsedPriority) && Enum.IsDefined(parsedPriority);
    }

    private static bool TryParseResultStatus(string? status, out MaintenanceResultStatus parsedStatus)
    {
        return Enum.TryParse(status?.Trim(), ignoreCase: true, out parsedStatus) && Enum.IsDefined(parsedStatus);
    }

    private static DateTime NormalizeDateTime(DateTime value) => value.Kind switch
    {
        DateTimeKind.Local => value.ToUniversalTime(),
        DateTimeKind.Utc => value,
        _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
    };

    private static string? NormalizeOptional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    private static List<MaintenanceChecklistItemDto> NormalizeChecklist(IEnumerable<MaintenanceChecklistItemDto> items) => items
        .Where(x => !string.IsNullOrWhiteSpace(x.Text))
        .Select(x => new MaintenanceChecklistItemDto { Text = x.Text.Trim(), IsChecked = x.IsChecked })
        .ToList();

    private static IReadOnlyList<MaintenanceChecklistItemDto> ParseChecklist(string? checklistJson)
    {
        if (string.IsNullOrWhiteSpace(checklistJson))
        {
            return [];
        }

        try
        {
            return JsonSerializer.Deserialize<List<MaintenanceChecklistItemDto>>(checklistJson) ?? [];
        }
        catch (JsonException)
        {
            return [];
        }
    }
}
