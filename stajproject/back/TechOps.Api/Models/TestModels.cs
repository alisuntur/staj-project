namespace TechOps.Api.Models;

public sealed class TestPlanListItemDto
{
    public Guid Id { get; set; }
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public Guid ResponsibleUserId { get; set; }
    public string ResponsibleUserName { get; set; } = string.Empty;
    public string TestType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Status { get; set; } = string.Empty;
    public string DisplayStatus { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class TestPlanDetailDto
{
    public Guid Id { get; set; }
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
    public string TestType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string Status { get; set; } = string.Empty;
    public string DisplayStatus { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public IReadOnlyList<TestRecordListItemDto> Records { get; set; } = new List<TestRecordListItemDto>();
}

public sealed class TestRecordListItemDto
{
    public Guid Id { get; set; }
    public Guid? TestPlanId { get; set; }
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public Guid TestedByUserId { get; set; }
    public string TestedByUserName { get; set; } = string.Empty;
    public string? TestedByUserTitle { get; set; }
    public string TestType { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public int? DurationMinutes { get; set; }
    public string Result { get; set; } = string.Empty;
    public string? AbnormalCondition { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class TestRecordDetailDto
{
    public Guid Id { get; set; }
    public Guid? TestPlanId { get; set; }
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public Guid TestedByUserId { get; set; }
    public string TestedByUserName { get; set; } = string.Empty;
    public string? TestedByUserTitle { get; set; }
    public string? TestedByUserDepartment { get; set; }
    public string TestType { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public int? DurationMinutes { get; set; }
    public string Result { get; set; } = string.Empty;
    public string? AbnormalCondition { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public IReadOnlyList<TestRecordListItemDto> EquipmentRecentRecords { get; set; } = new List<TestRecordListItemDto>();
}

public sealed class CreateTestPlanRequest
{
    public Guid EquipmentId { get; set; }
    public Guid ResponsibleUserId { get; set; }
    public string TestType { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public string? Frequency { get; set; }
    public string? Description { get; set; }
}

public sealed class CreateTestRecordRequest
{
    public Guid? TestPlanId { get; set; }
    public Guid EquipmentId { get; set; }
    public Guid TestedByUserId { get; set; }
    public DateTime TestDate { get; set; }
    public string TestType { get; set; } = string.Empty;
    public int? DurationMinutes { get; set; }
    public string Result { get; set; } = "Success";
    public string? AbnormalCondition { get; set; }
    public string? Description { get; set; }
}
