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
    private static readonly XLColor BrandDark = XLColor.FromHtml("#111827");
    private static readonly XLColor BrandBlue = XLColor.FromHtml("#3755C3");
    private static readonly XLColor BrandBlueSoft = XLColor.FromHtml("#DDE1FF");
    private static readonly XLColor BorderColor = XLColor.FromHtml("#D1D5DB");
    private static readonly XLColor TextMuted = XLColor.FromHtml("#4B5563");
    private static readonly XLColor SheetBackground = XLColor.FromHtml("#F8FAFC");
    private static readonly XLColor RowStripe = XLColor.FromHtml("#F3F4F6");

    public byte[] BuildExcel(ExecutiveReportDocument report)
    {
        using var workbook = new XLWorkbook();
        workbook.Properties.Title = report.Title;
        workbook.Properties.Subject = report.Subtitle;
        workbook.Properties.Author = "TechOps O&M";
        workbook.Properties.Company = "TechOps";

        var summary = workbook.Worksheets.Add("Yonetici Ozeti");
        summary.Style.Font.FontName = "Aptos";
        summary.Style.Font.FontSize = 10;
        summary.Style.Fill.BackgroundColor = SheetBackground;
        summary.TabColor = BrandBlue;

        summary.Columns(1, 6).Width = 18;
        summary.Row(1).Height = 30;
        summary.Row(2).Height = 28;

        summary.Cell(1, 1).Value = "TechOps O&M";
        summary.Cell(1, 5).Value = ModuleHeader(report.ModuleName);
        summary.Range(1, 1, 2, 6).Style.Fill.BackgroundColor = BrandDark;
        summary.Range(1, 1, 2, 6).Style.Font.FontColor = XLColor.White;
        summary.Range(1, 1, 2, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        summary.Range(1, 1, 1, 3).Merge().Style.Font.SetBold().Font.SetFontSize(18);
        summary.Range(1, 5, 1, 6).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        summary.Range(1, 5, 1, 6).Style.Font.SetBold().Font.SetFontSize(11);
        summary.Range(2, 1, 2, 6).Merge();
        summary.Cell(2, 1).Value = "Operasyon, bakım, test, vardiya ve varlık yönetimi çıktı özeti";
        summary.Cell(2, 1).Style.Font.FontColor = XLColor.FromHtml("#CBD5E1");

        summary.Cell(4, 1).Value = report.Title;
        summary.Range(4, 1, 4, 6).Merge().Style.Font.SetBold().Font.SetFontSize(20).Font.SetFontColor(BrandDark);
        summary.Cell(5, 1).Value = report.Subtitle;
        summary.Range(5, 1, 5, 6).Merge().Style.Font.SetFontColor(TextMuted);

        AddInfoBox(summary, 7, 1, "Modül", report.ModuleName);
        AddInfoBox(summary, 7, 3, "Hazırlanan", report.PreparedFor);
        AddInfoBox(summary, 7, 5, "Oluşturma", FormatDateTime(report.GeneratedAt));

        var metricRow = 12;
        AddSectionTitle(summary, metricRow, "KPI Özeti");
        metricRow += 2;
        for (var i = 0; i < report.Metrics.Count; i++)
        {
            var metric = report.Metrics[i];
            var column = (i % 3) * 2 + 1;
            var row = metricRow + (i / 3) * 4;
            summary.Cell(row, column).Value = metric.Label;
            summary.Cell(row + 1, column).Value = metric.Value;
            summary.Cell(row + 2, column).Value = metric.Note;
            var card = summary.Range(row, column, row + 2, column + 1);
            card.Merge(false);
            card.Style.Fill.BackgroundColor = XLColor.White;
            card.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            card.Style.Border.OutsideBorderColor = BorderColor;
            card.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            summary.Range(row, column, row, column + 1).Style.Font.SetBold().Font.SetFontColor(TextMuted).Font.SetFontSize(9);
            summary.Range(row + 1, column, row + 1, column + 1).Style.Font.SetBold().Font.SetFontSize(22).Font.SetFontColor(BrandDark);
            summary.Range(row + 2, column, row + 2, column + 1).Style.Font.SetFontColor(TextMuted).Font.SetFontSize(9);
        }

        var filterRow = metricRow + Math.Max(1, (int)Math.Ceiling(report.Metrics.Count / 3m)) * 4 + 1;
        AddSectionTitle(summary, filterRow, "Filtre ve Kapsam");
        filterRow += 2;
        summary.Cell(filterRow, 1).Value = "Filtre";
        summary.Cell(filterRow, 2).Value = "Değer";
        summary.Range(filterRow, 1, filterRow, 6).Style.Font.SetBold().Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(BrandBlue);
        filterRow++;
        foreach (var filter in report.Filters)
        {
            summary.Cell(filterRow, 1).Value = filter.Label;
            summary.Cell(filterRow, 2).Value = filter.Value;
            summary.Range(filterRow, 2, filterRow, 6).Merge();
            summary.Range(filterRow, 1, filterRow, 6).Style.Fill.BackgroundColor = filterRow % 2 == 0 ? RowStripe : XLColor.White;
            summary.Range(filterRow, 1, filterRow, 1).Style.Font.SetBold().Font.SetFontColor(BrandDark);
            summary.Range(filterRow, 1, filterRow, 6).Style.Border.BottomBorder = XLBorderStyleValues.Hair;
            summary.Range(filterRow, 1, filterRow, 6).Style.Border.BottomBorderColor = BorderColor;
            filterRow++;
        }

        var sectionRow = filterRow + 2;
        AddSectionTitle(summary, sectionRow, "Rapor Bölümleri");
        sectionRow += 2;
        summary.Cell(sectionRow, 1).Value = "Bölüm";
        summary.Cell(sectionRow, 4).Value = "Kayıt";
        summary.Cell(sectionRow, 5).Value = "Açıklama";
        summary.Range(sectionRow, 1, sectionRow, 6).Style.Font.SetBold().Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(BrandBlue);
        sectionRow++;
        foreach (var section in report.Sections)
        {
            summary.Cell(sectionRow, 1).Value = section.Title;
            summary.Range(sectionRow, 1, sectionRow, 3).Merge();
            summary.Cell(sectionRow, 4).Value = section.Rows.Count;
            summary.Cell(sectionRow, 5).Value = string.IsNullOrWhiteSpace(section.Description) ? "-" : section.Description;
            summary.Range(sectionRow, 5, sectionRow, 6).Merge();
            summary.Range(sectionRow, 1, sectionRow, 6).Style.Fill.BackgroundColor = sectionRow % 2 == 0 ? RowStripe : XLColor.White;
            summary.Range(sectionRow, 1, sectionRow, 6).Style.Border.BottomBorder = XLBorderStyleValues.Hair;
            summary.Range(sectionRow, 1, sectionRow, 6).Style.Border.BottomBorderColor = BorderColor;
            sectionRow++;
        }

        var signatureRow = sectionRow + 2;
        AddSignatureBlock(summary, signatureRow, 1, "Hazırlayan");
        AddSignatureBlock(summary, signatureRow, 3, "Kontrol Eden");
        AddSignatureBlock(summary, signatureRow, 5, "Onaylayan");

        summary.ColumnsUsed().Style.Alignment.WrapText = true;
        summary.RowsUsed().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        summary.SheetView.FreezeRows(3);
        ApplyPrintSettings(summary);

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
        worksheet.Style.Font.FontName = "Aptos";
        worksheet.Style.Font.FontSize = 10;
        worksheet.Style.Fill.BackgroundColor = SheetBackground;
        worksheet.TabColor = BrandDark;

        var lastColumn = Math.Max(1, section.Headers.Count);
        worksheet.Cell(1, 1).Value = section.Title;
        worksheet.Range(1, 1, 1, lastColumn).Merge().Style
            .Font.SetBold()
            .Font.SetFontSize(17)
            .Font.SetFontColor(XLColor.White)
            .Fill.SetBackgroundColor(BrandDark);
        worksheet.Row(1).Height = 28;

        worksheet.Cell(2, 1).Value = section.Description;
        worksheet.Range(2, 1, 2, lastColumn).Merge().Style.Font.SetFontColor(TextMuted);
        worksheet.Row(2).Height = 24;

        for (var i = 0; i < section.Headers.Count; i++)
        {
            worksheet.Cell(4, i + 1).Value = section.Headers[i];
        }

        if (section.Headers.Count > 0)
        {
            worksheet.Range(4, 1, 4, section.Headers.Count).Style
                .Font.SetBold()
                .Font.SetFontColor(XLColor.White)
                .Fill.SetBackgroundColor(BrandBlue)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Row(4).Height = 22;
        }

        for (var rowIndex = 0; rowIndex < section.Rows.Count; rowIndex++)
        {
            var row = section.Rows[rowIndex];
            for (var columnIndex = 0; columnIndex < section.Headers.Count; columnIndex++)
            {
                worksheet.Cell(rowIndex + 5, columnIndex + 1).Value = columnIndex < row.Count ? row[columnIndex] : string.Empty;
            }

            worksheet.Range(rowIndex + 5, 1, rowIndex + 5, lastColumn).Style.Fill.BackgroundColor = rowIndex % 2 == 0 ? XLColor.White : RowStripe;
        }

        if (section.Rows.Count > 0 && section.Headers.Count > 0)
        {
            var range = worksheet.Range(4, 1, section.Rows.Count + 4, section.Headers.Count);
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.OutsideBorderColor = BorderColor;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            range.Style.Border.InsideBorderColor = BorderColor;
            range.SetAutoFilter();
        }
        else
        {
            worksheet.Cell(5, 1).Value = "Bu bölüm için kayıt bulunamadı.";
            worksheet.Range(5, 1, 5, lastColumn).Merge().Style.Font.SetFontColor(TextMuted).Fill.SetBackgroundColor(XLColor.White);
        }

        worksheet.Columns().AdjustToContents();
        foreach (var column in worksheet.ColumnsUsed())
        {
            if (column.Width < 14)
            {
                column.Width = 14;
            }

            if (column.Width > 42)
            {
                column.Width = 42;
            }
        }
        worksheet.RowsUsed().Style.Alignment.WrapText = true;
        worksheet.RowsUsed().Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
        worksheet.SheetView.FreezeRows(4);
        ApplyPrintSettings(worksheet);
    }

    private static void AddInfoBox(IXLWorksheet worksheet, int row, int column, string label, string value)
    {
        worksheet.Cell(row, column).Value = label;
        worksheet.Cell(row + 1, column).Value = value;
        var range = worksheet.Range(row, column, row + 1, column + 1);
        range.Merge(false);
        range.Style.Fill.BackgroundColor = XLColor.White;
        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        range.Style.Border.OutsideBorderColor = BorderColor;
        worksheet.Range(row, column, row, column + 1).Style.Font.SetBold().Font.SetFontColor(TextMuted).Font.SetFontSize(9);
        worksheet.Range(row + 1, column, row + 1, column + 1).Style.Font.SetBold().Font.SetFontColor(BrandDark).Font.SetFontSize(12);
    }

    private static void AddSectionTitle(IXLWorksheet worksheet, int row, string title)
    {
        worksheet.Cell(row, 1).Value = title;
        worksheet.Range(row, 1, row, 6).Merge().Style
            .Font.SetBold()
            .Font.SetFontColor(XLColor.White)
            .Fill.SetBackgroundColor(BrandBlue);
    }

    private static void AddSignatureBlock(IXLWorksheet worksheet, int row, int column, string title)
    {
        worksheet.Cell(row, column).Value = title;
        worksheet.Range(row, column, row, column + 1).Merge().Style.Font.SetBold().Font.SetFontColor(BrandDark);
        var signature = worksheet.Range(row + 1, column, row + 4, column + 1);
        signature.Merge();
        signature.Style.Fill.BackgroundColor = XLColor.White;
        signature.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        signature.Style.Border.OutsideBorderColor = BorderColor;
    }

    private static void ApplyPrintSettings(IXLWorksheet worksheet)
    {
        worksheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
        worksheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
        worksheet.PageSetup.FitToPages(1, 0);
        worksheet.PageSetup.Margins.Top = 0.35;
        worksheet.PageSetup.Margins.Bottom = 0.35;
        worksheet.PageSetup.Margins.Left = 0.25;
        worksheet.PageSetup.Margins.Right = 0.25;
        worksheet.PageSetup.Footer.Right.AddText("TechOps O&M");
        worksheet.PageSetup.Footer.Center.AddText("Sayfa &P / &N");
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
                        table.Cell().Background("#1D4ED8").Padding(4).Text(TruncateForPdf(header, 24)).FontColor(Colors.White).Bold().FontSize(7);
                    }

                    foreach (var row in section.Rows.Take(10))
                    {
                        for (var i = 0; i < headers.Count; i++)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor("#E5E7EB").Padding(4).Text(TruncateForPdf(i < row.Count ? row[i] : string.Empty, 80)).FontSize(7);
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

    private static string TruncateForPdf(string value, int maxLength)
    {
        var normalized = value.ReplaceLineEndings(" ").Trim();
        return normalized.Length <= maxLength ? normalized : normalized[..Math.Max(0, maxLength - 3)] + "...";
    }

    private static string FormatDateTime(DateTime value) => value.ToLocalTime().ToString("dd.MM.yyyy HH:mm");

    private static string ModuleHeader(string moduleName) => string.IsNullOrWhiteSpace(moduleName)
        ? "Yönetici Raporu"
        : $"{moduleName.Trim()} Raporu";
}
