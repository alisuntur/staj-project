namespace TechOps.Api.Models;

public sealed class ExecutiveReportDocument
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string ModuleName { get; set; } = string.Empty;
    public string PreparedFor { get; set; } = "Yönetici İncelemesi";
    public DateTime GeneratedAt { get; set; }
    public IReadOnlyList<ExecutiveReportMetric> Metrics { get; set; } = new List<ExecutiveReportMetric>();
    public IReadOnlyList<ExecutiveReportFilter> Filters { get; set; } = new List<ExecutiveReportFilter>();
    public IReadOnlyList<ExecutiveReportSection> Sections { get; set; } = new List<ExecutiveReportSection>();
}

public sealed class ExecutiveReportMetric
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public sealed class ExecutiveReportFilter
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public sealed class ExecutiveReportSection
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IReadOnlyList<string> Headers { get; set; } = new List<string>();
    public IReadOnlyList<IReadOnlyList<string>> Rows { get; set; } = new List<IReadOnlyList<string>>();
}
