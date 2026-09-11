using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TechOps.Api.Models;
using Xunit;

namespace TechOps.Api.IntegrationTests;

public sealed class AuthAndAuthorizationTests(TechOpsApiFactory factory) : IClassFixture<TechOpsApiFactory>
{
    [Fact]
    public async Task Login_ReturnsJwtAndAdminProfile()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest
        {
            UsernameOrEmail = "admin",
            Password = "Demo123!"
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
        Assert.NotNull(payload);
        Assert.False(string.IsNullOrWhiteSpace(payload.AccessToken));
        Assert.Equal("Admin", payload.User.Role);
        Assert.Equal("admin", payload.User.Username);
    }

    [Fact]
    public async Task AdminUsers_RequiresAuthenticatedAdminRole()
    {
        var anonymousClient = factory.CreateClient();
        var anonymousResponse = await anonymousClient.GetAsync("/api/admin/users");
        Assert.Equal(HttpStatusCode.Unauthorized, anonymousResponse.StatusCode);

        var reportClient = factory.CreateClient();
        var reportToken = await LoginAndGetTokenAsync(reportClient, "raporcu");
        reportClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", reportToken);

        var forbiddenResponse = await reportClient.GetAsync("/api/admin/users");
        Assert.Equal(HttpStatusCode.Forbidden, forbiddenResponse.StatusCode);
    }

    [Fact]
    public async Task ShiftAssignments_AreVisibleOnlyToAdminAndManagerRoles()
    {
        var technicianClient = factory.CreateClient();
        var technicianToken = await LoginAndGetTokenAsync(technicianClient, "teknik2");
        technicianClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", technicianToken);

        var forbiddenResponse = await technicianClient.GetAsync("/api/shifts/assignments");
        Assert.Equal(HttpStatusCode.Forbidden, forbiddenResponse.StatusCode);

        var adminClient = factory.CreateClient();
        var adminToken = await LoginAndGetTokenAsync(adminClient, "admin");
        adminClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

        var users = await adminClient.GetFromJsonAsync<IReadOnlyList<UserListItemDto>>("/api/shifts/users");
        var technician = users?.FirstOrDefault(x => x.Role == "Teknik Personel") ?? throw new InvalidOperationException("No technician user found.");

        var saveResponse = await adminClient.PostAsJsonAsync("/api/shifts/assignments", new SaveShiftAssignmentRequest
        {
            UserId = technician.Id,
            ShiftType = "Night",
            ShiftDate = new DateOnly(2026, 9, 12),
            Notes = "Gece vardiyası saha takip sorumlusu"
        });

        Assert.Equal(HttpStatusCode.OK, saveResponse.StatusCode);
        var saved = await saveResponse.Content.ReadFromJsonAsync<ShiftAssignmentDto>();
        Assert.NotNull(saved);
        Assert.Equal(technician.Id, saved.UserId);
        Assert.Equal("Night", saved.ShiftType);

        var assignments = await adminClient.GetFromJsonAsync<IReadOnlyList<ShiftAssignmentDto>>("/api/shifts/assignments?from=2026-09-12&to=2026-09-12");
        Assert.Contains(assignments ?? [], x => x.UserId == technician.Id && x.ShiftDate == new DateOnly(2026, 9, 12));
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
