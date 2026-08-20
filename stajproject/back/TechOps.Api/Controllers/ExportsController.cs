using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOps.Api.Data;
using TechOps.Api.Entities;
using TechOps.Api.Enums;
using TechOps.Api.Models;
using TechOps.Api.Services;

namespace TechOps.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/exports")]
public sealed class ExportsController(AppDbContext dbContext, IExecutiveReportService reportService) : ControllerBase
{
    private const string DashboardRoles = "Admin,Yönetici,Teknik Personel,Operatör,Rapor Kullanıcısı";
    private const string ReportRoles = "Admin,Yönetici,Teknik Personel,Rapor Kullanıcısı";
    private const string OperationsRoles = "Admin,Yönetici,Teknik Personel";
    private const string FaultRoles = "Admin,Yönetici,Teknik Personel,Operatör";
    private const string ActivityRoles = "Admin,Yönetici,Rapor Kullanıcısı";

    [Authorize(Roles = DashboardRoles)]
    [HttpGet("dashboard/{format}")]
    public async Task<IActionResult> ExportDashboard([FromRoute] string format, [FromQuery] string? period, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var faults = await dbContext.Faults.AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.AssignedToUser)
            .OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt)
            .ToListAsync(cancellationToken);
        var maintenancePlans = await dbContext.MaintenancePlans.AsNoTracking().ToListAsync(cancellationToken);
        var testRecords = await dbContext.TestRecords.AsNoTracking().ToListAsync(cancellationToken);
        var openShiftItems = await dbContext.ShiftItems.AsNoTracking()
            .Include(x => x.ShiftHandover)
            .Include(x => x.Equipment)
            .Include(x => x.Fault).ThenInclude(x => x!.Equipment)
            .Include(x => x.MaintenancePlan).ThenInclude(x => x!.Equipment)
            .Where(x => !x.IsCompleted)
            .OrderByDescending(x => x.Priority == FaultPriority.Critical)
            .ThenByDescending(x => x.Priority == FaultPriority.High)
            .ThenByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

        var openFaults = faults.Where(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed).ToList();
        var criticalFaults = faults.Where(x => x.Priority == FaultPriority.Critical).ToList();
        var completedMaintenance = maintenancePlans.Count(x => x.Status == MaintenanceStatus.Completed);
        var successfulTests = testRecords.Count(x => x.Result is TestResult.Success or TestResult.ConditionalSuccess);
        var trendPeriod = NormalizeTrendPeriod(period);

        var report = new ExecutiveReportDocument
        {
            Title = "Operasyon Dashboard Yönetici Raporu",
            Subtitle = "KPI, trend, kritik arıza ve devreden iş özeti",
            ModuleName = "Dashboard",
            GeneratedAt = now,
            Metrics =
            [
                Metric("Açık Arıza", openFaults.Count, "Çözülmemiş/kapatılmamış"),
                Metric("Kritik Arıza", criticalFaults.Count, "Toplam kritik kayıt"),
                Metric("Bekleyen İş", openShiftItems.Count, "Açık vardiya maddesi"),
                Metric("Bakım Tamamlama", $"%{Rate(completedMaintenance, maintenancePlans.Count)}", $"{completedMaintenance}/{maintenancePlans.Count}"),
                Metric("Test Başarı", $"%{Rate(successfulTests, testRecords.Count)}", $"{successfulTests}/{testRecords.Count}"),
                Metric("Tamamlanan Test", testRecords.Count, "Toplam test kaydı")
            ],
            Filters = [Filter("Trend Periyodu", TrendPeriodLabel(trendPeriod))],
            Sections =
            [
                Section("Arıza Trendi", "Seçili periyoda göre kayıt yoğunluğu", ["Dönem", "Kayıt"], BuildFaultTrendRows(faults, now, trendPeriod)),
                Section("Lokasyon Bazlı Arızalar", "Arızaların lokasyon dağılımı", ["Lokasyon", "Arıza"], faults.GroupBy(x => x.Equipment.Location.Name).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Kritik Açık Arızalar", "Yönetici takibi gerektiren kritik açık kayıtlar", ["Arıza", "Ekipman", "Lokasyon", "Durum", "Atanan", "Tarih"], criticalFaults.Where(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed).Take(20).Select(x => Row(x.FaultNo, x.Equipment.Name, x.Equipment.Location.Name, x.Status, x.AssignedToUser?.FullName, x.CreatedAt)).ToList()),
                Section("Devreden İşler", "Vardiya devirlerinden gelen açık maddeler", ["Devir", "Tür", "Başlık", "Öncelik", "Ekipman", "Tarih"], openShiftItems.Take(30).Select(x => Row(x.ShiftHandover.HandoverNo, x.ItemType, x.Title, x.Priority, x.Equipment?.Code ?? x.Fault?.Equipment.Code ?? x.MaintenancePlan?.Equipment.Code, x.CreatedAt)).ToList())
            ]
        };

        return Export(report, format, $"dashboard-yonetici-raporu-{trendPeriod}");
    }

    [Authorize(Roles = ReportRoles)]
    [HttpGet("reports/operations/{format}")]
    public async Task<IActionResult> ExportOperationsReport(
        [FromRoute] string format,
        [FromQuery] DateOnly? from,
        [FromQuery] DateOnly? to,
        [FromQuery] Guid? locationId,
        [FromQuery] Guid? technicalSystemId,
        [FromQuery] Guid? equipmentId,
        [FromQuery] string? priority,
        [FromQuery] string? status,
        CancellationToken cancellationToken)
    {
        if (from.HasValue && to.HasValue && from > to)
        {
            return BadRequest(new { message = "Başlangıç tarihi bitiş tarihinden büyük olamaz." });
        }

        var parsedPriority = ParseEnum<FaultPriority>(priority);
        var parsedStatus = ParseEnum<FaultStatus>(status);
        if (!string.IsNullOrWhiteSpace(priority) && parsedPriority is null)
        {
            return BadRequest(new { message = "Öncelik filtresi geçersiz." });
        }

        if (!string.IsNullOrWhiteSpace(status) && parsedStatus is null)
        {
            return BadRequest(new { message = "Durum filtresi geçersiz." });
        }

        var faultsQuery = dbContext.Faults.AsNoTracking()
            .Include(x => x.Equipment)
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .AsQueryable();
        if (from.HasValue) faultsQuery = faultsQuery.Where(x => x.CreatedAt >= from.Value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        if (to.HasValue) faultsQuery = faultsQuery.Where(x => x.CreatedAt < to.Value.AddDays(1).ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        if (locationId.HasValue) faultsQuery = faultsQuery.Where(x => x.LocationId == locationId.Value);
        if (technicalSystemId.HasValue) faultsQuery = faultsQuery.Where(x => x.TechnicalSystemId == technicalSystemId.Value);
        if (equipmentId.HasValue) faultsQuery = faultsQuery.Where(x => x.EquipmentId == equipmentId.Value);
        if (parsedPriority.HasValue) faultsQuery = faultsQuery.Where(x => x.Priority == parsedPriority.Value);
        if (parsedStatus.HasValue) faultsQuery = faultsQuery.Where(x => x.Status == parsedStatus.Value);

        var maintenanceQuery = dbContext.MaintenancePlans.AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
            .AsQueryable();
        if (from.HasValue) maintenanceQuery = maintenanceQuery.Where(x => x.PlannedDate >= from.Value);
        if (to.HasValue) maintenanceQuery = maintenanceQuery.Where(x => x.PlannedDate <= to.Value);
        if (locationId.HasValue) maintenanceQuery = maintenanceQuery.Where(x => x.Equipment.LocationId == locationId.Value);
        if (technicalSystemId.HasValue) maintenanceQuery = maintenanceQuery.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        if (equipmentId.HasValue) maintenanceQuery = maintenanceQuery.Where(x => x.EquipmentId == equipmentId.Value);
        if (parsedPriority.HasValue) maintenanceQuery = maintenanceQuery.Where(x => x.Priority == parsedPriority.Value);

        var testQuery = dbContext.TestRecords.AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.Equipment).ThenInclude(x => x.TechnicalSystem)
            .AsQueryable();
        if (from.HasValue) testQuery = testQuery.Where(x => x.TestDate >= from.Value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        if (to.HasValue) testQuery = testQuery.Where(x => x.TestDate < to.Value.AddDays(1).ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        if (locationId.HasValue) testQuery = testQuery.Where(x => x.Equipment.LocationId == locationId.Value);
        if (technicalSystemId.HasValue) testQuery = testQuery.Where(x => x.Equipment.TechnicalSystemId == technicalSystemId.Value);
        if (equipmentId.HasValue) testQuery = testQuery.Where(x => x.EquipmentId == equipmentId.Value);

        var faults = await faultsQuery.OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt).ToListAsync(cancellationToken);
        var maintenancePlans = await maintenanceQuery.OrderByDescending(x => x.CompletedAt ?? x.CreatedAt).ToListAsync(cancellationToken);
        var testRecords = await testQuery.OrderByDescending(x => x.TestDate).ToListAsync(cancellationToken);
        var completedMaintenance = maintenancePlans.Count(x => x.Status == MaintenanceStatus.Completed);
        var successfulTests = testRecords.Count(x => x.Result is TestResult.Success or TestResult.ConditionalSuccess);

        var report = new ExecutiveReportDocument
        {
            Title = "Operasyon Analiz Yönetici Raporu",
            Subtitle = "Filtreli arıza, bakım ve test performans özeti",
            ModuleName = "Raporlama",
            GeneratedAt = DateTime.UtcNow,
            Metrics =
            [
                Metric("Arıza", faults.Count, "Filtreye uyan kayıt"),
                Metric("Açık Arıza", faults.Count(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed), "Devam eden"),
                Metric("Kritik Arıza", faults.Count(x => x.Priority == FaultPriority.Critical), "Kritik öncelik"),
                Metric("Bakım", maintenancePlans.Count, $"%{Rate(completedMaintenance, maintenancePlans.Count)} tamamlandı"),
                Metric("Test", testRecords.Count, $"%{Rate(successfulTests, testRecords.Count)} başarılı"),
                Metric("Ort. Çözüm", AverageResolutionHours(faults), "saat")
            ],
            Filters = BuildCommonFilters(from, to, locationId, technicalSystemId, equipmentId, priority, status),
            Sections =
            [
                Section("En Fazla Arıza Veren Ekipman", "Tekrarlayan ekipman odakları", ["Ekipman", "Ad", "Arıza"], faults.GroupBy(x => new { x.Equipment.Code, x.Equipment.Name }).OrderByDescending(x => x.Count()).Take(15).Select(x => Row(x.Key.Code, x.Key.Name, x.Count())).ToList()),
                Section("Lokasyon Dağılımı", "Lokasyon bazlı arıza yoğunluğu", ["Lokasyon", "Arıza"], faults.GroupBy(x => x.Location.Name).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Arıza Detayları", "İlk 50 filtreli arıza kaydı", ["No", "Ekipman", "Lokasyon", "Sistem", "Öncelik", "Durum", "Tarih"], faults.Take(50).Select(x => Row(x.FaultNo, x.Equipment.Code, x.Location.Name, x.TechnicalSystem.Name, x.Priority, x.Status, x.CreatedAt)).ToList()),
                Section("Bakım Planları", "İlk 50 filtreli bakım kaydı", ["Plan", "Ekipman", "Tür", "Öncelik", "Durum", "Plan Tarihi"], maintenancePlans.Take(50).Select(x => Row(x.PlanNo, x.Equipment.Code, x.MaintenanceType, x.Priority, x.Status, x.PlannedDate)).ToList()),
                Section("Test Kayıtları", "İlk 50 filtreli test kaydı", ["Ekipman", "Test", "Sonuç", "Süre", "Tarih"], testRecords.Take(50).Select(x => Row(x.Equipment.Code, x.TestType, x.Result, x.DurationMinutes, x.TestDate)).ToList())
            ]
        };

        return Export(report, format, "operasyon-yonetici-raporu");
    }

    [Authorize(Roles = FaultRoles)]
    [HttpGet("faults/{format}")]
    public async Task<IActionResult> ExportFaults([FromRoute] string format, CancellationToken cancellationToken)
    {
        var faults = await dbContext.Faults.AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .Include(x => x.AssignedToUser)
            .OrderByDescending(x => x.CreatedAt)
            .Take(300)
            .ToListAsync(cancellationToken);

        var report = new ExecutiveReportDocument
        {
            Title = "Arıza Yönetimi Yönetici Raporu",
            Subtitle = "Açık, kritik ve tekrar eden arıza görünümü",
            ModuleName = "Arıza Yönetimi",
            GeneratedAt = DateTime.UtcNow,
            Metrics =
            [
                Metric("Toplam Arıza", faults.Count, "Son 300 kayıt"),
                Metric("Açık Arıza", faults.Count(x => x.Status is not FaultStatus.Resolved and not FaultStatus.Closed), "Takipte"),
                Metric("Kritik", faults.Count(x => x.Priority == FaultPriority.Critical), "Acil öncelik"),
                Metric("Kapalı", faults.Count(x => x.Status == FaultStatus.Closed), "Tamamlanan")
            ],
            Filters = [Filter("Kapsam", "Son 300 arıza kaydı")],
            Sections =
            [
                Section("Durum Dağılımı", "Arıza durumlarına göre özet", ["Durum", "Kayıt"], faults.GroupBy(x => x.Status).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Öncelik Dağılımı", "Arıza önceliklerine göre özet", ["Öncelik", "Kayıt"], faults.GroupBy(x => x.Priority).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Arıza Listesi", "Yönetici inceleme listesi", ["No", "Ekipman", "Lokasyon", "Sistem", "Öncelik", "Durum", "Atanan", "Tarih"], faults.Select(x => Row(x.FaultNo, x.Equipment.Code, x.Equipment.Location.Name, x.TechnicalSystem.Name, x.Priority, x.Status, x.AssignedToUser?.FullName, x.CreatedAt)).ToList())
            ]
        };

        return Export(report, format, "ariza-yonetici-raporu");
    }

    [Authorize(Roles = OperationsRoles)]
    [HttpGet("maintenance/{format}")]
    public async Task<IActionResult> ExportMaintenance([FromRoute] string format, CancellationToken cancellationToken)
    {
        var plans = await dbContext.MaintenancePlans.AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.ResponsibleUser)
            .OrderByDescending(x => x.PlannedDate)
            .Take(300)
            .ToListAsync(cancellationToken);
        var completed = plans.Count(x => x.Status == MaintenanceStatus.Completed);
        var delayed = plans.Count(x => x.Status != MaintenanceStatus.Completed && x.PlannedDate < DateOnly.FromDateTime(DateTime.UtcNow));

        var report = new ExecutiveReportDocument
        {
            Title = "Bakım Yönetimi Yönetici Raporu",
            Subtitle = "Plan, tamamlanma ve gecikme özeti",
            ModuleName = "Bakım Yönetimi",
            GeneratedAt = DateTime.UtcNow,
            Metrics = [Metric("Plan", plans.Count, "Son 300 kayıt"), Metric("Tamamlanan", completed, $"%{Rate(completed, plans.Count)}"), Metric("Geciken", delayed, "Plan tarihi geçti"), Metric("Kritik", plans.Count(x => x.Priority == FaultPriority.Critical), "Kritik öncelik")],
            Filters = [Filter("Kapsam", "Son 300 bakım planı")],
            Sections =
            [
                Section("Durum Dağılımı", "Bakım planı durumları", ["Durum", "Kayıt"], plans.GroupBy(x => x.Status).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Bakım Planları", "Yönetici bakım planı listesi", ["Plan", "Ekipman", "Lokasyon", "Tür", "Sorumlu", "Öncelik", "Durum", "Tarih"], plans.Select(x => Row(x.PlanNo, x.Equipment.Code, x.Equipment.Location.Name, x.MaintenanceType, x.ResponsibleUser.FullName, x.Priority, x.Status, x.PlannedDate)).ToList())
            ]
        };

        return Export(report, format, "bakim-yonetici-raporu");
    }

    [Authorize(Roles = OperationsRoles)]
    [HttpGet("tests/{format}")]
    public async Task<IActionResult> ExportTests([FromRoute] string format, CancellationToken cancellationToken)
    {
        var records = await dbContext.TestRecords.AsNoTracking()
            .Include(x => x.Equipment).ThenInclude(x => x.Location)
            .Include(x => x.TestedByUser)
            .OrderByDescending(x => x.TestDate)
            .Take(300)
            .ToListAsync(cancellationToken);
        var success = records.Count(x => x.Result is TestResult.Success or TestResult.ConditionalSuccess);

        var report = new ExecutiveReportDocument
        {
            Title = "Periyodik Test Yönetici Raporu",
            Subtitle = "Test sonuçları ve tekrar test ihtiyacı",
            ModuleName = "Test Yönetimi",
            GeneratedAt = DateTime.UtcNow,
            Metrics = [Metric("Test", records.Count, "Son 300 kayıt"), Metric("Başarı", $"%{Rate(success, records.Count)}", $"{success}/{records.Count}"), Metric("Başarısız", records.Count(x => x.Result == TestResult.Failed), "Limit dışı"), Metric("Tekrar Test", records.Count(x => x.Result == TestResult.RetestRequired), "Aksiyon gerekli")],
            Filters = [Filter("Kapsam", "Son 300 test kaydı")],
            Sections =
            [
                Section("Sonuç Dağılımı", "Test sonuçlarına göre özet", ["Sonuç", "Kayıt"], records.GroupBy(x => x.Result).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Test Kayıtları", "Yönetici test kayıt listesi", ["Ekipman", "Lokasyon", "Test", "Test Eden", "Sonuç", "Süre", "Tarih"], records.Select(x => Row(x.Equipment.Code, x.Equipment.Location.Name, x.TestType, x.TestedByUser.FullName, x.Result, x.DurationMinutes, x.TestDate)).ToList())
            ]
        };

        return Export(report, format, "test-yonetici-raporu");
    }

    [Authorize(Roles = OperationsRoles)]
    [HttpGet("shifts/{format}")]
    public async Task<IActionResult> ExportShifts([FromRoute] string format, CancellationToken cancellationToken)
    {
        var handovers = await dbContext.ShiftHandovers.AsNoTracking()
            .Include(x => x.HandoverFromUser)
            .Include(x => x.HandoverToUser)
            .Include(x => x.Items)
            .OrderByDescending(x => x.ShiftDate)
            .ThenByDescending(x => x.CreatedAt)
            .Take(200)
            .ToListAsync(cancellationToken);
        var openItemCount = handovers.Sum(x => x.Items.Count(item => !item.IsCompleted));

        var report = new ExecutiveReportDocument
        {
            Title = "Vardiya Devir Teslim Yönetici Raporu",
            Subtitle = "Devir kayıtları ve açık devreden işler",
            ModuleName = "Vardiya Devir Teslim",
            GeneratedAt = DateTime.UtcNow,
            Metrics = [Metric("Devir", handovers.Count, "Son 200 kayıt"), Metric("Açık Madde", openItemCount, "Devreden iş"), Metric("Kritik Not", handovers.Count(x => !string.IsNullOrWhiteSpace(x.CriticalNotes)), "Not içeren"), Metric("Tamamlanan Madde", handovers.Sum(x => x.Items.Count(item => item.IsCompleted)), "Kapatılan")],
            Filters = [Filter("Kapsam", "Son 200 vardiya devri")],
            Sections =
            [
                Section("Vardiya Dağılımı", "Vardiya türlerine göre devir sayısı", ["Vardiya", "Kayıt"], handovers.GroupBy(x => x.ShiftType).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Devir Kayıtları", "Yönetici devir teslim listesi", ["No", "Vardiya", "Tarih", "Devreden", "Devralan", "Açık Madde", "Özet"], handovers.Select(x => Row(x.HandoverNo, x.ShiftType, x.ShiftDate, x.HandoverFromUser.FullName, x.HandoverToUser.FullName, x.Items.Count(item => !item.IsCompleted), x.Summary)).ToList())
            ]
        };

        return Export(report, format, "vardiya-yonetici-raporu");
    }

    [Authorize(Roles = OperationsRoles)]
    [HttpGet("equipment/{format}")]
    public async Task<IActionResult> ExportEquipment([FromRoute] string format, CancellationToken cancellationToken)
    {
        var equipment = await dbContext.Equipment.AsNoTracking()
            .Include(x => x.Location)
            .Include(x => x.TechnicalSystem)
            .OrderBy(x => x.Code)
            .ToListAsync(cancellationToken);

        var report = new ExecutiveReportDocument
        {
            Title = "Ekipman Envanteri Yönetici Raporu",
            Subtitle = "Varlık envanteri, durum ve lokasyon dağılımı",
            ModuleName = "Varlık Yönetimi",
            GeneratedAt = DateTime.UtcNow,
            Metrics = [Metric("Ekipman", equipment.Count, "Toplam varlık"), Metric("Aktif", equipment.Count(x => x.IsActive), "Kullanımda"), Metric("Arızalı", equipment.Count(x => x.Status == EquipmentStatus.Faulted), "Aksiyon gerekli"), Metric("Bakımda", equipment.Count(x => x.Status == EquipmentStatus.Maintenance), "Planlı/aktif bakım")],
            Filters = [Filter("Kapsam", "Tüm ekipman envanteri")],
            Sections =
            [
                Section("Durum Dağılımı", "Ekipman durum özeti", ["Durum", "Ekipman"], equipment.GroupBy(x => x.Status).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Lokasyon Dağılımı", "Lokasyona göre varlık sayısı", ["Lokasyon", "Ekipman"], equipment.GroupBy(x => x.Location.Name).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Envanter", "Yönetici ekipman listesi", ["Kod", "Ad", "Lokasyon", "Sistem", "Marka", "Model", "Durum", "Aktif"], equipment.Select(x => Row(x.Code, x.Name, x.Location.Name, x.TechnicalSystem.Name, x.Brand, x.Model, x.Status, x.IsActive ? "Aktif" : "Pasif")).ToList())
            ]
        };

        return Export(report, format, "ekipman-yonetici-raporu");
    }

    [Authorize(Roles = ActivityRoles)]
    [HttpGet("activity/{format}")]
    public async Task<IActionResult> ExportActivity([FromRoute] string format, CancellationToken cancellationToken)
    {
        var logs = await dbContext.AuditLogs.AsNoTracking()
            .Include(x => x.User).ThenInclude(x => x!.Role)
            .OrderByDescending(x => x.CreatedAt)
            .Take(300)
            .ToListAsync(cancellationToken);

        var report = new ExecutiveReportDocument
        {
            Title = "Aktivite ve Denetim Yönetici Raporu",
            Subtitle = "Sistem işlem geçmişi ve modül bazlı hareket özeti",
            ModuleName = "Bildirim ve Aktivite Merkezi",
            GeneratedAt = DateTime.UtcNow,
            Metrics = [Metric("Aktivite", logs.Count, "Son 300 kayıt"), Metric("Kullanıcı", logs.Select(x => x.UserId).Distinct().Count(), "İşlem yapan"), Metric("Export", logs.Count(x => x.Action == "Export"), "Dışa aktarma"), Metric("Modül", logs.Select(x => x.EntityName).Distinct().Count(), "Etkilenen varlık")],
            Filters = [Filter("Kapsam", "Son 300 aktivite kaydı")],
            Sections =
            [
                Section("Modül Dağılımı", "Entity bazlı aktivite sayısı", ["Modül", "Kayıt"], logs.GroupBy(x => x.EntityName).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Aktivite Listesi", "Yönetici denetim listesi", ["Kullanıcı", "Rol", "Modül", "Aksiyon", "IP", "Tarih"], logs.Select(x => Row(x.User?.FullName, x.User?.Role.Name, x.EntityName, x.Action, x.IpAddress, x.CreatedAt)).ToList())
            ]
        };

        return Export(report, format, "aktivite-denetim-raporu");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("users/{format}")]
    public async Task<IActionResult> ExportUsers([FromRoute] string format, CancellationToken cancellationToken)
    {
        var users = await dbContext.Users.AsNoTracking()
            .Include(x => x.Role)
            .OrderBy(x => x.FullName)
            .ToListAsync(cancellationToken);
        var openFaults = await dbContext.Faults.AsNoTracking().Where(x => x.AssignedToUserId.HasValue && x.Status != FaultStatus.Resolved && x.Status != FaultStatus.Closed).GroupBy(x => x.AssignedToUserId!.Value).Select(x => new { UserId = x.Key, Count = x.Count() }).ToListAsync(cancellationToken);
        var faultMap = openFaults.ToDictionary(x => x.UserId, x => x.Count);

        var report = new ExecutiveReportDocument
        {
            Title = "Kullanıcı ve İş Yükü Yönetici Raporu",
            Subtitle = "Rol dağılımı, aktiflik ve açık iş yükü özeti",
            ModuleName = "Kullanıcı Yönetimi",
            GeneratedAt = DateTime.UtcNow,
            Metrics = [Metric("Kullanıcı", users.Count, "Toplam"), Metric("Aktif", users.Count(x => x.IsActive), "Aktif hesap"), Metric("Pasif", users.Count(x => !x.IsActive), "Pasif hesap"), Metric("Admin", users.Count(x => x.Role.Name == "Admin"), "Yönetici")],
            Filters = [Filter("Kapsam", "Tüm kullanıcılar")],
            Sections =
            [
                Section("Rol Dağılımı", "Role göre kullanıcı sayısı", ["Rol", "Kullanıcı"], users.GroupBy(x => x.Role.Name).OrderByDescending(x => x.Count()).Select(x => Row(x.Key, x.Count())).ToList()),
                Section("Kullanıcı Listesi", "Admin yönetici listesi", ["Ad Soyad", "Kullanıcı", "E-posta", "Rol", "Unvan", "Departman", "Aktif", "Açık Arıza"], users.Select(x => Row(x.FullName, x.Username, x.Email, x.Role.Name, x.Title, x.Department, x.IsActive ? "Aktif" : "Pasif", faultMap.GetValueOrDefault(x.Id))).ToList())
            ]
        };

        return Export(report, format, "kullanici-yonetici-raporu");
    }

    private IActionResult Export(ExecutiveReportDocument report, string format, string fileName)
    {
        var normalized = format.Trim().ToLowerInvariant();
        var stampedFileName = $"{fileName}-{DateTime.UtcNow:yyyyMMdd-HHmm}";
        if (normalized is "xlsx" or "excel")
        {
            return File(reportService.BuildExcel(report), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{stampedFileName}.xlsx");
        }

        if (normalized == "pdf")
        {
            return File(reportService.BuildPdf(report), "application/pdf", $"{stampedFileName}.pdf");
        }

        return BadRequest(new { message = "Desteklenen formatlar: xlsx, pdf." });
    }

    private static ExecutiveReportMetric Metric(string label, object? value, string note) => new() { Label = label, Value = FormatValue(value), Note = note };
    private static ExecutiveReportFilter Filter(string label, object? value) => new() { Label = label, Value = FormatValue(value) };

    private static ExecutiveReportSection Section(string title, string description, IReadOnlyList<string> headers, IReadOnlyList<IReadOnlyList<string>> rows) => new()
    {
        Title = title,
        Description = description,
        Headers = headers,
        Rows = rows
    };

    private static IReadOnlyList<string> Row(params object?[] values) => values.Select(FormatValue).ToList();

    private static string FormatValue(object? value) => value switch
    {
        null => "-",
        DateTime dateTime => dateTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm"),
        DateOnly dateOnly => dateOnly.ToString("dd.MM.yyyy"),
        decimal number => number.ToString("0.##"),
        double number => number.ToString("0.##"),
        float number => number.ToString("0.##"),
        _ => value.ToString() ?? "-"
    };

    private static decimal Rate(int completed, int total) => total == 0 ? 0 : Math.Round((decimal)completed * 100 / total, 1);

    private static decimal AverageResolutionHours(IReadOnlyList<Fault> faults)
    {
        var resolved = faults.Where(x => x.ResolvedAt.HasValue || x.ClosedAt.HasValue).ToList();
        if (resolved.Count == 0)
        {
            return 0;
        }

        return Math.Round((decimal)resolved.Average(x => ((x.ClosedAt ?? x.ResolvedAt)!.Value - x.CreatedAt).TotalHours), 1);
    }

    private static TEnum? ParseEnum<TEnum>(string? value) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return Enum.TryParse<TEnum>(value.Trim(), true, out var parsed) && Enum.IsDefined(parsed) ? parsed : null;
    }

    private static string NormalizeTrendPeriod(string? period) => period?.Trim().ToLowerInvariant() switch
    {
        "week" => "week",
        "year" => "year",
        _ => "month"
    };

    private static string TrendPeriodLabel(string period) => period switch
    {
        "week" => "Haftalık",
        "year" => "Yıllık",
        _ => "Aylık"
    };

    private static IReadOnlyList<IReadOnlyList<string>> BuildFaultTrendRows(IReadOnlyList<Fault> faults, DateTime now, string period)
    {
        if (period == "week")
        {
            var start = DateOnly.FromDateTime(now.Date.AddDays(-6));
            return Enumerable.Range(0, 7).Select(offset =>
            {
                var day = start.AddDays(offset);
                return Row(day, faults.Count(x => DateOnly.FromDateTime(x.CreatedAt) == day));
            }).ToList();
        }

        if (period == "year")
        {
            var startYear = now.Year - 4;
            return Enumerable.Range(0, 5).Select(offset =>
            {
                var year = startYear + offset;
                return Row(year, faults.Count(x => x.CreatedAt.Year == year));
            }).ToList();
        }

        var trendStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-5);
        return Enumerable.Range(0, 6).Select(offset =>
        {
            var month = trendStart.AddMonths(offset);
            return Row(month.ToString("MMM yyyy"), faults.Count(x => x.CreatedAt.Year == month.Year && x.CreatedAt.Month == month.Month));
        }).ToList();
    }

    private static IReadOnlyList<ExecutiveReportFilter> BuildCommonFilters(DateOnly? from, DateOnly? to, Guid? locationId, Guid? technicalSystemId, Guid? equipmentId, string? priority, string? status) =>
    [
        Filter("Başlangıç", from?.ToString("dd.MM.yyyy") ?? "Tümü"),
        Filter("Bitiş", to?.ToString("dd.MM.yyyy") ?? "Tümü"),
        Filter("Lokasyon", locationId?.ToString() ?? "Tümü"),
        Filter("Sistem", technicalSystemId?.ToString() ?? "Tümü"),
        Filter("Ekipman", equipmentId?.ToString() ?? "Tümü"),
        Filter("Öncelik", string.IsNullOrWhiteSpace(priority) ? "Tümü" : priority),
        Filter("Durum", string.IsNullOrWhiteSpace(status) ? "Tümü" : status)
    ];
}
