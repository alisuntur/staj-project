namespace TechOps.Api.Models;

public sealed class LocationDto
{
    public Guid Id { get; set; }
    public Guid? ParentLocationId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public sealed class TechnicalSystemDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public sealed class EquipmentListItemDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public sealed class EquipmentDetailDto
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public LocationDto Location { get; set; } = null!;
    public TechnicalSystemDto TechnicalSystem { get; set; } = null!;
}

public sealed class EquipmentHistoryDto
{
    public EquipmentDetailDto Equipment { get; set; } = null!;
    public EquipmentHistorySummaryDto Summary { get; set; } = null!;
    public IReadOnlyList<EquipmentHistoryFaultDto> Faults { get; set; } = new List<EquipmentHistoryFaultDto>();
    public IReadOnlyList<EquipmentHistoryMaintenancePlanDto> MaintenancePlans { get; set; } = new List<EquipmentHistoryMaintenancePlanDto>();
    public IReadOnlyList<EquipmentHistoryMaintenanceRecordDto> MaintenanceRecords { get; set; } = new List<EquipmentHistoryMaintenanceRecordDto>();
    public IReadOnlyList<EquipmentHistoryTestRecordDto> TestRecords { get; set; } = new List<EquipmentHistoryTestRecordDto>();
    public IReadOnlyList<EquipmentHistoryShiftItemDto> ShiftItems { get; set; } = new List<EquipmentHistoryShiftItemDto>();
}

public sealed class EquipmentHistorySummaryDto
{
    public int FaultCount { get; set; }
    public int OpenFaultCount { get; set; }
    public int MaintenancePlanCount { get; set; }
    public int CompletedMaintenanceCount { get; set; }
    public int TestRecordCount { get; set; }
    public int FailedTestCount { get; set; }
    public int OpenShiftItemCount { get; set; }
    public DateTime? LastActivityAt { get; set; }
}

public sealed class EquipmentHistoryFaultDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatedByUserName { get; set; } = string.Empty;
    public string? AssignedToUserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class EquipmentHistoryMaintenancePlanDto
{
    public Guid Id { get; set; }
    public string PlanNo { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ResponsibleUserName { get; set; } = string.Empty;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? Description { get; set; }
}

public sealed class EquipmentHistoryMaintenanceRecordDto
{
    public Guid Id { get; set; }
    public Guid? MaintenancePlanId { get; set; }
    public string? PlanNo { get; set; }
    public string MaintenanceType { get; set; } = string.Empty;
    public string PerformedByUserName { get; set; } = string.Empty;
    public DateTime? StartedAt { get; set; }
    public DateTime CompletedAt { get; set; }
    public string ResultStatus { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public sealed class EquipmentHistoryTestRecordDto
{
    public Guid Id { get; set; }
    public Guid? TestPlanId { get; set; }
    public string TestType { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public int? DurationMinutes { get; set; }
    public string Result { get; set; } = string.Empty;
    public string TestedByUserName { get; set; } = string.Empty;
    public string? AbnormalCondition { get; set; }
    public string? Description { get; set; }
}

public sealed class EquipmentHistoryShiftItemDto
{
    public Guid Id { get; set; }
    public Guid ShiftHandoverId { get; set; }
    public string HandoverNo { get; set; } = string.Empty;
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public string ItemType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FaultNo { get; set; }
    public string? MaintenancePlanNo { get; set; }
    public string? Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class CreateEquipmentRequest
{
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string Status { get; set; } = "Active";
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
}

public sealed class UpdateEquipmentRequest
{
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string Status { get; set; } = "Active";
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public sealed class UpdateEquipmentStatusRequest
{
    public string Status { get; set; } = "Active";
    public bool IsActive { get; set; } = true;
}
