using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel")]
[Route("api/technical-systems")]
public sealed class TechnicalSystemsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTechnicalSystems(CancellationToken cancellationToken)
    {
        var systems = await dbContext.TechnicalSystems
            .Where(x => x.IsActive)
            .OrderBy(x => x.Code)
            .Select(x => MapTechnicalSystem(x))
            .ToListAsync(cancellationToken);

        return Ok(systems);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTechnicalSystem(Guid id, CancellationToken cancellationToken)
    {
        var system = await dbContext.TechnicalSystems
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return system is null ? NotFound(new { message = "Teknik sistem bulunamadı." }) : Ok(MapTechnicalSystem(system));
    }

    private static TechnicalSystemDto MapTechnicalSystem(TechnicalSystem system) => new()
    {
        Id = system.Id,
        Code = system.Code,
        Name = system.Name,
        Description = system.Description,
        IsActive = system.IsActive
    };
}
