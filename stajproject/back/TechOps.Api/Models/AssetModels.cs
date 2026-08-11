namespace TechOps.Api.Models;

public sealed class LocationDto
{
    public Guid Id { get; set; }
    public Guid? ParentLocationId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public sealed class TechnicalSystemDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public sealed class EquipmentListItemDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public Guid TechnicalSystemId { get; set; }
    public string TechnicalSystemName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public sealed class EquipmentDetailDto
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public LocationDto Location { get; set; } = null!;
    public TechnicalSystemDto TechnicalSystem { get; set; } = null!;
}

public sealed class CreateEquipmentRequest
{
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string Status { get; set; } = "Active";
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
}

public sealed class UpdateEquipmentRequest
{
    public Guid LocationId { get; set; }
    public Guid TechnicalSystemId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string Status { get; set; } = "Active";
    public DateOnly? CommissionedAt { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public sealed class UpdateEquipmentStatusRequest
{
    public string Status { get; set; } = "Active";
    public bool IsActive { get; set; } = true;
}
