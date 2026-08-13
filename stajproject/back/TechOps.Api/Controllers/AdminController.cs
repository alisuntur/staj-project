using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
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

    [HttpGet("users/{id:guid}/workload")]
    public async Task<IActionResult> GetUserWorkload(Guid id, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (user is null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        var openFaults = await dbContext.Faults
            .AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Where(x => x.AssignedToUserId == id && x.Status != FaultStatus.Resolved && x.Status != FaultStatus.Closed)
            .OrderByDescending(x => x.Priority == FaultPriority.Critical)
            .ThenByDescending(x => x.Priority == FaultPriority.High)
            .ThenByDescending(x => x.UpdatedAt ?? x.CreatedAt)
            .Take(20)
            .Select(x => new UserFaultTaskDto
            {
                Id = x.Id,
                FaultNo = x.FaultNo,
                EquipmentCode = x.Equipment.Code,
                EquipmentName = x.Equipment.Name,
                LocationName = x.Equipment.Location.Name,
                Priority = x.Priority.ToString(),
                Status = x.Status.ToString(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .ToListAsync(cancellationToken);

        var openMaintenancePlans = await dbContext.MaintenancePlans
            .AsNoTracking()
            .Include(x => x.Equipment)
            .Where(x => x.ResponsibleUserId == id && x.Status != MaintenanceStatus.Completed && x.Status != MaintenanceStatus.Cancelled)
            .OrderBy(x => x.PlannedDate)
            .Take(20)
            .Select(x => new UserMaintenanceTaskDto
            {
                Id = x.Id,
                PlanNo = x.PlanNo,
                EquipmentCode = x.Equipment.Code,
                EquipmentName = x.Equipment.Name,
                MaintenanceType = x.MaintenanceType,
                Priority = x.Priority.ToString(),
                Status = x.Status.ToString(),
                PlannedDate = x.PlannedDate
            })
            .ToListAsync(cancellationToken);

        var openTestPlans = await dbContext.TestPlans
            .AsNoTracking()
            .Include(x => x.Equipment)
            .Where(x => x.ResponsibleUserId == id && x.Status != TestPlanStatus.Completed && x.Status != TestPlanStatus.Cancelled)
            .OrderBy(x => x.PlannedDate)
            .Take(20)
            .Select(x => new UserTestTaskDto
            {
                Id = x.Id,
                EquipmentCode = x.Equipment.Code,
                EquipmentName = x.Equipment.Name,
                TestType = x.TestType,
                Status = x.Status.ToString(),
                PlannedDate = x.PlannedDate
            })
            .ToListAsync(cancellationToken);

        var shiftHandovers = await dbContext.ShiftHandovers
            .AsNoTracking()
            .Where(x => x.HandoverFromUserId == id || x.HandoverToUserId == id)
            .OrderByDescending(x => x.ShiftDate)
            .ThenByDescending(x => x.CreatedAt)
            .Take(20)
            .Select(x => new UserShiftTaskDto
            {
                Id = x.Id,
                HandoverNo = x.HandoverNo,
                ShiftType = x.ShiftType.ToString(),
                ShiftDate = x.ShiftDate,
                Direction = x.HandoverFromUserId == id ? "Devreden" : "Devralan",
                Summary = x.Summary,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync(cancellationToken);

        var faultActions = await dbContext.FaultActions
            .AsNoTracking()
            .Include(x => x.Fault)
            .Where(x => x.UserId == id)
            .OrderByDescending(x => x.CreatedAt)
            .Take(20)
            .Select(x => new UserFaultActionDto
            {
                Id = x.Id,
                FaultNo = x.Fault.FaultNo,
                ActionType = x.ActionType,
                OldStatus = x.OldStatus.HasValue ? x.OldStatus.Value.ToString() : null,
                NewStatus = x.NewStatus.HasValue ? x.NewStatus.Value.ToString() : null,
                Note = x.Note,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync(cancellationToken);

        var resolvedFaults = await dbContext.Faults
            .AsNoTracking()
            .Where(x => x.ResolvedByUserId == id && x.ResolvedAt.HasValue)
            .OrderByDescending(x => x.ResolvedAt)
            .Take(15)
            .Select(x => new UserCompletedWorkDto
            {
                Id = x.Id,
                WorkType = "Arıza Çözümü",
                ReferenceNo = x.FaultNo,
                Title = x.Description,
                Result = x.Status.ToString(),
                CompletedAt = x.ResolvedAt!.Value
            })
            .ToListAsync(cancellationToken);

        var maintenanceRecords = await dbContext.MaintenanceRecords
            .AsNoTracking()
            .Include(x => x.MaintenancePlan)
            .Include(x => x.Equipment)
            .Where(x => x.PerformedByUserId == id)
            .OrderByDescending(x => x.CompletedAt)
            .Take(15)
            .Select(x => new UserCompletedWorkDto
            {
                Id = x.Id,
                WorkType = "Bakım Kaydı",
                ReferenceNo = x.MaintenancePlan != null ? x.MaintenancePlan.PlanNo : x.Equipment.Code,
                Title = x.MaintenanceType,
                Result = x.ResultStatus.ToString(),
                CompletedAt = x.CompletedAt
            })
            .ToListAsync(cancellationToken);

        var testRecords = await dbContext.TestRecords
            .AsNoTracking()
            .Include(x => x.Equipment)
            .Where(x => x.TestedByUserId == id)
            .OrderByDescending(x => x.TestDate)
            .Take(15)
            .Select(x => new UserCompletedWorkDto
            {
                Id = x.Id,
                WorkType = "Test Kaydı",
                ReferenceNo = x.Equipment.Code,
                Title = x.TestType,
                Result = x.Result.ToString(),
                CompletedAt = x.TestDate
            })
            .ToListAsync(cancellationToken);

        var completedWorks = resolvedFaults
            .Concat(maintenanceRecords)
            .Concat(testRecords)
            .OrderByDescending(x => x.CompletedAt)
            .Take(30)
            .ToList();

        return Ok(new UserWorkloadDto
        {
            User = MapUser(user),
            Summary = new UserWorkloadSummaryDto
            {
                OpenFaultCount = openFaults.Count,
                OpenMaintenanceCount = openMaintenancePlans.Count,
                OpenTestCount = openTestPlans.Count,
                ShiftHandoverCount = shiftHandovers.Count,
                FaultActionCount = faultActions.Count,
                CompletedWorkCount = completedWorks.Count
            },
            OpenFaults = openFaults,
            OpenMaintenancePlans = openMaintenancePlans,
            OpenTestPlans = openTestPlans,
            ShiftHandovers = shiftHandovers,
            FaultActions = faultActions,
            CompletedWorks = completedWorks,
            GeneratedAt = DateTime.UtcNow
        });
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
