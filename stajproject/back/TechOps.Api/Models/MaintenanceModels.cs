namespace TechOps.Api.Models;

public sealed class MaintenancePlanListItemDto
{
    public Guid Id { get; set; }
    public string PlanNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public Guid ResponsibleUserId { get; set; }
    public string ResponsibleUserName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string DisplayStatus { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class MaintenancePlanDetailDto
{
    public Guid Id { get; set; }
    public string PlanNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public Guid ResponsibleUserId { get; set; }
    public string ResponsibleUserName { get; set; } = string.Empty;
    public string? ResponsibleUserTitle { get; set; }
    public string? ResponsibleUserDepartment { get; set; }
    public Guid CreatedByUserId { get; set; }
    public string CreatedByUserName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string DisplayStatus { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public IReadOnlyList<MaintenanceRecordDto> Records { get; set; } = new List<MaintenanceRecordDto>();
}

public sealed class MaintenanceRecordDto
{
    public Guid Id { get; set; }
    public Guid? MaintenancePlanId { get; set; }
    public string? PlanNo { get; set; }
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public Guid PerformedByUserId { get; set; }
    public string PerformedByUserName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public DateTime? StartedAt { get; set; }
    public DateTime CompletedAt { get; set; }
    public string ResultStatus { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? UsedMaterials { get; set; }
    public IReadOnlyList<MaintenanceChecklistItemDto> ChecklistItems { get; set; } = new List<MaintenanceChecklistItemDto>();
    public DateTime CreatedAt { get; set; }
}

public sealed class MaintenanceChecklistItemDto
{
    public string Text { get; set; } = string.Empty;
    public bool IsChecked { get; set; }
}

public sealed class CreateMaintenancePlanRequest
{
    public Guid EquipmentId { get; set; }
    public Guid ResponsibleUserId { get; set; }
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Priority { get; set; } = "Medium";
    public string? Description { get; set; }
}

public sealed class UpdateMaintenancePlanRequest
{
    public Guid EquipmentId { get; set; }
    public Guid ResponsibleUserId { get; set; }
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Priority { get; set; } = "Medium";
    public string? Description { get; set; }
}

public sealed class StartMaintenancePlanRequest
{
    public string? Note { get; set; }
}

public sealed class CompleteMaintenancePlanRequest
{
    public DateTime? CompletedAt { get; set; }
    public string ResultStatus { get; set; } = "Completed";
    public string Description { get; set; } = string.Empty;
    public string? UsedMaterials { get; set; }
    public IReadOnlyList<MaintenanceChecklistItemDto> ChecklistItems { get; set; } = new List<MaintenanceChecklistItemDto>();
}
