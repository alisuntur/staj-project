using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel,Rapor Kullanıcısı")]
[Route("api/reports")]
public sealed class ReportsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet("operations")]
    public async Task<IActionResult> GetOperationsReport(
        [FromQuery] DateOnly? from,
        [FromQuery] DateOnly? to,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] Guid? equipmentId,
        [FromQuery] string? priority,
        [FromQuery] string? status,
        CancellationToken cancellationToken)
    {
        if (from.HasValue && to.HasValue && from > to)
        {
            return BadRequest(new { message = "Başlangıç tarihi bitiş tarihinden büyük olamaz." });
        }

        var parsedPriority = ParseEnum<FaultPriority>(priority);
        if (!string.IsNullOrWhiteSpace(priority) && parsedPriority is null)
        {
            return BadRequest(new { message = "Öncelik filtresi geçersiz." });
        }

        var parsedStatus = ParseEnum<FaultStatus>(status);
        if (!string.IsNullOrWhiteSpace(status) && parsedStatus is null)
        {
            return BadRequest(new { message = "Durum filtresi geçersiz." });
        }

        var faults = await BuildFaultQuery(from, to, locationId, technicalSystemId, equipmentId, parsedPriority, parsedStatus)
            .OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt)
            .ToListAsync(cancellationToken);

        var maintenancePlans = await BuildMaintenanceQuery(from, to, locationId, technicalSystemId, equipmentId, parsedPriority)
            .OrderByDescending(x => x.CompletedAt ?? x.CreatedAt)
            .ToListAsync(cancellationToken);

        var testRecords = await BuildTestQuery(from, to, locationId, technicalSystemId, equipmentId)
            .OrderByDescending(x => x.TestDate)
            .ToListAsync(cancellationToken);

        var faultedEquipmentCount = await dbContext.Equipment
            .AsNoTracking()
            .CountAsync(x => x.Status == EquipmentStatus.Faulted
                && (!locationId.HasValue || x.LocationId == locationId.Value)
                && (!technicalSystemId.HasValue || x.TechnicalSystemId == technicalSystemId.Value)
                && (!equipmentId.HasValue || x.Id == equipmentId.Value), cancellationToken);

        var completedMaintenanceCount = maintenancePlans.Count(x => x.Status == MaintenanceStatus.Completed);
        var successfulTestCount = testRecords.Count(x => x.Result is TestResult.Success or TestResult.ConditionalSuccess);

        var report = new OperationsReportDto
        {
            Filters = new OperationsReportFiltersDto
            {
                From = from,
                To = to,
                LocationId = locationId,
                TechnicalSystemId = technicalSystemId,
                EquipmentId = equipmentId,
                Priority = parsedPriority?.ToString(),
                Status = parsedStatus?.ToString()
            },
            Summary = new OperationsReportSummaryDto
            {
                FaultCount = faults.Count,
                OpenFaultCount = faults.Count(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed),
                CriticalFaultCount = faults.Count(x => x.Priority == FaultPriority.Critical),
                AverageResolutionHours = CalculateAverageResolutionHours(faults),
                MaintenanceCount = maintenancePlans.Count,
                MaintenanceCompletionRate = CalculateRate(completedMaintenanceCount, maintenancePlans.Count),
                TestCount = testRecords.Count,
                TestSuccessRate = CalculateRate(successfulTestCount, testRecords.Count),
                FaultedEquipmentCount = faultedEquipmentCount
            },
            FaultsByEquipment = faults
                .GroupBy(x => new { x.EquipmentId, x.Equipment.Code, x.Equipment.Name })
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key.Code)
                .Take(8)
                .Select(x => new ReportChartPointDto { Id = x.Key.EquipmentId.ToString(), Label = $"{x.Key.Code} - {x.Key.Name}", Value = x.Count() })
                .ToList(),
            FaultsByLocation = faults
                .GroupBy(x => new { x.LocationId, x.Location.Name })
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key.Name)
                .Select(x => new ReportChartPointDto { Id = x.Key.LocationId.ToString(), Label = x.Key.Name, Value = x.Count() })
                .ToList(),
            RepeatedFaults = faults
                .GroupBy(x => new { x.EquipmentId, x.Equipment.Code, x.Equipment.Name, LocationName = x.Location.Name, TechnicalSystemName = x.TechnicalSystem.Name })
                .Where(x => x.Count() > 1)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key.Code)
                .Take(10)
                .Select(x => new RepeatedFaultDto
                {
                    EquipmentId = x.Key.EquipmentId,
                    EquipmentCode = x.Key.Code,
                    EquipmentName = x.Key.Name,
                    LocationName = x.Key.LocationName,
                    TechnicalSystemName = x.Key.TechnicalSystemName,
                    FaultCount = x.Count(),
                    LastFaultAt = x.Max(item => item.UpdatedAt ?? item.CreatedAt)
                })
                .ToList(),
            FaultRows = faults.Take(30).Select(MapFaultRow).ToList(),
            MaintenanceRows = maintenancePlans.Take(30).Select(MapMaintenanceRow).ToList(),
            TestRows = testRecords.Take(30).Select(MapTestRow).ToList(),
            GeneratedAt = DateTime.UtcNow
        };

        return Ok(report);
    }

    private IQueryable<Fault> BuildFaultQuery(
        DateOnly? from,
        DateOnly? to,
        Guid? locationId,
        Guid? technicalSystemId,
        Guid? equipmentId,
        FaultPriority? priority,
        FaultStatus? status)
    {
        var query = dbContext.Faults
            .AsNoTracking()
            .Include(x => x.Equipment)
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .AsQueryable();

        if (from.HasValue)
        {
            var start = from.Value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
            query = query.Where(x => x.CreatedAt >= start);
        }

        if (to.HasValue)
        {
            var end = to.Value.AddDays(1).ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
            query = query.Where(x => x.CreatedAt < end);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.TechnicalSystemId == technicalSystemId.Value);
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (priority.HasValue)
        {
            query = query.Where(x => x.Priority == priority.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(x => x.Status == status.Value);
        }

        return query;
    }

    private IQueryable<MaintenancePlan> BuildMaintenanceQuery(
        DateOnly? from,
        DateOnly? to,
        Guid? locationId,
        Guid? technicalSystemId,
        Guid? equipmentId,
        FaultPriority? priority)
    {
        var query = dbContext.MaintenancePlans
            .AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
            .AsQueryable();

        if (from.HasValue)
        {
            query = query.Where(x => x.PlannedDate >= from.Value);
        }

        if (to.HasValue)
        {
            query = query.Where(x => x.PlannedDate <= to.Value);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.Equipment.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (priority.HasValue)
        {
            query = query.Where(x => x.Priority == priority.Value);
        }

        return query;
    }

    private IQueryable<TestRecord> BuildTestQuery(DateOnly? from, DateOnly? to, Guid? locationId, Guid? technicalSystemId, Guid? equipmentId)
    {
        var query = dbContext.TestRecords
            .AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
            .AsQueryable();

        if (from.HasValue)
        {
            var start = from.Value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
            query = query.Where(x => x.TestDate >= start);
        }

        if (to.HasValue)
        {
            var end = to.Value.AddDays(1).ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
            query = query.Where(x => x.TestDate < end);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.Equipment.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        return query;
    }

    private static TEnum? ParseEnum<TEnum>(string? value) where TEnum : struct
    {
        return string.IsNullOrWhiteSpace(value) ? null : Enum.TryParse<TEnum>(value.Trim(), true, out var result) ? result : null;
    }

    private static decimal CalculateRate(int completed, int total)
    {
        return total == 0 ? 0 : Math.Round((decimal)completed * 100 / total, 1);
    }

    private static decimal CalculateAverageResolutionHours(IEnumerable<Fault> faults)
    {
        var durations = faults
            .Select(x =>
            {
                var completedAt = x.ClosedAt ?? x.ResolvedAt;
                return completedAt.HasValue ? completedAt.Value - x.CreatedAt : (TimeSpan?)null;
            })
            .Where(x => x.HasValue)
            .Select(x => x!.Value.TotalHours)
            .ToList();

        return durations.Count == 0 ? 0 : Math.Round((decimal)durations.Average(), 1);
    }

    private static ReportFaultRowDto MapFaultRow(Fault fault)
    {
        var completedAt = fault.ClosedAt ?? fault.ResolvedAt;

        return new ReportFaultRowDto
        {
            Id = fault.Id,
            FaultNo = fault.FaultNo,
            EquipmentCode = fault.Equipment.Code,
            EquipmentName = fault.Equipment.Name,
            LocationName = fault.Location.Name,
            TechnicalSystemName = fault.TechnicalSystem.Name,
            Priority = fault.Priority.ToString(),
            Status = fault.Status.ToString(),
            CreatedAt = fault.CreatedAt,
            ResolvedAt = fault.ResolvedAt,
            ClosedAt = fault.ClosedAt,
            ResolutionHours = completedAt.HasValue ? Math.Round((decimal)(completedAt.Value - fault.CreatedAt).TotalHours, 1) : null
        };
    }

    private static ReportMaintenanceRowDto MapMaintenanceRow(MaintenancePlan plan) => new()
    {
        Id = plan.Id,
        PlanNo = plan.PlanNo,
        EquipmentCode = plan.Equipment.Code,
        EquipmentName = plan.Equipment.Name,
        LocationName = plan.Equipment.Location.Name,
        TechnicalSystemName = plan.Equipment.TechnicalSystem.Name,
        MaintenanceType = plan.MaintenanceType,
        Priority = plan.Priority.ToString(),
        Status = plan.Status.ToString(),
        PlannedDate = plan.PlannedDate,
        CompletedAt = plan.CompletedAt
    };

    private static ReportTestRowDto MapTestRow(TestRecord record) => new()
    {
        Id = record.Id,
        EquipmentCode = record.Equipment.Code,
        EquipmentName = record.Equipment.Name,
        LocationName = record.Equipment.Location.Name,
        TechnicalSystemName = record.Equipment.TechnicalSystem.Name,
        TestType = record.TestType,
        Result = record.Result.ToString(),
        TestDate = record.TestDate,
        DurationMinutes = record.DurationMinutes
    };
}
