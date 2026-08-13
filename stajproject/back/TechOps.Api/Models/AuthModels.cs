namespace TechOps.Api.Models;

public sealed class LoginRequest
{
    public string UsernameOrEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public sealed class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public UserProfileDto User { get; set; } = null!;
}

public sealed class UserProfileDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Department { get; set; }
}

public sealed class UserListItemDto
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Department { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLoginAt { get; set; }
}

public sealed class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsSystemRole { get; set; }
}

public sealed class CreateUserRequest
{
    public Guid RoleId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Department { get; set; }
}

public sealed class UpdateUserRequest
{
    public Guid RoleId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Department { get; set; }
}

public sealed class UpdateUserStatusRequest
{
    public bool IsActive { get; set; }
}

public sealed class UserWorkloadDto
{
    public UserListItemDto User { get; set; } = null!;
    public UserWorkloadSummaryDto Summary { get; set; } = null!;
    public IReadOnlyList<UserFaultTaskDto> OpenFaults { get; set; } = new List<UserFaultTaskDto>();
    public IReadOnlyList<UserMaintenanceTaskDto> OpenMaintenancePlans { get; set; } = new List<UserMaintenanceTaskDto>();
    public IReadOnlyList<UserTestTaskDto> OpenTestPlans { get; set; } = new List<UserTestTaskDto>();
    public IReadOnlyList<UserShiftTaskDto> ShiftHandovers { get; set; } = new List<UserShiftTaskDto>();
    public IReadOnlyList<UserFaultActionDto> FaultActions { get; set; } = new List<UserFaultActionDto>();
    public IReadOnlyList<UserCompletedWorkDto> CompletedWorks { get; set; } = new List<UserCompletedWorkDto>();
    public DateTime GeneratedAt { get; set; }
}

public sealed class UserWorkloadSummaryDto
{
    public int OpenFaultCount { get; set; }
    public int OpenMaintenanceCount { get; set; }
    public int OpenTestCount { get; set; }
    public int ShiftHandoverCount { get; set; }
    public int FaultActionCount { get; set; }
    public int CompletedWorkCount { get; set; }
}

public sealed class UserFaultTaskDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class UserMaintenanceTaskDto
{
    public Guid Id { get; set; }
    public string PlanNo { get; set; } = string.Empty;
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
}

public sealed class UserTestTaskDto
{
    public Guid Id { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string TestType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
}

public sealed class UserShiftTaskDto
{
    public Guid Id { get; set; }
    public string HandoverNo { get; set; } = string.Empty;
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public string Direction { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public DateTime CreatedAt { get; set; }
}

public sealed class UserFaultActionDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public string ActionType { get; set; } = string.Empty;
    public string? OldStatus { get; set; }
    public string? NewStatus { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
}

public sealed class UserCompletedWorkDto
{
    public Guid Id { get; set; }
    public string WorkType { get; set; } = string.Empty;
    public string ReferenceNo { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Result { get; set; }
    public DateTime CompletedAt { get; set; }
}
