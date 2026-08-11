using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechOps.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class AuthTestController : ControllerBase
{
    [Authorize]
    [HttpGet("secure-test")]
    public IActionResult SecureTest()
    {
        return Ok(new
        {
            message = "Authenticated endpoint erişimi başarılı.",
            user = User.FindFirst(ClaimTypes.Name)?.Value,
            role = User.FindFirst(ClaimTypes.Role)?.Value
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-test")]
    public IActionResult AdminTest()
    {
        return Ok(new
        {
            message = "Admin endpoint erişimi başarılı.",
            user = User.FindFirst(ClaimTypes.Name)?.Value,
            role = User.FindFirst(ClaimTypes.Role)?.Value
        });
    }
}
