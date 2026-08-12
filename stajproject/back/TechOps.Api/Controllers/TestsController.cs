using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin,Yönetici,Teknik Personel")]
[Route("api/tests")]
public sealed class TestsController(AppDbContext dbContext) : ControllerBase
{
    private static readonly string[] ResponsibleRoles = ["Admin", "Yönetici", "Teknik Personel"];

    [HttpGet("plans")]
    public async Task<IActionResult> GetPlans(
        [FromQuery] string? search,
        [FromQuery] string? status,
        [FromQuery] Guid? equipmentId,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] Guid? responsibleUserId,
        [FromQuery] string? testType,
        [FromQuery] DateOnly? plannedFrom,
        [FromQuery] DateOnly? plannedTo,
        CancellationToken cancellationToken)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var query = PlanQuery();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lookup = search.Trim().ToLowerInvariant();
            query = query.Where(x =>
                x.TestType.ToLower().Contains(lookup) ||
                (x.Description != null && x.Description.ToLower().Contains(lookup)) ||
                x.Equipment.Code.ToLower().Contains(lookup) ||
                x.Equipment.Name.ToLower().Contains(lookup));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (status.Trim().Equals("Delayed", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(x => x.Status != TestPlanStatus.Completed && x.PlannedDate < today);
            }
            else
            {
                if (!TryParsePlanStatus(status, out var parsedStatus))
                {
                    return BadRequest(new { message = "Geçersiz test planı durumu." });
                }

                query = query.Where(x => x.Status == parsedStatus);
            }
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.Equipment.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        }

        if (responsibleUserId.HasValue)
        {
            query = query.Where(x => x.ResponsibleUserId == responsibleUserId.Value);
        }

        if (!string.IsNullOrWhiteSpace(testType))
        {
            var typeLookup = testType.Trim().ToLowerInvariant();
            query = query.Where(x => x.TestType.ToLower().Contains(typeLookup));
        }

        if (plannedFrom.HasValue)
        {
            query = query.Where(x => x.PlannedDate >= plannedFrom.Value);
        }

        if (plannedTo.HasValue)
        {
            query = query.Where(x => x.PlannedDate <= plannedTo.Value);
        }

        var planEntities = await query
            .OrderBy(x => x.Status == TestPlanStatus.Completed)
            .ThenBy(x => x.PlannedDate)
            .ThenBy(x => x.TestType)
            .ToListAsync(cancellationToken);
        var plans = planEntities.Select(x => MapPlanListItem(x, today)).ToList();

        return Ok(plans);
    }

    [HttpGet("plans/{id:guid}")]
    public async Task<IActionResult> GetPlan(Guid id, CancellationToken cancellationToken)
    {
        var plan = await PlanDetailQuery().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return plan is null ? NotFound(new { message = "Test planı bulunamadı." }) : Ok(MapPlanDetail(plan));
    }

    [HttpPost("plans")]
    public async Task<IActionResult> CreatePlan(CreateTestPlanRequest request, CancellationToken cancellationToken)
    {
        var validation = await ValidatePlanRequest(request.EquipmentId, request.ResponsibleUserId, request.TestType, request.PlannedDate, cancellationToken);
        if (validation.Error is not null)
        {
            return validation.Error;
        }

        var now = DateTime.UtcNow;
        var plan = new TestPlan
        {
            Id = Guid.NewGuid(),
            EquipmentId = validation.Equipment!.Id,
            ResponsibleUserId = validation.ResponsibleUser!.Id,
            TestType = request.TestType.Trim(),
            PlannedDate = request.PlannedDate,
            Frequency = NormalizeOptional(request.Frequency),
            Status = TestPlanStatus.Planned,
            Description = NormalizeOptional(request.Description),
            CreatedAt = now
        };

        dbContext.TestPlans.Add(plan);
        await dbContext.SaveChangesAsync(cancellationToken);

        var created = await PlanDetailQuery().SingleAsync(x => x.Id == plan.Id, cancellationToken);
        return CreatedAtAction(nameof(GetPlan), new { id = created.Id }, MapPlanDetail(created));
    }

    [HttpGet("records")]
    public async Task<IActionResult> GetRecords(
        [FromQuery] string? search,
        [FromQuery] Guid? equipmentId,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] Guid? testedByUserId,
        [FromQuery] string? testType,
        [FromQuery] string? result,
        [FromQuery] DateOnly? testDate,
        [FromQuery] DateTime? testedFrom,
        [FromQuery] DateTime? testedTo,
        CancellationToken cancellationToken)
    {
        var query = RecordQuery();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lookup = search.Trim().ToLowerInvariant();
            query = query.Where(x =>
                x.TestType.ToLower().Contains(lookup) ||
                (x.Description != null && x.Description.ToLower().Contains(lookup)) ||
                (x.AbnormalCondition != null && x.AbnormalCondition.ToLower().Contains(lookup)) ||
                x.Equipment.Code.ToLower().Contains(lookup) ||
                x.Equipment.Name.ToLower().Contains(lookup) ||
                x.Equipment.Location.Name.ToLower().Contains(lookup) ||
                x.Equipment.TechnicalSystem.Name.ToLower().Contains(lookup) ||
                x.TestedByUser.FullName.ToLower().Contains(lookup));
        }

        if (equipmentId.HasValue)
        {
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        }

        if (locationId.HasValue)
        {
            query = query.Where(x => x.Equipment.LocationId == locationId.Value);
        }

        if (technicalSystemId.HasValue)
        {
            query = query.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        }

        if (testedByUserId.HasValue)
        {
            query = query.Where(x => x.TestedByUserId == testedByUserId.Value);
        }

        if (!string.IsNullOrWhiteSpace(testType))
        {
            var typeLookup = testType.Trim().ToLowerInvariant();
            query = query.Where(x => x.TestType.ToLower().Contains(typeLookup));
        }

        if (!string.IsNullOrWhiteSpace(result))
        {
            if (!TryParseResult(result, out var parsedResult))
            {
                return BadRequest(new { message = "Geçersiz test sonucu." });
            }

            query = query.Where(x => x.Result == parsedResult);
        }

        if (testDate.HasValue)
        {
            var from = testDate.Value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
            var to = from.AddDays(1);
            query = query.Where(x => x.TestDate >= from && x.TestDate < to);
        }

        if (testedFrom.HasValue)
        {
            var from = NormalizeDateTime(testedFrom.Value);
            query = query.Where(x => x.TestDate >= from);
        }

        if (testedTo.HasValue)
        {
            var to = NormalizeDateTime(testedTo.Value);
            query = query.Where(x => x.TestDate <= to);
        }

        var recordEntities = await query
            .OrderByDescending(x => x.TestDate)
            .ThenBy(x => x.Equipment.Code)
            .ToListAsync(cancellationToken);
        var records = recordEntities.Select(MapRecordListItem).ToList();

        return Ok(records);
    }

    [HttpGet("records/{id:guid}")]
    public async Task<IActionResult> GetRecord(Guid id, CancellationToken cancellationToken)
    {
        var record = await RecordQuery().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (record is null)
        {
            return NotFound(new { message = "Test kaydı bulunamadı." });
        }

        var recentRecords = await RecordQuery()
            .Where(x => x.EquipmentId == record.EquipmentId && x.Id != record.Id)
            .OrderByDescending(x => x.TestDate)
            .Take(5)
            .ToListAsync(cancellationToken);

        return Ok(MapRecordDetail(record, recentRecords));
    }

    [HttpPost("records")]
    public async Task<IActionResult> CreateRecord(CreateTestRecordRequest request, CancellationToken cancellationToken)
    {
        var validation = await ValidateRecordRequest(request, cancellationToken);
        if (validation.Error is not null)
        {
            return validation.Error;
        }

        var now = DateTime.UtcNow;
        var record = new TestRecord
        {
            Id = Guid.NewGuid(),
            TestPlanId = validation.Plan?.Id,
            EquipmentId = validation.Equipment!.Id,
            TestedByUserId = validation.TestedByUser!.Id,
            TestDate = validation.TestDate,
            TestType = validation.TestType,
            DurationMinutes = request.DurationMinutes,
            Result = validation.Result,
            AbnormalCondition = NormalizeOptional(request.AbnormalCondition),
            Description = NormalizeOptional(request.Description),
            CreatedAt = now
        };

        if (validation.Plan is not null && validation.Plan.Status != TestPlanStatus.Completed)
        {
            validation.Plan.Status = TestPlanStatus.Completed;
            validation.Plan.UpdatedAt = now;
        }

        dbContext.TestRecords.Add(record);
        await dbContext.SaveChangesAsync(cancellationToken);

        var created = await RecordQuery().SingleAsync(x => x.Id == record.Id, cancellationToken);
        var recentRecords = await RecordQuery()
            .Where(x => x.EquipmentId == created.EquipmentId && x.Id != created.Id)
            .OrderByDescending(x => x.TestDate)
            .Take(5)
            .ToListAsync(cancellationToken);

        return CreatedAtAction(nameof(GetRecord), new { id = created.Id }, MapRecordDetail(created, recentRecords));
    }

    [HttpGet("equipment/{equipmentId:guid}/records")]
    public async Task<IActionResult> GetEquipmentRecords(Guid equipmentId, CancellationToken cancellationToken)
    {
        var equipmentExists = await dbContext.Equipment.AnyAsync(x => x.Id == equipmentId, cancellationToken);
        if (!equipmentExists)
        {
            return NotFound(new { message = "Ekipman bulunamadı." });
        }

        var records = await RecordQuery()
            .Where(x => x.EquipmentId == equipmentId)
            .OrderByDescending(x => x.TestDate)
            .ToListAsync(cancellationToken);

        return Ok(records.Select(MapRecordListItem).ToList());
    }

    [HttpGet("responsible-users")]
    public async Task<IActionResult> GetResponsibleUsers(CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .Include(x => x.Role)
            .Where(x => x.IsActive && ResponsibleRoles.Contains(x.Role.Name))
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

    private IQueryable<TestPlan> PlanQuery() => dbContext.TestPlans
        .Include(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
        .Include(x => x.ResponsibleUser);

    private IQueryable<TestPlan> PlanDetailQuery() => dbContext.TestPlans
        .Include(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
        .Include(x => x.ResponsibleUser)
        .Include(x => x.Records).ThenInclude(x => x.TestedByUser)
        .Include(x => x.Records).ThenInclude(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Records).ThenInclude(x => x.Equipment).ThenInclude(x => x.TechnicalSystem);

    private IQueryable<TestRecord> RecordQuery() => dbContext.TestRecords
        .Include(x => x.TestPlan)
        .Include(x => x.Equipment).ThenInclude(x => x.Location)
        .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
        .Include(x => x.TestedByUser);

    private async Task<(IActionResult? Error, Equipment? Equipment, User? ResponsibleUser)> ValidatePlanRequest(
        Guid equipmentId,
        Guid responsibleUserId,
        string testType,
        DateOnly plannedDate,
        CancellationToken cancellationToken)
    {
        if (equipmentId == Guid.Empty)
        {
            return (BadRequest(new { message = "Hedef ekipman seçimi zorunludur." }), null, null);
        }

        if (responsibleUserId == Guid.Empty)
        {
            return (BadRequest(new { message = "Sorumlu kişi seçimi zorunludur." }), null, null);
        }

        if (string.IsNullOrWhiteSpace(testType))
        {
            return (BadRequest(new { message = "Test tipi zorunludur." }), null, null);
        }

        if (plannedDate == default)
        {
            return (BadRequest(new { message = "Planlanan test tarihi zorunludur." }), null, null);
        }

        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == equipmentId, cancellationToken);

        if (equipment is null || !equipment.IsActive || !equipment.Location.IsActive || !equipment.TechnicalSystem.IsActive)
        {
            return (BadRequest(new { message = "Geçerli ve aktif bir ekipman seçilmelidir." }), null, null);
        }

        var responsibleUser = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == responsibleUserId && x.IsActive, cancellationToken);

        if (responsibleUser is null || !ResponsibleRoles.Contains(responsibleUser.Role.Name))
        {
            return (BadRequest(new { message = "Sorumlu kişi aktif yönetici veya teknik personel olmalıdır." }), null, null);
        }

        return (null, equipment, responsibleUser);
    }

    private async Task<(IActionResult? Error, Equipment? Equipment, User? TestedByUser, TestPlan? Plan, TestResult Result, string TestType, DateTime TestDate)> ValidateRecordRequest(
        CreateTestRecordRequest request,
        CancellationToken cancellationToken)
    {
        var plan = request.TestPlanId.HasValue
            ? await dbContext.TestPlans
                .Include(x => x.Equipment).ThenInclude(x => x.Location)
                .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
                .SingleOrDefaultAsync(x => x.Id == request.TestPlanId.Value, cancellationToken)
            : null;

        if (request.TestPlanId.HasValue && plan is null)
        {
            return (BadRequest(new { message = "Geçerli bir test planı seçilmelidir." }), null, null, null, default, string.Empty, default);
        }

        if (plan?.Status == TestPlanStatus.Cancelled)
        {
            return (BadRequest(new { message = "İptal edilmiş test planına kayıt girilemez." }), null, null, null, default, string.Empty, default);
        }

        var equipmentId = request.EquipmentId != Guid.Empty ? request.EquipmentId : plan?.EquipmentId ?? Guid.Empty;
        if (equipmentId == Guid.Empty)
        {
            return (BadRequest(new { message = "Hedef ekipman seçimi zorunludur." }), null, null, null, default, string.Empty, default);
        }

        if (plan is not null && equipmentId != plan.EquipmentId)
        {
            return (BadRequest(new { message = "Test planı ile hedef ekipman eşleşmelidir." }), null, null, null, default, string.Empty, default);
        }

        if (request.TestedByUserId == Guid.Empty)
        {
            return (BadRequest(new { message = "Test eden kullanıcı seçimi zorunludur." }), null, null, null, default, string.Empty, default);
        }

        var testType = string.IsNullOrWhiteSpace(request.TestType) ? plan?.TestType.Trim() ?? string.Empty : request.TestType.Trim();
        if (string.IsNullOrWhiteSpace(testType))
        {
            return (BadRequest(new { message = "Test tipi zorunludur." }), null, null, null, default, string.Empty, default);
        }

        if (request.TestDate == default)
        {
            return (BadRequest(new { message = "Test tarihi zorunludur." }), null, null, null, default, string.Empty, default);
        }

        if (request.DurationMinutes.HasValue && request.DurationMinutes.Value <= 0)
        {
            return (BadRequest(new { message = "Test süresi 0 değerinden büyük olmalıdır." }), null, null, null, default, string.Empty, default);
        }

        if (!TryParseResult(request.Result, out var result))
        {
            return (BadRequest(new { message = "Geçersiz test sonucu." }), null, null, null, default, string.Empty, default);
        }

        if ((result == TestResult.Failed || result == TestResult.RetestRequired) &&
            string.IsNullOrWhiteSpace(request.AbnormalCondition) &&
            string.IsNullOrWhiteSpace(request.Description))
        {
            return (BadRequest(new { message = "Başarısız veya tekrar test gerekli sonucunda anormal durum ya da açıklama zorunludur." }), null, null, null, default, string.Empty, default);
        }

        var equipment = await dbContext.Equipment
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .SingleOrDefaultAsync(x => x.Id == equipmentId, cancellationToken);

        if (equipment is null || !equipment.IsActive || !equipment.Location.IsActive || !equipment.TechnicalSystem.IsActive)
        {
            return (BadRequest(new { message = "Geçerli ve aktif bir ekipman seçilmelidir." }), null, null, null, default, string.Empty, default);
        }

        var testedByUser = await dbContext.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == request.TestedByUserId && x.IsActive, cancellationToken);

        if (testedByUser is null || !ResponsibleRoles.Contains(testedByUser.Role.Name))
        {
            return (BadRequest(new { message = "Test eden kullanıcı aktif yönetici veya teknik personel olmalıdır." }), null, null, null, default, string.Empty, default);
        }

        return (null, equipment, testedByUser, plan, result, testType, NormalizeDateTime(request.TestDate));
    }

    private static TestPlanListItemDto MapPlanListItem(TestPlan plan, DateOnly today) => new()
    {
        Id = plan.Id,
        EquipmentId = plan.EquipmentId,
        EquipmentCode = plan.Equipment.Code,
        EquipmentName = plan.Equipment.Name,
        LocationId = plan.Equipment.LocationId,
        LocationName = plan.Equipment.Location.Name,
        TechnicalSystemId = plan.Equipment.TechnicalSystemId,
        TechnicalSystemName = plan.Equipment.TechnicalSystem.Name,
        ResponsibleUserId = plan.ResponsibleUserId,
        ResponsibleUserName = plan.ResponsibleUser.FullName,
        TestType = plan.TestType,
        PlannedDate = plan.PlannedDate,
        Frequency = plan.Frequency,
        Status = plan.Status.ToString(),
        DisplayStatus = GetDisplayStatus(plan.Status, plan.PlannedDate, today),
        Description = plan.Description,
        CreatedAt = plan.CreatedAt,
        UpdatedAt = plan.UpdatedAt
    };

    private static TestPlanDetailDto MapPlanDetail(TestPlan plan)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        return new TestPlanDetailDto
        {
            Id = plan.Id,
            EquipmentId = plan.EquipmentId,
            EquipmentCode = plan.Equipment.Code,
            EquipmentName = plan.Equipment.Name,
            LocationId = plan.Equipment.LocationId,
            LocationName = plan.Equipment.Location.Name,
            TechnicalSystemId = plan.Equipment.TechnicalSystemId,
            TechnicalSystemName = plan.Equipment.TechnicalSystem.Name,
            ResponsibleUserId = plan.ResponsibleUserId,
            ResponsibleUserName = plan.ResponsibleUser.FullName,
            ResponsibleUserTitle = plan.ResponsibleUser.Title,
            ResponsibleUserDepartment = plan.ResponsibleUser.Department,
            TestType = plan.TestType,
            PlannedDate = plan.PlannedDate,
            Frequency = plan.Frequency,
            Status = plan.Status.ToString(),
            DisplayStatus = GetDisplayStatus(plan.Status, plan.PlannedDate, today),
            Description = plan.Description,
            CreatedAt = plan.CreatedAt,
            UpdatedAt = plan.UpdatedAt,
            Records = plan.Records.OrderByDescending(x => x.TestDate).Select(MapRecordListItem).ToList()
        };
    }

    private static TestRecordListItemDto MapRecordListItem(TestRecord record) => new()
    {
        Id = record.Id,
        TestPlanId = record.TestPlanId,
        EquipmentId = record.EquipmentId,
        EquipmentCode = record.Equipment.Code,
        EquipmentName = record.Equipment.Name,
        LocationId = record.Equipment.LocationId,
        LocationName = record.Equipment.Location.Name,
        TechnicalSystemId = record.Equipment.TechnicalSystemId,
        TechnicalSystemName = record.Equipment.TechnicalSystem.Name,
        TestedByUserId = record.TestedByUserId,
        TestedByUserName = record.TestedByUser.FullName,
        TestedByUserTitle = record.TestedByUser.Title,
        TestType = record.TestType,
        TestDate = record.TestDate,
        DurationMinutes = record.DurationMinutes,
        Result = record.Result.ToString(),
        AbnormalCondition = record.AbnormalCondition,
        Description = record.Description,
        CreatedAt = record.CreatedAt,
        UpdatedAt = record.UpdatedAt
    };

    private static TestRecordDetailDto MapRecordDetail(TestRecord record, IReadOnlyList<TestRecord> recentRecords) => new()
    {
        Id = record.Id,
        TestPlanId = record.TestPlanId,
        EquipmentId = record.EquipmentId,
        EquipmentCode = record.Equipment.Code,
        EquipmentName = record.Equipment.Name,
        LocationId = record.Equipment.LocationId,
        LocationName = record.Equipment.Location.Name,
        TechnicalSystemId = record.Equipment.TechnicalSystemId,
        TechnicalSystemName = record.Equipment.TechnicalSystem.Name,
        TestedByUserId = record.TestedByUserId,
        TestedByUserName = record.TestedByUser.FullName,
        TestedByUserTitle = record.TestedByUser.Title,
        TestedByUserDepartment = record.TestedByUser.Department,
        TestType = record.TestType,
        TestDate = record.TestDate,
        DurationMinutes = record.DurationMinutes,
        Result = record.Result.ToString(),
        AbnormalCondition = record.AbnormalCondition,
        Description = record.Description,
        CreatedAt = record.CreatedAt,
        UpdatedAt = record.UpdatedAt,
        EquipmentRecentRecords = recentRecords.Select(MapRecordListItem).ToList()
    };

    private static string GetDisplayStatus(TestPlanStatus status, DateOnly plannedDate, DateOnly today)
    {
        return status != TestPlanStatus.Completed && plannedDate < today ? "Delayed" : status.ToString();
    }

    private static bool TryParsePlanStatus(string? status, out TestPlanStatus parsedStatus)
    {
        return Enum.TryParse(status?.Trim(), ignoreCase: true, out parsedStatus) && Enum.IsDefined(parsedStatus);
    }

    private static bool TryParseResult(string? result, out TestResult parsedResult)
    {
        return Enum.TryParse(result?.Trim(), ignoreCase: true, out parsedResult) && Enum.IsDefined(parsedResult);
    }

    private static DateTime NormalizeDateTime(DateTime value) => value.Kind switch
    {
        DateTimeKind.Local => value.ToUniversalTime(),
        DateTimeKind.Utc => value,
        _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
    };

    private static string? NormalizeOptional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
