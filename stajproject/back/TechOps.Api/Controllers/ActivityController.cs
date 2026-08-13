using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Rapor Kullanıcısı")]
[Route("api/activity")]
public sealed class ActivityController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet("logs")]
    public async Task<IActionResult> GetLogs(
        [FromQuery] string? entityName,
        [FromQuery] string? action,
        [FromQuery] DateOnly? from,
        [FromQuery] DateOnly? to,
        [FromQuery] int? take,
        CancellationToken cancellationToken)
    {
        if (from.HasValue && to.HasValue && from > to)
        {
            return BadRequest(new { message = "Başlangıç tarihi bitiş tarihinden büyük olamaz." });
        }

        var query = dbContext.AuditLogs
            .AsNoTracking()
            .Include(x => x.User).ThenInclude(x => x!.Role)
            .AsQueryable();

        var normalizedEntityName = NormalizeOptional(entityName);
        if (normalizedEntityName is not null)
        {
            query = query.Where(x => x.EntityName.ToLower() == normalizedEntityName);
        }

        var normalizedAction = NormalizeOptional(action);
        if (normalizedAction is not null)
        {
            query = query.Where(x => x.Action.ToLower() == normalizedAction);
        }

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

        var totalCount = await query.CountAsync(cancellationToken);
        var logs = await query
            .OrderByDescending(x => x.CreatedAt)
            .Take(NormalizeTake(take, 50, 100))
            .ToListAsync(cancellationToken);

        return Ok(new ActivityLogListResponseDto
        {
            TotalCount = totalCount,
            Items = logs.Select(MapLog).ToList(),
            GeneratedAt = DateTime.UtcNow
        });
    }

    private static ActivityLogListItemDto MapLog(AuditLog log) => new()
    {
        Id = log.Id,
        UserId = log.UserId,
        UserName = log.User?.FullName,
        UserRole = log.User?.Role.Name,
        EntityName = log.EntityName,
        EntityId = log.EntityId,
        Action = log.Action,
        OldValues = log.OldValues,
        NewValues = log.NewValues,
        IpAddress = log.IpAddress,
        UserAgent = log.UserAgent,
        CreatedAt = log.CreatedAt
    };

    private static string? NormalizeOptional(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim().ToLowerInvariant();
    }

    private static int NormalizeTake(int? take, int defaultValue, int maxValue)
    {
        return Math.Clamp(take ?? defaultValue, 1, maxValue);
    }
}
