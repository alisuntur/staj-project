using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOps.Api.Models;
using TechOps.Api.Services;

namespace TechOps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(request, cancellationToken);
        return ToActionResult(result);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me(CancellationToken cancellationToken)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized(new { message = "Token kullanıcı bilgisi geçersiz." });
        }

        var result = await authService.GetProfileAsync(userId, cancellationToken);
        return ToActionResult(result);
    }

    private IActionResult ToActionResult<T>(AuthServiceResult<T> result)
    {
        if (result.Succeeded)
        {
            return Ok(result.Value);
        }

        return result.FailureReason switch
        {
            AuthFailureReason.MissingCredentials => BadRequest(new { message = result.Message }),
            AuthFailureReason.InvalidCredentials or AuthFailureReason.UserNotFound => Unauthorized(new { message = result.Message }),
            AuthFailureReason.InactiveUser => StatusCode(StatusCodes.Status403Forbidden, new { message = result.Message }),
            _ => StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kimlik doğrulama işlemi tamamlanamadı." })
        };
    }
}
