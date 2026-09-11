using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Models;
using TechOps.Api.Security;

namespace TechOps.Api.Services;

public enum AuthFailureReason
{
    MissingCredentials,
    InvalidCredentials,
    InactiveUser,
    UserNotFound
}

public sealed record AuthServiceResult<T>(T? Value, AuthFailureReason? FailureReason, string? Message)
{
    public bool Succeeded => FailureReason is null;

    public static AuthServiceResult<T> Success(T value) => new(value, null, null);

    public static AuthServiceResult<T> Failure(AuthFailureReason reason, string message) => new(default, reason, message);
}

public interface IAuthService
{
    Task<AuthServiceResult<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<AuthServiceResult<UserProfileDto>> GetProfileAsync(Guid userId, CancellationToken cancellationToken);
}

public sealed class AuthService(
    AppDbContext dbContext,
    IPasswordService passwordService,
    ITokenService tokenService) : IAuthService
{
    public async Task<AuthServiceResult<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.UsernameOrEmail) || string.IsNullOrWhiteSpace(request.Password))
        {
            return AuthServiceResult<LoginResponse>.Failure(AuthFailureReason.MissingCredentials, "Kullanıcı adı/e-posta ve şifre zorunludur.");
        }

        var lookup = request.UsernameOrEmail.Trim().ToLowerInvariant();
        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username.ToLower() == lookup || x.Email.ToLower() == lookup, cancellationToken);

        if (user is null || !passwordService.VerifyPassword(request.Password, user.PasswordHash))
        {
            return AuthServiceResult<LoginResponse>.Failure(AuthFailureReason.InvalidCredentials, "Kullanıcı adı/e-posta veya şifre hatalı.");
        }

        if (!user.IsActive)
        {
            return AuthServiceResult<LoginResponse>.Failure(AuthFailureReason.InactiveUser, "Kullanıcı pasif durumda.");
        }

        user.LastLoginAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);

        var token = tokenService.CreateToken(user);
        return AuthServiceResult<LoginResponse>.Success(new LoginResponse
        {
            AccessToken = token.AccessToken,
            ExpiresAt = token.ExpiresAt,
            User = MapProfile(user)
        });
    }

    public async Task<AuthServiceResult<UserProfileDto>> GetProfileAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user is null)
        {
            return AuthServiceResult<UserProfileDto>.Failure(AuthFailureReason.UserNotFound, "Kullanıcı bulunamadı.");
        }

        if (!user.IsActive)
        {
            return AuthServiceResult<UserProfileDto>.Failure(AuthFailureReason.InactiveUser, "Kullanıcı pasif durumda.");
        }

        return AuthServiceResult<UserProfileDto>.Success(MapProfile(user));
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
