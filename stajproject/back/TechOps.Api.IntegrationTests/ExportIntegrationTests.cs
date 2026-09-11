using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using ClosedXML.Excel;
using TechOps.Api.Models;
using Xunit;

namespace TechOps.Api.IntegrationTests;

public sealed class ExportIntegrationTests(TechOpsApiFactory factory) : IClassFixture<TechOpsApiFactory>
{
    [Fact]
    public async Task ExportEndpoints_ReturnModuleSpecificExcelFiles()
    {
        var client = factory.CreateClient();
        var token = await LoginAndGetTokenAsync(client, "admin");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var dashboard = await client.GetAsync("/api/exports/dashboard/xlsx?period=week");
        var faults = await client.GetAsync("/api/exports/faults/xlsx");
        var maintenance = await client.GetAsync("/api/exports/maintenance/xlsx");

        AssertExcelAttachment(dashboard, "dashboard-yonetici-raporu-week");
        AssertExcelAttachment(faults, "ariza-yonetici-raporu");
        AssertExcelAttachment(maintenance, "bakim-yonetici-raporu");
        AssertDashboardKpisAreVisible(await dashboard.Content.ReadAsByteArrayAsync());
        Assert.DoesNotContain("dashboard", ContentDispositionFileName(faults), StringComparison.OrdinalIgnoreCase);
        Assert.True((await faults.Content.ReadAsByteArrayAsync()).Length > 1_000);
    }

    private static void AssertDashboardKpisAreVisible(byte[] content)
    {
        using var stream = new MemoryStream(content);
        using var workbook = new XLWorkbook(stream);
        var worksheet = workbook.Worksheet("Yonetici Ozeti");

        AssertMetric(worksheet, 14, 1, "Açık Arıza");
        AssertMetric(worksheet, 14, 3, "Kritik Arıza");
        AssertMetric(worksheet, 14, 5, "Bekleyen İş");
        AssertMetric(worksheet, 18, 1, "Bakım Tamamlama");
        AssertMetric(worksheet, 18, 3, "Test Başarı");
        AssertMetric(worksheet, 18, 5, "Tamamlanan Test");
    }

    private static void AssertMetric(IXLWorksheet worksheet, int row, int column, string label)
    {
        Assert.Equal(label, worksheet.Cell(row, column).GetString());
        Assert.False(string.IsNullOrWhiteSpace(worksheet.Cell(row + 1, column).GetFormattedString()));
        Assert.False(string.IsNullOrWhiteSpace(worksheet.Cell(row + 2, column).GetString()));
    }

    private static void AssertExcelAttachment(HttpResponseMessage response, string expectedFilePrefix)
    {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", response.Content.Headers.ContentType?.MediaType);
        Assert.Contains(expectedFilePrefix, ContentDispositionFileName(response), StringComparison.OrdinalIgnoreCase);
    }

    private static string ContentDispositionFileName(HttpResponseMessage response)
    {
        var disposition = response.Content.Headers.ContentDisposition;
        return disposition?.FileNameStar ?? disposition?.FileName ?? string.Empty;
    }

    private static async Task<string> LoginAndGetTokenAsync(HttpClient client, string username)
    {
        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest
        {
            UsernameOrEmail = username,
            Password = "Demo123!"
        });

        response.EnsureSuccessStatusCode();
        var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
        return payload?.AccessToken ?? throw new InvalidOperationException("Login response did not include a token.");
    }
}
