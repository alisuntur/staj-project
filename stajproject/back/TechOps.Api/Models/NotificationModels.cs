namespace TechOps.Api.Models;

public sealed class NotificationListResponseDto
{
    public int TotalCount { get; set; }
    public int UnreadCount { get; set; }
    public IReadOnlyList<NotificationListItemDto> Items { get; set; } = new List<NotificationListItemDto>();
    public DateTime GeneratedAt { get; set; }
}

public sealed class NotificationListItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? RelatedEntityName { get; set; }
    public Guid? RelatedEntityId { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public sealed class NotificationUnreadCountDto
{
    public int UnreadCount { get; set; }
}

public sealed class NotificationReadResultDto
{
    public Guid Id { get; set; }
    public bool IsRead { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int UnreadCount { get; set; }
}

public sealed class NotificationReadAllResultDto
{
    public int UpdatedCount { get; set; }
    public int UnreadCount { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public sealed class ActivityLogListResponseDto
{
    public int TotalCount { get; set; }
    public IReadOnlyList<ActivityLogListItemDto> Items { get; set; } = new List<ActivityLogListItemDto>();
    public DateTime GeneratedAt { get; set; }
}

public sealed class ActivityLogListItemDto
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserRole { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public Guid? EntityId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public DateTime CreatedAt { get; set; }
}
