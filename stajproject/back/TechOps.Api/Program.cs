using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuestPDF.Infrastructure;
using TechOps.Api.Data;
using TechOps.Api.Options;
using TechOps.Api.Security;
using TechOps.Api.Services;

var builder = WebApplication.CreateBuilder(args);
QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    var bearerScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Bearer token. Örnek: Bearer {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", bearerScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        [bearerScheme] = Array.Empty<string>()
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()
    ?? throw new InvalidOperationException("Jwt configuration is missing.");

if (Encoding.UTF8.GetByteCount(jwtOptions.Secret) < 32)
{
    throw new InvalidOperationException("Jwt:Secret must be at least 32 bytes for HMAC SHA-256.");
}

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IOperationalDataSeeder, OperationalDataSeeder>();
builder.Services.AddSingleton<IExecutiveReportService, ExecutiveReportService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

if (args.Any(arg => string.Equals(arg, "--reset-operational-data", StringComparison.OrdinalIgnoreCase)))
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<IOperationalDataSeeder>();
    await dbContext.Database.MigrateAsync();
    await seeder.SeedAsync(forceReset: true);
    await PrintSeedSummary(dbContext);
    return;
}

if (args.Any(arg => string.Equals(arg, "--seed-summary", StringComparison.OrdinalIgnoreCase)))
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await PrintSeedSummary(dbContext);
    return;
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Frontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Configuration.GetValue<bool>("TechOps:ApplyMigrationsOnStartup") || app.Configuration.GetValue<bool>("TechOps:SeedOperationalDataOnStartup"))
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

if (app.Configuration.GetValue<bool>("TechOps:SeedOperationalDataOnStartup"))
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IOperationalDataSeeder>();
    await seeder.SeedIfNeededAsync();
}

app.Run();

static async Task PrintSeedSummary(AppDbContext dbContext)
{
    var legacyTextCount = await dbContext.Equipment.CountAsync(x => x.Description != null && (x.Description.Contains("Sentetik") || x.Description.Contains("demo") || x.Description.Contains("Demo")))
        + await dbContext.Faults.CountAsync(x => x.Description.Contains("Sentetik") || x.Description.Contains("demo") || x.Description.Contains("Demo"))
        + await dbContext.MaintenancePlans.CountAsync(x => x.Description != null && (x.Description.Contains("Sentetik") || x.Description.Contains("demo") || x.Description.Contains("Demo")))
        + await dbContext.TestRecords.CountAsync(x => x.Description != null && (x.Description.Contains("Sentetik") || x.Description.Contains("demo") || x.Description.Contains("Demo")));
    var duplicateUserFullNameCount = await dbContext.Users
        .GroupBy(x => x.FullName)
        .Where(group => group.Count() > 1)
        .CountAsync();
    var today = DateOnly.FromDateTime(DateTime.UtcNow.Date);
    var recentFaultStart = DateTime.UtcNow.Date.AddDays(-21);

    Console.WriteLine("TechOps operational seed summary");
    Console.WriteLine($"Roles: {await dbContext.Roles.CountAsync()}");
    Console.WriteLine($"Users: {await dbContext.Users.CountAsync()}");
    Console.WriteLine($"Locations: {await dbContext.Locations.CountAsync()}");
    Console.WriteLine($"TechnicalSystems: {await dbContext.TechnicalSystems.CountAsync()}");
    Console.WriteLine($"Equipment: {await dbContext.Equipment.CountAsync()}");
    Console.WriteLine($"Faults: {await dbContext.Faults.CountAsync()}");
    Console.WriteLine($"FaultActions: {await dbContext.FaultActions.CountAsync()}");
    Console.WriteLine($"MaintenancePlans: {await dbContext.MaintenancePlans.CountAsync()}");
    Console.WriteLine($"MaintenanceRecords: {await dbContext.MaintenanceRecords.CountAsync()}");
    Console.WriteLine($"TestPlans: {await dbContext.TestPlans.CountAsync()}");
    Console.WriteLine($"TestRecords: {await dbContext.TestRecords.CountAsync()}");
    Console.WriteLine($"ShiftHandovers: {await dbContext.ShiftHandovers.CountAsync()}");
    Console.WriteLine($"ShiftItems: {await dbContext.ShiftItems.CountAsync()}");
    Console.WriteLine($"ShiftAssignments: {await dbContext.ShiftAssignments.CountAsync()}");
    Console.WriteLine($"AuditLogs: {await dbContext.AuditLogs.CountAsync()}");
    Console.WriteLine($"Notifications: {await dbContext.Notifications.CountAsync()}");
    Console.WriteLine($"LegacySyntheticOrDemoText: {legacyTextCount}");
    Console.WriteLine($"DuplicateUserFullNames: {duplicateUserFullNameCount}");
    Console.WriteLine($"TodayShiftHandovers: {await dbContext.ShiftHandovers.CountAsync(x => x.ShiftDate == today)}");
    Console.WriteLine($"TodayShiftAssignments: {await dbContext.ShiftAssignments.CountAsync(x => x.ShiftDate == today)}");
    Console.WriteLine($"OpenShiftItems: {await dbContext.ShiftItems.CountAsync(x => !x.IsCompleted)}");
    Console.WriteLine($"TodayMaintenancePlans: {await dbContext.MaintenancePlans.CountAsync(x => x.PlannedDate == today)}");
    Console.WriteLine($"RecentFaults21Days: {await dbContext.Faults.CountAsync(x => x.CreatedAt >= recentFaultStart)}");
}

public partial class Program;
