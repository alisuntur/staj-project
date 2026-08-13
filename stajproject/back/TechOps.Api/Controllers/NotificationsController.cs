using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/notifications")]
public sealed class NotificationsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetNotifications(
        [FromQuery] bool? isRead,
        [FromQuery] string? type,
        [FromQuery] int? take,
        CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var parsedType = ParseEnum<NotificationType>(type);
        if (!string.IsNullOrWhiteSpace(type) && parsedType is null)
        {
            return BadRequest(new { message = "Bildirim tipi geçersiz." });
        }

        var userNotifications = dbContext.Notifications
            .AsNoTracking()
            .Where(x => x.UserId == userId);

        var query = userNotifications;

        if (isRead.HasValue)
        {
            query = query.Where(x => x.IsRead == isRead.Value);
        }

        if (parsedType.HasValue)
        {
            query = query.Where(x => x.Type == parsedType.Value);
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var unreadCount = await userNotifications.CountAsync(x => !x.IsRead, cancellationToken);
        var items = await query
            .OrderBy(x => x.IsRead)
            .ThenByDescending(x => x.CreatedAt)
            .Take(NormalizeTake(take, 50, 100))
            .Select(x => MapNotification(x))
            .ToListAsync(cancellationToken);

        return Ok(new NotificationListResponseDto
        {
            TotalCount = totalCount,
            UnreadCount = unreadCount,
            Items = items,
            GeneratedAt = DateTime.UtcNow
        });
    }

    [HttpGet("unread-count")]
    public async Task<IActionResult> GetUnreadCount(CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var unreadCount = await dbContext.Notifications
            .AsNoTracking()
            .CountAsync(x => x.UserId == userId && !x.IsRead, cancellationToken);

        return Ok(new NotificationUnreadCountDto { UnreadCount = unreadCount });
    }

    [HttpPatch("{id:guid}/read")]
    public async Task<IActionResult> MarkAsRead(Guid id, CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var notification = await dbContext.Notifications
            .SingleOrDefaultAsync(x => x.Id == id && x.UserId == userId, cancellationToken);

        if (notification is null)
        {
            return NotFound(new { message = "Bildirim bulunamadı." });
        }

        if (!notification.IsRead)
        {
            notification.IsRead = true;
            notification.UpdatedAt = DateTime.UtcNow;
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        var unreadCount = await dbContext.Notifications
            .AsNoTracking()
            .CountAsync(x => x.UserId == userId && !x.IsRead, cancellationToken);

        return Ok(new NotificationReadResultDto
        {
            Id = notification.Id,
            IsRead = notification.IsRead,
            UpdatedAt = notification.UpdatedAt,
            UnreadCount = unreadCount
        });
    }

    [HttpPatch("read-all")]
    public async Task<IActionResult> MarkAllAsRead(CancellationToken cancellationToken)
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var now = DateTime.UtcNow;
        var unreadNotifications = await dbContext.Notifications
            .Where(x => x.UserId == userId && !x.IsRead)
            .ToListAsync(cancellationToken);

        foreach (var notification in unreadNotifications)
        {
            notification.IsRead = true;
            notification.UpdatedAt = now;
        }

        if (unreadNotifications.Count > 0)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        return Ok(new NotificationReadAllResultDto
        {
            UpdatedCount = unreadNotifications.Count,
            UnreadCount = 0,
            UpdatedAt = now
        });
    }

    private bool TryGetCurrentUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(userIdClaim, out userId);
    }

    private static NotificationListItemDto MapNotification(Notification notification) => new()
    {
        Id = notification.Id,
        Title = notification.Title,
        Message = notification.Message,
        Type = notification.Type.ToString(),
        RelatedEntityName = notification.RelatedEntityName,
        RelatedEntityId = notification.RelatedEntityId,
        IsRead = notification.IsRead,
        CreatedAt = notification.CreatedAt,
        UpdatedAt = notification.UpdatedAt
    };

    private static TEnum? ParseEnum<TEnum>(string? value) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return Enum.TryParse<TEnum>(value.Trim(), true, out var parsed) && Enum.IsDefined(parsed) ? parsed : null;
    }

    private static int NormalizeTake(int? take, int defaultValue, int maxValue)
    {
        return Math.Clamp(take ?? defaultValue, 1, maxValue);
    }
}
