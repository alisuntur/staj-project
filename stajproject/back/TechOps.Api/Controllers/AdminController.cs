using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Models;
using TechOps.Api.Security;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/admin")]
public sealed class AdminController(AppDbContext dbContext, IPasswordService passwordService) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .Include(x => x.Role)
            .OrderBy(x => x.FullName)
            .Select(x => new UserListItemDto
            {
                Id = x.Id,
                RoleId = x.RoleId,
                FullName = x.FullName,
                Username = x.Username,
                Email = x.Email,
                Role = x.Role.Name,
                Title = x.Title,
                Department = x.Department,
                IsActive = x.IsActive,
                LastLoginAt = x.LastLoginAt
            })
            .ToListAsync(cancellationToken);

        return Ok(users);
    }

    [HttpGet("users/{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return user is null ? NotFound(new { message = "Kullanıcı bulunamadı." }) : Ok(MapUser(user));
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateUserRequest(request.RoleId, request.FullName, request.Username, request.Email, request.Password, null, cancellationToken);
        if (validationResult is not null)
        {
            return validationResult;
        }

        var role = await dbContext.Roles.SingleAsync(x => x.Id == request.RoleId, cancellationToken);
        var now = DateTime.UtcNow;
        var user = new User
        {
            Id = Guid.NewGuid(),
            RoleId = role.Id,
            FullName = request.FullName.Trim(),
            Username = request.Username.Trim(),
            Email = request.Email.Trim(),
            PasswordHash = passwordService.HashPassword(request.Password),
            Title = NormalizeOptional(request.Title),
            Department = NormalizeOptional(request.Department),
            IsActive = true,
            CreatedAt = now,
            Role = role
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, MapUser(user));
    }

    [HttpPut("users/{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (user is null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        var validationResult = await ValidateUserRequest(request.RoleId, request.FullName, request.Username, request.Email, null, id, cancellationToken);
        if (validationResult is not null)
        {
            return validationResult;
        }

        var role = await dbContext.Roles.SingleAsync(x => x.Id == request.RoleId, cancellationToken);
        user.RoleId = role.Id;
        user.FullName = request.FullName.Trim();
        user.Username = request.Username.Trim();
        user.Email = request.Email.Trim();
        user.Title = NormalizeOptional(request.Title);
        user.Department = NormalizeOptional(request.Department);
        user.UpdatedAt = DateTime.UtcNow;
        user.Role = role;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(MapUser(user));
    }

    [HttpPatch("users/{id:guid}/status")]
    public async Task<IActionResult> UpdateUserStatus(Guid id, UpdateUserStatusRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (user is null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        user.IsActive = request.IsActive;
        user.UpdatedAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(MapUser(user));
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
    {
        var roles = await dbContext.Roles
            .OrderBy(x => x.Name)
            .Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsSystemRole = x.IsSystemRole
            })
            .ToListAsync(cancellationToken);

        return Ok(roles);
    }

    private async Task<IActionResult?> ValidateUserRequest(
        Guid roleId,
        string fullName,
        string username,
        string email,
        string? password,
        Guid? currentUserId,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
        {
            return BadRequest(new { message = "Ad soyad, kullanıcı adı ve e-posta zorunludur." });
        }

        if (password is not null && password.Length < 8)
        {
            return BadRequest(new { message = "Şifre en az 8 karakter olmalıdır." });
        }

        var roleExists = await dbContext.Roles.AnyAsync(x => x.Id == roleId, cancellationToken);
        if (!roleExists)
        {
            return BadRequest(new { message = "Seçilen rol bulunamadı." });
        }

        var usernameLookup = username.Trim().ToLowerInvariant();
        var emailLookup = email.Trim().ToLowerInvariant();
        var duplicateExists = await dbContext.Users.AnyAsync(x =>
            (!currentUserId.HasValue || x.Id != currentUserId.Value) &&
            (x.Username.ToLower() == usernameLookup || x.Email.ToLower() == emailLookup), cancellationToken);

        return duplicateExists ? Conflict(new { message = "Kullanıcı adı veya e-posta zaten kullanılıyor." }) : null;
    }

    private static UserListItemDto MapUser(User user) => new()
    {
        Id = user.Id,
        RoleId = user.RoleId,
        FullName = user.FullName,
        Username = user.Username,
        Email = user.Email,
        Role = user.Role.Name,
        Title = user.Title,
        Department = user.Department,
        IsActive = user.IsActive,
        LastLoginAt = user.LastLoginAt
    };

    private static string? NormalizeOptional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
