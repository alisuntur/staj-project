using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel")]
[Route("api/locations")]
public sealed class LocationsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLocations(CancellationToken cancellationToken)
    {
        var locations = await dbContext.Locations
            .Where(x => x.IsActive)
            .OrderBy(x => x.Code)
            .Select(x => MapLocation(x))
            .ToListAsync(cancellationToken);

        return Ok(locations);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLocation(Guid id, CancellationToken cancellationToken)
    {
        var location = await dbContext.Locations
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return location is null ? NotFound(new { message = "Lokasyon bulunamadı." }) : Ok(MapLocation(location));
    }

    private static LocationDto MapLocation(Location location) => new()
    {
        Id = location.Id,
        ParentLocationId = location.ParentLocationId,
        Code = location.Code,
        Name = location.Name,
        Type = location.Type,
        Description = location.Description,
        IsActive = location.IsActive
    };
}
