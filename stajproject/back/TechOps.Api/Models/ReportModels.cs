namespace TechOps.Api.Models;

public sealed class OperationsReportDto
{
    public OperationsReportFiltersDto Filters { get; set; } = null!;
    public OperationsReportSummaryDto Summary { get; set; } = null!;
    public IReadOnlyList<ReportChartPointDto> FaultsByEquipment { get; set; } = new List<ReportChartPointDto>();
    public IReadOnlyList<ReportChartPointDto> FaultsByLocation { get; set; } = new List<ReportChartPointDto>();
    public IReadOnlyList<RepeatedFaultDto> RepeatedFaults { get; set; } = new List<RepeatedFaultDto>();
    public IReadOnlyList<ReportFaultRowDto> FaultRows { get; set; } = new List<ReportFaultRowDto>();
    public IReadOnlyList<ReportMaintenanceRowDto> MaintenanceRows { get; set; } = new List<ReportMaintenanceRowDto>();
    public IReadOnlyList<ReportTestRowDto> TestRows { get; set; } = new List<ReportTestRowDto>();
    public DateTime GeneratedAt { get; set; }
}

public sealed class OperationsReportFiltersDto
{
    public DateOnly? From { get; set; }
    public DateOnly? To { get; set; }
    public Guid? LocationId { get; set; }
    public Guid? TechnicalSystemId { get; set; }
    public Guid? EquipmentId { get; set; }
    public string? Priority { get; set; }
    public string? Status { get; set; }
}

public sealed class OperationsReportSummaryDto
{
    public int FaultCount { get; set; }
    public int OpenFaultCount { get; set; }
    public int CriticalFaultCount { get; set; }
    public decimal AverageResolutionHours { get; set; }
    public int MaintenanceCount { get; set; }
    public decimal MaintenanceCompletionRate { get; set; }
    public int TestCount { get; set; }
    public decimal TestSuccessRate { get; set; }
    public int FaultedEquipmentCount { get; set; }
}

public sealed class ReportChartPointDto
{
    public string Id { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public int Value { get; set; }
}

public sealed class RepeatedFaultDto
{
    public Guid EquipmentId { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public int FaultCount { get; set; }
    public DateTime? LastFaultAt { get; set; }
}

public sealed class ReportFaultRowDto
{
    public Guid Id { get; set; }
    public string FaultNo { get; set; } = string.Empty;
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public decimal? ResolutionHours { get; set; }
}

public sealed class ReportMaintenanceRowDto
{
    public Guid Id { get; set; }
    public string PlanNo { get; set; } = string.Empty;
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateOnly PlannedDate { get; set; }
    public DateTime? CompletedAt { get; set; }
}

public sealed class ReportTestRowDto
{
    public Guid Id { get; set; }
    public string EquipmentCode { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string TestType { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public int? DurationMinutes { get; set; }
}
