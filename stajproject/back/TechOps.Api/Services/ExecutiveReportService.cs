using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TechOps.Api.Models;

namespace TechOps.Api.Services;

public interface IExecutiveReportService
{
    byte[] BuildExcel(ExecutiveReportDocument report);
    byte[] BuildPdf(ExecutiveReportDocument report);
}

public sealed class ExecutiveReportService : IExecutiveReportService
{
    public byte[] BuildExcel(ExecutiveReportDocument report)
    {
        using var workbook = new XLWorkbook();
        var summary = workbook.Worksheets.Add("Yonetici Ozeti");

        summary.Cell(1, 1).Value = "TechOps O&M Yönetici Raporu";
        summary.Range(1, 1, 1, 6).Merge().Style
            .Font.SetBold()
            .Font.SetFontSize(22)
            .Font.SetFontColor(XLColor.White)
            .Fill.SetBackgroundColor(XLColor.FromHtml("#111827"));

        summary.Cell(2, 1).Value = report.Title;
        summary.Range(2, 1, 2, 6).Merge().Style.Font.SetBold().Font.SetFontSize(16);
        summary.Cell(3, 1).Value = report.Subtitle;
        summary.Range(3, 1, 3, 6).Merge().Style.Font.SetFontColor(XLColor.FromHtml("#4B5563"));

        summary.Cell(5, 1).Value = "Modül";
        summary.Cell(5, 2).Value = report.ModuleName;
        summary.Cell(6, 1).Value = "Hazırlanan";
        summary.Cell(6, 2).Value = report.PreparedFor;
        summary.Cell(7, 1).Value = "Oluşturma";
        summary.Cell(7, 2).Value = FormatDateTime(report.GeneratedAt);
        summary.Range(5, 1, 7, 1).Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#E5E7EB"));

        var metricRow = 10;
        summary.Cell(metricRow, 1).Value = "KPI";
        summary.Range(metricRow, 1, metricRow, 6).Merge().Style.Font.SetBold().Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromHtml("#1D4ED8"));
        metricRow++;
        for (var i = 0; i < report.Metrics.Count; i++)
        {
            var metric = report.Metrics[i];
            var column = (i % 3) * 2 + 1;
            var row = metricRow + (i / 3) * 3;
            summary.Cell(row, column).Value = metric.Label;
            summary.Cell(row + 1, column).Value = metric.Value;
            summary.Cell(row + 2, column).Value = metric.Note;
            summary.Range(row, column, row + 2, column + 1).Merge(false).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            summary.Range(row, column, row, column + 1).Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#DBEAFE"));
            summary.Range(row + 1, column, row + 1, column + 1).Style.Font.SetBold().Font.SetFontSize(18);
            summary.Range(row + 2, column, row + 2, column + 1).Style.Font.SetFontColor(XLColor.FromHtml("#4B5563"));
        }

        var filterRow = metricRow + Math.Max(1, (int)Math.Ceiling(report.Metrics.Count / 3m)) * 3 + 2;
        summary.Cell(filterRow, 1).Value = "Filtre Özeti";
        summary.Range(filterRow, 1, filterRow, 6).Merge().Style.Font.SetBold().Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromHtml("#374151"));
        filterRow++;
        foreach (var filter in report.Filters)
        {
            summary.Cell(filterRow, 1).Value = filter.Label;
            summary.Cell(filterRow, 2).Value = filter.Value;
            summary.Range(filterRow, 1, filterRow, 1).Style.Font.SetBold();
            filterRow++;
        }

        summary.Cell(filterRow + 2, 1).Value = "Hazırlayan";
        summary.Cell(filterRow + 2, 3).Value = "Kontrol Eden";
        summary.Cell(filterRow + 2, 5).Value = "Onaylayan";
        summary.Range(filterRow + 3, 1, filterRow + 6, 2).Merge().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        summary.Range(filterRow + 3, 3, filterRow + 6, 4).Merge().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        summary.Range(filterRow + 3, 5, filterRow + 6, 6).Merge().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

        summary.Columns().AdjustToContents();
        summary.SheetView.FreezeRows(3);

        foreach (var section in report.Sections)
        {
            AddSectionWorksheet(workbook, section);
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public byte[] BuildPdf(ExecutiveReportDocument report)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(28);
                page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(9));

                page.Header().Element(header => BuildPdfHeader(header, report));
                page.Content().Element(content => BuildPdfContent(content, report));
                page.Footer().AlignRight().Text(text =>
                {
                    text.Span("Sayfa ");
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        });

        return document.GeneratePdf();
    }

    private static void AddSectionWorksheet(XLWorkbook workbook, ExecutiveReportSection section)
    {
        var sheetName = NormalizeSheetName(section.Title);
        var worksheet = workbook.Worksheets.Add(sheetName);
        worksheet.Cell(1, 1).Value = section.Title;
        worksheet.Range(1, 1, 1, Math.Max(1, section.Headers.Count)).Merge().Style
            .Font.SetBold()
            .Font.SetFontSize(16)
            .Font.SetFontColor(XLColor.White)
            .Fill.SetBackgroundColor(XLColor.FromHtml("#111827"));

        worksheet.Cell(2, 1).Value = section.Description;
        worksheet.Range(2, 1, 2, Math.Max(1, section.Headers.Count)).Merge().Style.Font.SetFontColor(XLColor.FromHtml("#4B5563"));

        for (var i = 0; i < section.Headers.Count; i++)
        {
            worksheet.Cell(4, i + 1).Value = section.Headers[i];
        }

        if (section.Headers.Count > 0)
        {
            worksheet.Range(4, 1, 4, section.Headers.Count).Style.Font.SetBold().Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromHtml("#1D4ED8"));
        }

        for (var rowIndex = 0; rowIndex < section.Rows.Count; rowIndex++)
        {
            var row = section.Rows[rowIndex];
            for (var columnIndex = 0; columnIndex < section.Headers.Count; columnIndex++)
            {
                worksheet.Cell(rowIndex + 5, columnIndex + 1).Value = columnIndex < row.Count ? row[columnIndex] : string.Empty;
            }
        }

        if (section.Rows.Count > 0 && section.Headers.Count > 0)
        {
            var range = worksheet.Range(4, 1, section.Rows.Count + 4, section.Headers.Count);
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            worksheet.Range(5, 1, section.Rows.Count + 4, section.Headers.Count).SetAutoFilter();
        }

        worksheet.Columns().AdjustToContents();
        worksheet.SheetView.FreezeRows(4);
    }

    private static void BuildPdfHeader(IContainer container, ExecutiveReportDocument report)
    {
        container.Column(column =>
        {
            column.Item().Background("#111827").Padding(12).Row(row =>
            {
                row.RelativeItem().Column(header =>
                {
                    header.Item().Text("TechOps O&M Yönetici Raporu").FontColor(Colors.White).Bold().FontSize(18);
                    header.Item().Text(report.Title).FontColor("#DBEAFE").FontSize(12);
                });
                row.ConstantItem(180).AlignRight().Text(FormatDateTime(report.GeneratedAt)).FontColor(Colors.White).FontSize(9);
            });
            column.Item().PaddingTop(6).Text(report.Subtitle).FontColor("#4B5563");
        });
    }

    private static void BuildPdfContent(IContainer container, ExecutiveReportDocument report)
    {
        container.PaddingTop(10).Column(column =>
        {
            column.Item().Row(row =>
            {
                foreach (var metric in report.Metrics.Take(6))
                {
                    row.RelativeItem().Border(1).BorderColor("#D1D5DB").Padding(7).Column(metricColumn =>
                    {
                        metricColumn.Item().Text(metric.Label).FontColor("#4B5563").FontSize(8);
                        metricColumn.Item().Text(metric.Value).Bold().FontSize(16).FontColor("#111827");
                        metricColumn.Item().Text(metric.Note).FontColor("#6B7280").FontSize(7);
                    });
                }
            });

            column.Item().PaddingTop(10).Text("Filtre Özeti").Bold().FontSize(11);
            column.Item().Border(1).BorderColor("#D1D5DB").Padding(7).Column(filters =>
            {
                foreach (var filter in report.Filters)
                {
                    filters.Item().Text($"{filter.Label}: {filter.Value}").FontSize(8);
                }
            });

            foreach (var section in report.Sections.Take(4))
            {
                column.Item().PaddingTop(10).Text(section.Title).Bold().FontSize(11);
                if (!string.IsNullOrWhiteSpace(section.Description))
                {
                    column.Item().Text(section.Description).FontColor("#4B5563").FontSize(8);
                }

                column.Item().Table(table =>
                {
                    var headers = section.Headers.Take(6).ToList();
                    table.ColumnsDefinition(columns =>
                    {
                        foreach (var _ in headers)
                        {
                            columns.RelativeColumn();
                        }
                    });

                    foreach (var header in headers)
                    {
                        table.Cell().Background("#1D4ED8").Padding(4).Text(header).FontColor(Colors.White).Bold().FontSize(7);
                    }

                    foreach (var row in section.Rows.Take(10))
                    {
                        for (var i = 0; i < headers.Count; i++)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor("#E5E7EB").Padding(4).Text(i < row.Count ? row[i] : string.Empty).FontSize(7);
                        }
                    }
                });
            }

            column.Item().PaddingTop(12).Row(row =>
            {
                row.RelativeItem().Border(1).BorderColor("#D1D5DB").Height(45).Padding(5).Text("Hazırlayan").FontSize(8);
                row.RelativeItem().Border(1).BorderColor("#D1D5DB").Height(45).Padding(5).Text("Kontrol Eden").FontSize(8);
                row.RelativeItem().Border(1).BorderColor("#D1D5DB").Height(45).Padding(5).Text("Onaylayan").FontSize(8);
            });
        });
    }

    private static string NormalizeSheetName(string value)
    {
        var invalidChars = Path.GetInvalidFileNameChars().Concat(['[', ']', '*', '?', '/', '\\']).ToHashSet();
        var normalized = new string(value.Select(ch => invalidChars.Contains(ch) ? '-' : ch).ToArray());
        return normalized.Length <= 31 ? normalized : normalized[..31];
    }

    private static string FormatDateTime(DateTime value) => value.ToLocalTime().ToString("dd.MM.yyyy HH:mm");
}
