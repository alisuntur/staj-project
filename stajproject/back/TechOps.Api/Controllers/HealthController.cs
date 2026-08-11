using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;

namespace TechOps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class HealthController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var canConnect = await dbContext.Database.CanConnectAsync(cancellationToken);

        return Ok(new
        {
            status = canConnect ? "Healthy" : "DatabaseUnavailable",
            database = canConnect ? "Connected" : "NotConnected",
            checkedAt = DateTime.UtcNow
        });
    }
}
