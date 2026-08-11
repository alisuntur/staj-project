namespace TechOps.Api.Enums;

public enum FaultStatus
{
    New,
    Assigned,
    InReview,
    InProgress,
    Waiting,
    Resolved,
    Closed
}

public enum FaultPriority
{
    Low,
    Medium,
    High,
    Critical
}

public enum FaultSource
{
    ScadaObservation,
    HoneywellEbiObservation,
    FieldObservation,
    OperatorReport,
    MaintenanceFinding
}

public enum EquipmentStatus
{
    Active,
    Passive,
    Maintenance,
    Faulted
}

public enum MaintenanceStatus
{
    Planned,
    Started,
    Completed,
    Delayed,
    Cancelled
}

public enum MaintenanceResultStatus
{
    Completed,
    PartiallyCompleted,
    Failed
}

public enum TestPlanStatus
{
    Planned,
    Completed,
    Delayed,
    Cancelled
}

public enum TestResult
{
    Success,
    Failed,
    ConditionalSuccess,
    RetestRequired
}

public enum ShiftType
{
    Morning,
    Evening,
    Night
}

public enum ShiftItemType
{
    OpenFault,
    OngoingWork,
    EquipmentToWatch,
    PendingMaintenance,
    CriticalNote
}

public enum NotificationType
{
    Info,
    Warning,
    Critical
}
