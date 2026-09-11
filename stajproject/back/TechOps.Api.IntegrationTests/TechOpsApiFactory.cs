using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechOps.Api.Data;

namespace TechOps.Api.IntegrationTests;

public sealed class TechOpsApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureAppConfiguration((_, configuration) =>
        {
            configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TechOps:ApplyMigrationsOnStartup"] = "false",
                ["TechOps:SeedOperationalDataOnStartup"] = "false"
            });
        });

        builder.ConfigureServices(services =>
        {
            foreach (var descriptor in services.Where(IsAppDbContextRegistration).ToList())
            {
                services.Remove(descriptor);
            }

            services.AddSingleton<DbConnection>(_ =>
            {
                var connection = new SqliteConnection("Data Source=:memory:");
                connection.Open();
                return connection;
            });

            services.AddDbContext<AppDbContext>((provider, options) =>
                options.UseSqlite(provider.GetRequiredService<DbConnection>()));
        });
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = base.CreateHost(builder);

        using var scope = host.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        var seeder = scope.ServiceProvider.GetRequiredService<IOperationalDataSeeder>();
        seeder.SeedAsync(forceReset: true).GetAwaiter().GetResult();

        return host;
    }

    private static bool IsAppDbContextRegistration(ServiceDescriptor descriptor) =>
        descriptor.ServiceType == typeof(DbContextOptions<AppDbContext>) ||
        descriptor.ServiceType == typeof(IDbContextOptionsConfiguration<AppDbContext>);
}
