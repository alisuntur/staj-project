using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Models;
using TechOps.Api.Security;
using TechOps.Api.Services;

namespace TechOps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(
    AppDbContext dbContext,
    IPasswordService passwordService,
    ITokenService tokenService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.UsernameOrEmail) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Kullanıcı adı/e-posta ve şifre zorunludur." });
        }

        var lookup = request.UsernameOrEmail.Trim().ToLowerInvariant();
        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username.ToLower() == lookup || x.Email.ToLower() == lookup, cancellationToken);

        if (user is null || !passwordService.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Kullanıcı adı/e-posta veya şifre hatalı." });
        }

        if (!user.IsActive)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new { message = "Kullanıcı pasif durumda." });
        }

        user.LastLoginAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        var token = tokenService.CreateToken(user);

        return Ok(new LoginResponse
        {
            AccessToken = token.AccessToken,
            ExpiresAt = token.ExpiresAt,
            User = MapProfile(user)
        });
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

        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user is null)
        {
            return Unauthorized(new { message = "Kullanıcı bulunamadı." });
        }

        if (!user.IsActive)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new { message = "Kullanıcı pasif durumda." });
        }

        return Ok(MapProfile(user));
    }

    private static UserProfileDto MapProfile(User user) => new()
    {
        Id = user.Id,
        FullName = user.FullName,
        Username = user.Username,
        Email = user.Email,
        Role = user.Role.Name,
        Title = user.Title,
        Department = user.Department
    };
}
