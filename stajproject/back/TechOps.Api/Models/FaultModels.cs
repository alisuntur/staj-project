namespace TechOps.Api.Models;

public sealed class FaultListItemDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
    public string CreatedByUserName { get; set; } = string.Empty;
    public Guid? AssignedToUserId { get; set; }
    public string? AssignedToUserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class FaultDetailDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ResolutionDescription { get; set; }
    public string? WaitingReason { get; set; }
    public Guid CreatedByUserId { get; set; }
    public string CreatedByUserName { get; set; } = string.Empty;
    public Guid? AssignedToUserId { get; set; }
    public string? AssignedToUserName { get; set; }
    public Guid? ResolvedByUserId { get; set; }
    public string? ResolvedByUserName { get; set; }
    public Guid? ClosedByUserId { get; set; }
    public string? ClosedByUserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? AssignedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public IReadOnlyList<FaultActionDto> Actions { get; set; } = new List<FaultActionDto>();
}

public sealed class FaultActionDto
{
    public Guid Id { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? OldStatus { get; set; }
    public string? NewStatus { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
}

public sealed class CreateFaultRequest
{
    public Guid EquipmentId { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public sealed class AssignFaultRequest
{
    public Guid AssignedToUserId { get; set; }
    public string? Note { get; set; }
}

public sealed class AddFaultActionRequest
{
    public string Note { get; set; } = string.Empty;
}

public sealed class UpdateFaultStatusRequest
{
    public string Status { get; set; } = string.Empty;
    public string? Note { get; set; }
    public string? WaitingReason { get; set; }
}

public sealed class ResolveFaultRequest
{
    public string ResolutionDescription { get; set; } = string.Empty;
}

public sealed class CloseFaultRequest
{
    public string? Note { get; set; }
}
