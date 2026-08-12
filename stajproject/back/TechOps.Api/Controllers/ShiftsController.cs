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
[Route("api/shifts")]
public sealed class ShiftsController(AppDbContext dbContext) : ControllerBase
{
    private static readonly string[] ShiftUserRoles = ["Admin", "Yönetici", "Teknik Personel"];

    [HttpGet("handovers")]
    public async Task<IActionResult> GetHandovers(
        [FromQuery] string? search,
        [FromQuery] string? shiftType,
        [FromQuery] DateOnly? shiftDate,
        [FromQuery] Guid? userId,
        [FromQuery] bool? hasOpenItems,
        CancellationToken cancellationToken)
    {
        var query = HandoverQuery();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lookup = search.Trim().ToLowerInvariant();
            query = query.Where(x =>
                x.HandoverNo.ToLower().Contains(lookup) ||
                (x.Summary != null && x.Summary.ToLower().Contains(lookup)) ||
                (x.CriticalNotes != null && x.CriticalNotes.ToLower().Contains(lookup)) ||
                x.HandoverFromUser.FullName.ToLower().Contains(lookup) ||
                x.HandoverToUser.FullName.ToLower().Contains(lookup));
        }

        if (!string.IsNullOrWhiteSpace(shiftType))
        {
            if (!TryParseShiftType(shiftType, out var parsedShiftType))
            {
                return BadRequest(new { message = "Geçersiz vardiya türü." });
            }

            query = query.Where(x => x.ShiftType == parsedShiftType);
        }

        if (shiftDate.HasValue)
        {
            query = query.Where(x => x.ShiftDate == shiftDate.Value);
        }

        if (userId.HasValue)
        {
            query = query.Where(x => x.HandoverFromUserId == userId.Value || x.HandoverToUserId == userId.Value);
        }

        if (hasOpenItems.HasValue)
        {
            query = hasOpenItems.Value
                ? query.Where(x => x.Items.Any(item => !item.IsCompleted))
                : query.Where(x => !x.Items.Any(item => !item.IsCompleted));
        }

        var handovers = await query
            .OrderByDescending(x => x.ShiftDate)
            .ThenByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

        return Ok(handovers.Select(MapListItem).ToList());
    }

    [HttpGet("handovers/{id:guid}")]
    public async Task<IActionResult> GetHandover(Guid id, CancellationToken cancellationToken)
    {
        var handover = await HandoverQuery().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return handover is null ? NotFound(new { message = "Vardiya devir teslim kaydı bulunamadı." }) : Ok(MapDetail(handover));
    }

    [HttpPost("handovers")]
    public async Task<IActionResult> CreateHandover(CreateShiftHandoverRequest request, CancellationToken cancellationToken)
    {
        var validation = await ValidateHandoverRequest(request, cancellationToken);
        if (validation.Error is not null)
        {
            return validation.Error;
        }

        var now = DateTime.UtcNow;
        var handover = new ShiftHandover
        {
            Id = Guid.NewGuid(),
            HandoverNo = await GenerateHandoverNo(now.Year, cancellationToken),
            ShiftType = validation.ShiftType,
            ShiftDate = request.ShiftDate,
            HandoverFromUserId = validation.HandoverFromUser!.Id,
            HandoverToUserId = validation.HandoverToUser!.Id,
            Summary = NormalizeOptional(request.Summary),
            CriticalNotes = NormalizeOptional(request.CriticalNotes),
            CreatedAt = now
        };

        foreach (var item in validation.Items)
        {
            item.Id = Guid.NewGuid();
            item.ShiftHandoverId = handover.Id;
            item.CreatedAt = now;
            handover.Items.Add(item);
        }

        dbContext.ShiftHandovers.Add(handover);
        await dbContext.SaveChangesAsync(cancellationToken);

        var created = await HandoverQuery().SingleAsync(x => x.Id == handover.Id, cancellationToken);
        return CreatedAtAction(nameof(GetHandover), new { id = created.Id }, MapDetail(created));
    }

    [HttpGet("open-items")]
    public async Task<IActionResult> GetOpenItems(CancellationToken cancellationToken)
    {
        var openFaults = await dbContext.Faults
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
            .Where(x => x.Status != FaultStatus.Closed && x.Status != FaultStatus.Resolved)
            .OrderByDescending(x => x.Priority)
            .ThenByDescending(x => x.CreatedAt)
            .Select(x => new ShiftOpenFaultDto
            {
                Id = x.Id,
                FaultNo = x.FaultNo,
                EquipmentId = x.EquipmentId,
                EquipmentCode = x.Equipment.Code,
                EquipmentName = x.Equipment.Name,
                LocationName = x.Equipment.Location.Name,
                TechnicalSystemName = x.Equipment.TechnicalSystem.Name,
                Priority = x.Priority.ToString(),
                Status = x.Status.ToString(),
                Description = x.Description
            })
            .ToListAsync(cancellationToken);

        var pendingMaintenancePlans = await dbContext.MaintenancePlans
            .Include(x => x.Equipment)
            .Where(x => x.Status != MaintenanceStatus.Completed && x.Status != MaintenanceStatus.Cancelled)
            .OrderBy(x => x.PlannedDate)
            .ThenByDescending(x => x.Priority)
            .Select(x => new ShiftPendingMaintenanceDto
            {
                Id = x.Id,
                PlanNo = x.PlanNo,
                EquipmentId = x.EquipmentId,
                EquipmentCode = x.Equipment.Code,
                EquipmentName = x.Equipment.Name,
                MaintenanceType = x.MaintenanceType,
                PlannedDate = x.PlannedDate,
                Priority = x.Priority.ToString(),
                Status = x.Status.ToString(),
                Description = x.Description
            })
            .ToListAsync(cancellationToken);

        var equipmentToWatch = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .Where(x => x.IsActive)
            .OrderBy(x => x.Code)
            .Select(x => new ShiftEquipmentOptionDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                LocationName = x.Location.Name,
                TechnicalSystemName = x.TechnicalSystem.Name,
                Status = x.Status.ToString()
            })
            .ToListAsync(cancellationToken);

        var openShiftItems = await ItemQuery()
            .Where(x => !x.IsCompleted)
            .OrderByDescending(x => x.Priority == FaultPriority.Critical)
            .ThenByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

        return Ok(new ShiftOpenItemsDto
        {
            OpenFaults = openFaults,
            PendingMaintenancePlans = pendingMaintenancePlans,
            EquipmentToWatch = equipmentToWatch,
            OpenShiftItems = openShiftItems.Select(MapItem).ToList()
        });
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .Include(x => x.Role)
            .Where(x => x.IsActive && ShiftUserRoles.Contains(x.Role.Name))
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

    [HttpPatch("items/{id:guid}/complete")]
    public async Task<IActionResult> UpdateItemStatus(Guid id, UpdateShiftItemStatusRequest request, CancellationToken cancellationToken)
    {
        var item = await dbContext.ShiftItems.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (item is null)
        {
            return NotFound(new { message = "Devredilen iş maddesi bulunamadı." });
        }

        item.IsCompleted = request.IsCompleted;
        item.UpdatedAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        var updated = await ItemQuery().SingleAsync(x => x.Id == id, cancellationToken);
        return Ok(MapItem(updated));
    }

    private IQueryable<ShiftHandover> HandoverQuery() => dbContext.ShiftHandovers
        .Include(x => x.HandoverFromUser)
        .Include(x => x.HandoverToUser)
        .Include(x => x.Items).ThenInclude(x => x.Fault)
        .Include(x => x.Items).ThenInclude(x => x.Equipment)
        .Include(x => x.Items).ThenInclude(x => x.MaintenancePlan);

    private IQueryable<ShiftItem> ItemQuery() => dbContext.ShiftItems
        .Include(x => x.ShiftHandover)
        .Include(x => x.Fault)
        .Include(x => x.Equipment)
        .Include(x => x.MaintenancePlan);

    private async Task<(IActionResult? Error, ShiftType ShiftType, User? HandoverFromUser, User? HandoverToUser, List<ShiftItem> Items)> ValidateHandoverRequest(
        CreateShiftHandoverRequest request,
        CancellationToken cancellationToken)
    {
        if (!TryParseShiftType(request.ShiftType, out var shiftType))
        {
            return (BadRequest(new { message = "Geçerli vardiya türü seçilmelidir." }), default, null, null, []);
        }

        if (request.ShiftDate == default)
        {
            return (BadRequest(new { message = "Vardiya tarihi zorunludur." }), default, null, null, []);
        }

        if (request.HandoverFromUserId == Guid.Empty || request.HandoverToUserId == Guid.Empty)
        {
            return (BadRequest(new { message = "Teslim eden ve teslim alan kullanıcı seçilmelidir." }), default, null, null, []);
        }

        if (request.HandoverFromUserId == request.HandoverToUserId)
        {
            return (BadRequest(new { message = "Teslim eden ve teslim alan kullanıcı aynı olamaz." }), default, null, null, []);
        }

        var handoverFromUser = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == request.HandoverFromUserId && x.IsActive, cancellationToken);
        var handoverToUser = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == request.HandoverToUserId && x.IsActive, cancellationToken);

        if (handoverFromUser is null || !ShiftUserRoles.Contains(handoverFromUser.Role.Name))
        {
            return (BadRequest(new { message = "Teslim eden kullanıcı aktif yönetici veya teknik personel olmalıdır." }), default, null, null, []);
        }

        if (handoverToUser is null || !ShiftUserRoles.Contains(handoverToUser.Role.Name))
        {
            return (BadRequest(new { message = "Teslim alan kullanıcı aktif yönetici veya teknik personel olmalıdır." }), default, null, null, []);
        }

        var items = await NormalizeItems(request.Items, cancellationToken);
        if (items.Error is not null)
        {
            return (items.Error, default, null, null, []);
        }

        if (string.IsNullOrWhiteSpace(request.Summary) && string.IsNullOrWhiteSpace(request.CriticalNotes) && items.Items.Count == 0)
        {
            return (BadRequest(new { message = "Devir teslim için özet, kritik not veya en az bir iş maddesi girilmelidir." }), default, null, null, []);
        }

        return (null, shiftType, handoverFromUser, handoverToUser, items.Items);
    }

    private async Task<(IActionResult? Error, List<ShiftItem> Items)> NormalizeItems(IEnumerable<CreateShiftItemRequest> requests, CancellationToken cancellationToken)
    {
        var items = new List<ShiftItem>();

        foreach (var request in requests)
        {
            if (!TryParseItemType(request.ItemType, out var itemType))
            {
                return (BadRequest(new { message = "Geçersiz devir maddesi türü." }), []);
            }

            if (!TryParsePriority(request.Priority, out var priority))
            {
                return (BadRequest(new { message = "Geçersiz devir maddesi önceliği." }), []);
            }

            var validation = await ValidateItemReference(itemType, request, cancellationToken);
            if (validation.Error is not null)
            {
                return (validation.Error, []);
            }

            var title = string.IsNullOrWhiteSpace(request.Title) ? validation.DefaultTitle : request.Title.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                return (BadRequest(new { message = "Devir maddesi başlığı zorunludur." }), []);
            }

            items.Add(new ShiftItem
            {
                ItemType = itemType,
                Title = title,
                Description = NormalizeOptional(request.Description) ?? validation.DefaultDescription,
                FaultId = request.FaultId,
                EquipmentId = validation.EquipmentId,
                MaintenancePlanId = request.MaintenancePlanId,
                Priority = priority,
                IsCompleted = false
            });
        }

        return (null, items);
    }

    private async Task<(IActionResult? Error, Guid? EquipmentId, string DefaultTitle, string? DefaultDescription)> ValidateItemReference(
        ShiftItemType itemType,
        CreateShiftItemRequest request,
        CancellationToken cancellationToken)
    {
        if (itemType == ShiftItemType.OpenFault)
        {
            if (!request.FaultId.HasValue)
            {
                return (BadRequest(new { message = "Açık arıza maddesi için arıza seçilmelidir." }), null, string.Empty, null);
            }

            var fault = await dbContext.Faults
                .Include(x => x.Equipment)
                .SingleOrDefaultAsync(x => x.Id == request.FaultId.Value, cancellationToken);
            if (fault is null || fault.Status is FaultStatus.Resolved or FaultStatus.Closed)
            {
                return (BadRequest(new { message = "Yalnızca kapanmamış arızalar devredilebilir." }), null, string.Empty, null);
            }

            return (null, fault.EquipmentId, $"{fault.FaultNo} - {fault.Equipment.Name}", fault.Description);
        }

        if (itemType == ShiftItemType.PendingMaintenance)
        {
            if (!request.MaintenancePlanId.HasValue)
            {
                return (BadRequest(new { message = "Bekleyen bakım maddesi için bakım planı seçilmelidir." }), null, string.Empty, null);
            }

            var plan = await dbContext.MaintenancePlans
                .Include(x => x.Equipment)
                .SingleOrDefaultAsync(x => x.Id == request.MaintenancePlanId.Value, cancellationToken);
            if (plan is null || plan.Status is MaintenanceStatus.Completed or MaintenanceStatus.Cancelled)
            {
                return (BadRequest(new { message = "Yalnızca tamamlanmamış bakım planları devredilebilir." }), null, string.Empty, null);
            }

            return (null, plan.EquipmentId, $"{plan.PlanNo} - {plan.MaintenanceType}", plan.Description);
        }

        if (itemType == ShiftItemType.EquipmentToWatch)
        {
            if (!request.EquipmentId.HasValue)
            {
                return (BadRequest(new { message = "Takip edilecek cihaz maddesi için ekipman seçilmelidir." }), null, string.Empty, null);
            }

            var equipment = await dbContext.Equipment.SingleOrDefaultAsync(x => x.Id == request.EquipmentId.Value && x.IsActive, cancellationToken);
            if (equipment is null)
            {
                return (BadRequest(new { message = "Geçerli ve aktif bir ekipman seçilmelidir." }), null, string.Empty, null);
            }

            return (null, equipment.Id, $"{equipment.Code} - {equipment.Name}", request.Description);
        }

        return (null, request.EquipmentId, string.Empty, request.Description);
    }

    private async Task<string> GenerateHandoverNo(int year, CancellationToken cancellationToken)
    {
        var start = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var end = start.AddYears(1);
        var sequence = await dbContext.ShiftHandovers.CountAsync(x => x.CreatedAt >= start && x.CreatedAt < end, cancellationToken) + 1;
        string handoverNo;

        do
        {
            handoverNo = $"VDT-{year}-{sequence:000}";
            sequence++;
        }
        while (await dbContext.ShiftHandovers.AnyAsync(x => x.HandoverNo == handoverNo, cancellationToken));

        return handoverNo;
    }

    private static ShiftHandoverListItemDto MapListItem(ShiftHandover handover) => new()
    {
        Id = handover.Id,
        HandoverNo = handover.HandoverNo,
        ShiftType = handover.ShiftType.ToString(),
        ShiftDate = handover.ShiftDate,
        HandoverFromUserId = handover.HandoverFromUserId,
        HandoverFromUserName = handover.HandoverFromUser.FullName,
        HandoverToUserId = handover.HandoverToUserId,
        HandoverToUserName = handover.HandoverToUser.FullName,
        Summary = handover.Summary,
        CriticalNotes = handover.CriticalNotes,
        ItemCount = handover.Items.Count,
        OpenItemCount = handover.Items.Count(x => !x.IsCompleted),
        CriticalItemCount = handover.Items.Count(x => x.ItemType == ShiftItemType.CriticalNote || x.Priority == FaultPriority.Critical),
        CreatedAt = handover.CreatedAt,
        UpdatedAt = handover.UpdatedAt
    };

    private static ShiftHandoverDetailDto MapDetail(ShiftHandover handover) => new()
    {
        Id = handover.Id,
        HandoverNo = handover.HandoverNo,
        ShiftType = handover.ShiftType.ToString(),
        ShiftDate = handover.ShiftDate,
        HandoverFromUserId = handover.HandoverFromUserId,
        HandoverFromUserName = handover.HandoverFromUser.FullName,
        HandoverFromUserTitle = handover.HandoverFromUser.Title,
        HandoverToUserId = handover.HandoverToUserId,
        HandoverToUserName = handover.HandoverToUser.FullName,
        HandoverToUserTitle = handover.HandoverToUser.Title,
        Summary = handover.Summary,
        CriticalNotes = handover.CriticalNotes,
        ItemCount = handover.Items.Count,
        OpenItemCount = handover.Items.Count(x => !x.IsCompleted),
        CriticalItemCount = handover.Items.Count(x => x.ItemType == ShiftItemType.CriticalNote || x.Priority == FaultPriority.Critical),
        CreatedAt = handover.CreatedAt,
        UpdatedAt = handover.UpdatedAt,
        Items = handover.Items.OrderBy(x => x.IsCompleted).ThenBy(x => x.ItemType).ThenBy(x => x.Title).Select(MapItem).ToList()
    };

    private static ShiftItemDto MapItem(ShiftItem item) => new()
    {
        Id = item.Id,
        ShiftHandoverId = item.ShiftHandoverId,
        HandoverNo = item.ShiftHandover.HandoverNo,
        ItemType = item.ItemType.ToString(),
        Title = item.Title,
        Description = item.Description,
        FaultId = item.FaultId,
        FaultNo = item.Fault?.FaultNo,
        FaultStatus = item.Fault?.Status.ToString(),
        EquipmentId = item.EquipmentId,
        EquipmentCode = item.Equipment?.Code,
        EquipmentName = item.Equipment?.Name,
        MaintenancePlanId = item.MaintenancePlanId,
        MaintenancePlanNo = item.MaintenancePlan?.PlanNo,
        Priority = item.Priority?.ToString(),
        IsCompleted = item.IsCompleted,
        CreatedAt = item.CreatedAt,
        UpdatedAt = item.UpdatedAt
    };

    private static bool TryParseShiftType(string? value, out ShiftType shiftType)
    {
        return Enum.TryParse(value?.Trim(), ignoreCase: true, out shiftType) && Enum.IsDefined(shiftType);
    }

    private static bool TryParseItemType(string? value, out ShiftItemType itemType)
    {
        return Enum.TryParse(value?.Trim(), ignoreCase: true, out itemType) && Enum.IsDefined(itemType);
    }

    private static bool TryParsePriority(string? value, out FaultPriority? priority)
    {
        priority = null;
        if (string.IsNullOrWhiteSpace(value))
        {
            return true;
        }

        if (Enum.TryParse(value.Trim(), ignoreCase: true, out FaultPriority parsedPriority) && Enum.IsDefined(parsedPriority))
        {
            priority = parsedPriority;
            return true;
        }

        return false;
    }

    private static string? NormalizeOptional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
