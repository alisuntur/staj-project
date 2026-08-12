namespace TechOps.Api.Models;

public sealed class DashboardOverviewDto
{
    public DashboardKpisDto Kpis { get; set; } = null!;
    public string TrendPeriod { get; set; } = string.Empty;
    public IReadOnlyList<DashboardChartPointDto> FaultStatusDistribution { get; set; } = new List<DashboardChartPointDto>();
    public IReadOnlyList<DashboardChartPointDto> FaultsByLocation { get; set; } = new List<DashboardChartPointDto>();
    public IReadOnlyList<DashboardTrendPointDto> MonthlyFaultTrend { get; set; } = new List<DashboardTrendPointDto>();
    public DashboardRateDto MaintenanceCompletion { get; set; } = null!;
    public DashboardRateDto TestSuccess { get; set; } = null!;
    public IReadOnlyList<DashboardRecentFaultDto> CriticalFaults { get; set; } = new List<DashboardRecentFaultDto>();
    public IReadOnlyList<DashboardRecentFaultDto> RecentFaults { get; set; } = new List<DashboardRecentFaultDto>();
    public IReadOnlyList<DashboardOpenShiftItemDto> OpenShiftItems { get; set; } = new List<DashboardOpenShiftItemDto>();
    public DateTime GeneratedAt { get; set; }
}

public sealed class DashboardKpisDto
{
    public int OpenFaultCount { get; set; }
    public int CriticalFaultCount { get; set; }
    public int TodayMaintenanceCount { get; set; }
    public int PendingWorkCount { get; set; }
    public int MonthlyCompletedTestCount { get; set; }
    public decimal MaintenanceCompletionRate { get; set; }
    public decimal TestSuccessRate { get; set; }
    public int FaultedEquipmentCount { get; set; }
}

public sealed class DashboardChartPointDto
{
    public string Label { get; set; } = string.Empty;
    public int Value { get; set; }
}

public sealed class DashboardTrendPointDto
{
    public string Label { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Month { get; set; }
    public int Value { get; set; }
}

public sealed class DashboardRateDto
{
    public int Completed { get; set; }
    public int Total { get; set; }
    public decimal Rate { get; set; }
}

public sealed class DashboardRecentFaultDto
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

public sealed class DashboardOpenShiftItemDto
{
    public Guid Id { get; set; }
    public string HandoverNo { get; set; } = string.Empty;
    public string ShiftType { get; set; } = string.Empty;
    public DateOnly ShiftDate { get; set; }
    public string ItemType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Priority { get; set; }
    public string? EquipmentCode { get; set; }
    public string? EquipmentName { get; set; }
    public DateTime CreatedAt { get; set; }
}
