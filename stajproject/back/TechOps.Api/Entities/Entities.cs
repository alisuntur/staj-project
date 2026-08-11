using TechOps.Api.Enums;

namespace TechOps.Api.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsSystemRole { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}

public sealed class User : BaseEntity
{
    public Guid RoleId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Department { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }

    public Role Role { get; set; } = null!;
    public ICollection<Fault> CreatedFaults { get; set; } = new List<Fault>();
    public ICollection<Fault> AssignedFaults { get; set; } = new List<Fault>();
    public ICollection<Fault> ResolvedFaults { get; set; } = new List<Fault>();
    public ICollection<Fault> ClosedFaults { get; set; } = new List<Fault>();
    public ICollection<FaultAction> FaultActions { get; set; } = new List<FaultAction>();
    public ICollection<MaintenancePlan> CreatedMaintenancePlans { get; set; } = new List<MaintenancePlan>();
    public ICollection<MaintenancePlan> ResponsibleMaintenancePlans { get; set; } = new List<MaintenancePlan>();
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    public ICollection<TestPlan> ResponsibleTestPlans { get; set; } = new List<TestPlan>();
    public ICollection<TestRecord> TestRecords { get; set; } = new List<TestRecord>();
    public ICollection<ShiftHandover> ShiftHandoversFrom { get; set; } = new List<ShiftHandover>();
    public ICollection<ShiftHandover> ShiftHandoversTo { get; set; } = new List<ShiftHandover>();
    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

public sealed class Location : BaseEntity
{
    public Guid? ParentLocationId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public Location? ParentLocation { get; set; }
    public ICollection<Location> ChildLocations { get; set; } = new List<Location>();
    public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    public ICollection<Fault> Faults { get; set; } = new List<Fault>();
}

public sealed class TechnicalSystem : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    public ICollection<Fault> Faults { get; set; } = new List<Fault>();
}

public sealed class Equipment : BaseEntity
{
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Active;
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public Location Location { get; set; } = null!;
    public TechnicalSystem TechnicalSystem { get; set; } = null!;
    public ICollection<Fault> Faults { get; set; } = new List<Fault>();
    public ICollection<MaintenancePlan> MaintenancePlans { get; set; } = new List<MaintenancePlan>();
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    public ICollection<TestPlan> TestPlans { get; set; } = new List<TestPlan>();
    public ICollection<TestRecord> TestRecords { get; set; } = new List<TestRecord>();
    public ICollection<ShiftItem> ShiftItems { get; set; } = new List<ShiftItem>();
}

public sealed class Fault : BaseEntity
{
    public string FaultNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public Guid? ResolvedByUserId { get; set; }
    public Guid? ClosedByUserId { get; set; }
    public FaultSource Source { get; set; }
    public FaultPriority Priority { get; set; }
    public FaultStatus Status { get; set; } = FaultStatus.New;
    public string Description { get; set; } = string.Empty;
    public string? ResolutionDescription { get; set; }
    public string? WaitingReason { get; set; }
    public DateTime? AssignedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public Equipment Equipment { get; set; } = null!;
    public Location Location { get; set; } = null!;
    public TechnicalSystem TechnicalSystem { get; set; } = null!;
    public User CreatedByUser { get; set; } = null!;
    public User? AssignedToUser { get; set; }
    public User? ResolvedByUser { get; set; }
    public User? ClosedByUser { get; set; }
    public ICollection<FaultAction> Actions { get; set; } = new List<FaultAction>();
    public ICollection<ShiftItem> ShiftItems { get; set; } = new List<ShiftItem>();
}

public sealed class FaultAction : BaseEntity
{
    public Guid FaultId { get; set; }
    public Guid UserId { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public FaultStatus? OldStatus { get; set; }
    public FaultStatus? NewStatus { get; set; }
    public string? Note { get; set; }
    public string? Metadata { get; set; }

    public Fault Fault { get; set; } = null!;
    public User User { get; set; } = null!;
}

public sealed class MaintenancePlan : BaseEntity
{
    public string PlanNo { get; set; } = string.Empty;
    public Guid EquipmentId { get; set; }
    public Guid ResponsibleUserId { get; set; }
    public Guid CreatedByUserId { get; set; }
    public string MaintenanceType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public FaultPriority Priority { get; set; } = FaultPriority.Medium;
    public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Planned;
    public string? Description { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public Equipment Equipment { get; set; } = null!;
    public User ResponsibleUser { get; set; } = null!;
    public User CreatedByUser { get; set; } = null!;
    public ICollection<MaintenanceRecord> Records { get; set; } = new List<MaintenanceRecord>();
    public ICollection<ShiftItem> ShiftItems { get; set; } = new List<ShiftItem>();
}

public sealed class MaintenanceRecord : BaseEntity
{
    public Guid? MaintenancePlanId { get; set; }
    public Guid EquipmentId { get; set; }
    public Guid PerformedByUserId { get; set; }
    public string MaintenanceType { get; set; } = string.Empty;
    public DateTime? StartedAt { get; set; }
    public DateTime CompletedAt { get; set; }
    public MaintenanceResultStatus ResultStatus { get; set; } = MaintenanceResultStatus.Completed;
    public string Description { get; set; } = string.Empty;
    public string? UsedMaterials { get; set; }
    public string? ChecklistJson { get; set; }

    public MaintenancePlan? MaintenancePlan { get; set; }
    public Equipment Equipment { get; set; } = null!;
    public User PerformedByUser { get; set; } = null!;
}

public sealed class TestPlan : BaseEntity
{
    public Guid EquipmentId { get; set; }
    public Guid ResponsibleUserId { get; set; }
    public string TestType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public TestPlanStatus Status { get; set; } = TestPlanStatus.Planned;
    public string? Description { get; set; }

    public Equipment Equipment { get; set; } = null!;
    public User ResponsibleUser { get; set; } = null!;
    public ICollection<TestRecord> Records { get; set; } = new List<TestRecord>();
}

public sealed class TestRecord : BaseEntity
{
    public Guid? TestPlanId { get; set; }
    public Guid EquipmentId { get; set; }
    public Guid TestedByUserId { get; set; }
    public DateTime TestDate { get; set; }
    public string TestType { get; set; } = string.Empty;
    public int? DurationMinutes { get; set; }
    public TestResult Result { get; set; } = TestResult.Success;
    public string? AbnormalCondition { get; set; }
    public string? Description { get; set; }

    public TestPlan? TestPlan { get; set; }
    public Equipment Equipment { get; set; } = null!;
    public User TestedByUser { get; set; } = null!;
}

public sealed class ShiftHandover : BaseEntity
{
    public string HandoverNo { get; set; } = string.Empty;
    public ShiftType ShiftType { get; set; }
    public DateOnly ShiftDate { get; set; }
    public Guid HandoverFromUserId { get; set; }
    public Guid HandoverToUserId { get; set; }
    public string? Summary { get; set; }
    public string? CriticalNotes { get; set; }

    public User HandoverFromUser { get; set; } = null!;
    public User HandoverToUser { get; set; } = null!;
    public ICollection<ShiftItem> Items { get; set; } = new List<ShiftItem>();
}

public sealed class ShiftItem : BaseEntity
{
    public Guid ShiftHandoverId { get; set; }
    public ShiftItemType ItemType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? FaultId { get; set; }
    public Guid? EquipmentId { get; set; }
    public Guid? MaintenancePlanId { get; set; }
    public FaultPriority? Priority { get; set; }
    public bool IsCompleted { get; set; }

    public ShiftHandover ShiftHandover { get; set; } = null!;
    public Fault? Fault { get; set; }
    public Equipment? Equipment { get; set; }
    public MaintenancePlan? MaintenancePlan { get; set; }
}

public sealed class AuditLog : BaseEntity
{
    public Guid? UserId { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public Guid? EntityId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }

    public User? User { get; set; }
}

public sealed class Notification : BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public string? RelatedEntityName { get; set; }
    public Guid? RelatedEntityId { get; set; }
    public bool IsRead { get; set; }

    public User User { get; set; } = null!;
}
