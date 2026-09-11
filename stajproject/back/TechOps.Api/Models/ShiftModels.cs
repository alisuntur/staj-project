namespace TechOps.Api.Models;

public sealed class ShiftHandoverListItemDto
{
    public Guid Id { get; set; }
    public string HandoverNo { get; set; } = string.Empty;
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public Guid HandoverFromUserId { get; set; }
    public string HandoverFromUserName { get; set; } = string.Empty;
    public Guid HandoverToUserId { get; set; }
    public string HandoverToUserName { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public string? CriticalNotes { get; set; }
    public int ItemCount { get; set; }
    public int OpenItemCount { get; set; }
    public int CriticalItemCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class ShiftHandoverDetailDto
{
    public Guid Id { get; set; }
    public string HandoverNo { get; set; } = string.Empty;
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public Guid HandoverFromUserId { get; set; }
    public string HandoverFromUserName { get; set; } = string.Empty;
    public string? HandoverFromUserTitle { get; set; }
    public Guid HandoverToUserId { get; set; }
    public string HandoverToUserName { get; set; } = string.Empty;
    public string? HandoverToUserTitle { get; set; }
    public string? Summary { get; set; }
    public string? CriticalNotes { get; set; }
    public int ItemCount { get; set; }
    public int OpenItemCount { get; set; }
    public int CriticalItemCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public IReadOnlyList<ShiftItemDto> Items { get; set; } = new List<ShiftItemDto>();
}

public sealed class ShiftItemDto
{
    public Guid Id { get; set; }
    public Guid ShiftHandoverId { get; set; }
    public string HandoverNo { get; set; } = string.Empty;
    public string ItemType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? FaultId { get; set; }
    public string? FaultNo { get; set; }
    public string? FaultStatus { get; set; }
    public Guid? EquipmentId { get; set; }
    public string? EquipmentCode { get; set; }
    public string? EquipmentName { get; set; }
    public Guid? MaintenancePlanId { get; set; }
    public string? MaintenancePlanNo { get; set; }
    public string? Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class ShiftOpenItemsDto
{
    public IReadOnlyList<ShiftOpenFaultDto> OpenFaults { get; set; } = new List<ShiftOpenFaultDto>();
    public IReadOnlyList<ShiftPendingMaintenanceDto> PendingMaintenancePlans { get; set; } = new List<ShiftPendingMaintenanceDto>();
    public IReadOnlyList<ShiftEquipmentOptionDto> EquipmentToWatch { get; set; } = new List<ShiftEquipmentOptionDto>();
    public IReadOnlyList<ShiftItemDto> OpenShiftItems { get; set; } = new List<ShiftItemDto>();
}

public sealed class ShiftOpenFaultDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public sealed class ShiftPendingMaintenanceDto
{
    public Guid Id { get; set; }
    public string PlanNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public sealed class ShiftEquipmentOptionDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public sealed class ShiftAssignmentDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserRole { get; set; } = string.Empty;
    public string? UserTitle { get; set; }
    public string? UserDepartment { get; set; }
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class CreateShiftHandoverRequest
{
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public Guid HandoverFromUserId { get; set; }
    public Guid HandoverToUserId { get; set; }
    public string? Summary { get; set; }
    public string? CriticalNotes { get; set; }
    public IReadOnlyList<CreateShiftItemRequest> Items { get; set; } = new List<CreateShiftItemRequest>();
}

public sealed class CreateShiftItemRequest
{
    public string ItemType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? FaultId { get; set; }
    public Guid? EquipmentId { get; set; }
    public Guid? MaintenancePlanId { get; set; }
    public string? Priority { get; set; }
}

public sealed class UpdateShiftItemStatusRequest
{
    public bool IsCompleted { get; set; } = true;
}

public sealed class SaveShiftAssignmentRequest
{
    public Guid UserId { get; set; }
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public string? Notes { get; set; }
}
