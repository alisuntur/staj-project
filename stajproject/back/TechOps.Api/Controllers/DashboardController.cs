using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel,Operatör,Rapor Kullanıcısı")]
[Route("api/dashboard")]
public sealed class DashboardController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet("overview")]
    public async Task<IActionResult> GetOverview([FromQuery] string? period, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var today = DateOnly.FromDateTime(now);
        var monthStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var nextMonthStart = monthStart.AddMonths(1);
        var trendPeriod = NormalizeTrendPeriod(period);

        var faults = await dbContext.Faults
            .AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt)
            .ToListAsync(cancellationToken);

        var maintenancePlans = await dbContext.MaintenancePlans
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var testRecords = await dbContext.TestRecords
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var openShiftItems = await dbContext.ShiftItems
            .AsNoTracking()
            .Include(x => x.ShiftHandover)
            .Include(x => x.Equipment)
            .Include(x => x.Fault).ThenInclude(x => x!.Equipment)
            .Include(x => x.MaintenancePlan).ThenInclude(x => x!.Equipment)
            .Where(x => !x.IsCompleted)
            .OrderByDescending(x => x.Priority == FaultPriority.Critical)
            .ThenByDescending(x => x.Priority == FaultPriority.High)
            .ThenByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

        var faultedEquipmentCount = await dbContext.Equipment
            .AsNoTracking()
            .CountAsync(x => x.Status == EquipmentStatus.Faulted, cancellationToken);

        var openFaults = faults.Where(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed).ToList();
        var criticalFaults = faults.Where(x => x.Priority == FaultPriority.Critical).ToList();
        var openCriticalFaults = criticalFaults.Where(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed).ToList();
        var todayMaintenanceCount = maintenancePlans.Count(x => x.PlannedDate == today);
        var monthlyCompletedTestCount = testRecords.Count(x => x.TestDate >= monthStart && x.TestDate < nextMonthStart);
        var completedMaintenanceCount = maintenancePlans.Count(x => x.Status == MaintenanceStatus.Completed);
        var maintenanceRate = CalculateRate(completedMaintenanceCount, maintenancePlans.Count);
        var successfulTestCount = testRecords.Count(x => x.Result is TestResult.Success or TestResult.ConditionalSuccess);
        var testRate = CalculateRate(successfulTestCount, testRecords.Count);

        var overview = new DashboardOverviewDto
        {
            Kpis = new DashboardKpisDto
            {
                OpenFaultCount = openFaults.Count,
                CriticalFaultCount = criticalFaults.Count,
                TodayMaintenanceCount = todayMaintenanceCount,
                PendingWorkCount = openShiftItems.Count,
                MonthlyCompletedTestCount = monthlyCompletedTestCount,
                MaintenanceCompletionRate = maintenanceRate,
                TestSuccessRate = testRate,
                FaultedEquipmentCount = faultedEquipmentCount
            },
            TrendPeriod = trendPeriod,
            FaultStatusDistribution = faults
                .GroupBy(x => x.Status)
                .OrderByDescending(x => x.Count())
                .Select(x => new DashboardChartPointDto { Label = x.Key.ToString(), Value = x.Count() })
                .ToList(),
            FaultsByLocation = faults
                .GroupBy(x => x.Equipment.Location.Name)
                .OrderByDescending(x => x.Count())
                .Select(x => new DashboardChartPointDto { Label = x.Key, Value = x.Count() })
                .ToList(),
            MonthlyFaultTrend = BuildFaultTrend(faults, now, trendPeriod),
            MaintenanceCompletion = new DashboardRateDto
            {
                Completed = completedMaintenanceCount,
                Total = maintenancePlans.Count,
                Rate = maintenanceRate
            },
            TestSuccess = new DashboardRateDto
            {
                Completed = successfulTestCount,
                Total = testRecords.Count,
                Rate = testRate
            },
            CriticalFaults = openCriticalFaults
                .Take(5)
                .Select(MapRecentFault)
                .ToList(),
            RecentFaults = faults
                .Take(5)
                .Select(MapRecentFault)
                .ToList(),
            OpenShiftItems = openShiftItems
                .Take(6)
                .Select(MapOpenShiftItem)
                .ToList(),
            GeneratedAt = now
        };

        return Ok(overview);
    }

    private static DashboardRecentFaultDto MapRecentFault(Fault fault) => new()
    {
        Id = fault.Id,
        FaultNo = fault.FaultNo,
        EquipmentCode = fault.Equipment.Code,
        EquipmentName = fault.Equipment.Name,
        LocationName = fault.Equipment.Location.Name,
        Priority = fault.Priority.ToString(),
        Status = fault.Status.ToString(),
        CreatedAt = fault.CreatedAt,
        UpdatedAt = fault.UpdatedAt
    };

    private static DashboardOpenShiftItemDto MapOpenShiftItem(ShiftItem item)
    {
        var equipment = item.Equipment ?? item.Fault?.Equipment ?? item.MaintenancePlan?.Equipment;

        return new DashboardOpenShiftItemDto
        {
            Id = item.Id,
            HandoverNo = item.ShiftHandover.HandoverNo,
            ShiftType = item.ShiftHandover.ShiftType.ToString(),
            ShiftDate = item.ShiftHandover.ShiftDate,
            ItemType = item.ItemType.ToString(),
            Title = item.Title,
            Priority = item.Priority?.ToString(),
            EquipmentCode = equipment?.Code,
            EquipmentName = equipment?.Name,
            CreatedAt = item.CreatedAt
        };
    }

    private static decimal CalculateRate(int completed, int total)
    {
        return total == 0 ? 0 : Math.Round((decimal)completed * 100 / total, 1);
    }

    private static string NormalizeTrendPeriod(string? period)
    {
        return period?.Trim().ToLowerInvariant() switch
        {
            "week" => "week",
            "year" => "year",
            _ => "month"
        };
    }

    private static IReadOnlyList<DashboardTrendPointDto> BuildFaultTrend(IReadOnlyList<Fault> faults, DateTime now, string period)
    {
        if (period == "week")
        {
            var start = DateOnly.FromDateTime(now.Date.AddDays(-6));
            return Enumerable.Range(0, 7)
                .Select(offset => start.AddDays(offset))
                .Select(day => new DashboardTrendPointDto
                {
                    Label = day.ToString("dd MMM"),
                    Year = day.Year,
                    Month = day.Month,
                    Value = faults.Count(x => DateOnly.FromDateTime(x.CreatedAt) == day)
                })
                .ToList();
        }

        if (period == "year")
        {
            var startYear = now.Year - 4;
            return Enumerable.Range(0, 5)
                .Select(offset => startYear + offset)
                .Select(year => new DashboardTrendPointDto
                {
                    Label = year.ToString(),
                    Year = year,
                    Month = 0,
                    Value = faults.Count(x => x.CreatedAt.Year == year)
                })
                .ToList();
        }

        var trendStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-5);
        return Enumerable.Range(0, 6)
            .Select(offset => trendStart.AddMonths(offset))
            .Select(month => new DashboardTrendPointDto
            {
                Label = $"{month:MMM yyyy}",
                Year = month.Year,
                Month = month.Month,
                Value = faults.Count(x => x.CreatedAt.Year == month.Year && x.CreatedAt.Month == month.Month)
            })
            .ToList();
    }
}
