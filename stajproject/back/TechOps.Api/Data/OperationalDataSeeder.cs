using Microsoft.EntityFrameworkCore;
using TechOps.Api.Entities;
using TechOps.Api.Enums;

namespace TechOps.Api.Data;

public interface IOperationalDataSeeder
{
    Task SeedIfNeededAsync(CancellationToken cancellationToken = default);
    Task SeedAsync(bool forceReset, CancellationToken cancellationToken = default);
}

public sealed class OperationalDataSeeder(AppDbContext dbContext) : IOperationalDataSeeder
{
    private static readonly DateTime SeedCreatedAt = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static readonly DateTime DataStart = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static readonly DateTime DataEnd = new(2026, 8, 22, 23, 59, 0, DateTimeKind.Utc);
    private static readonly DateOnly DataStartDate = DateOnly.FromDateTime(DataStart);
    private static readonly DateOnly DataEndDate = DateOnly.FromDateTime(DataEnd);
    private static readonly int TotalDays = DataEndDate.DayNumber - DataStartDate.DayNumber + 1;

    private static readonly Guid AdminRoleId = SeedData.AdminRoleId;
    private static readonly Guid ManagerRoleId = SeedData.ManagerRoleId;
    private static readonly Guid TechnicianRoleId = SeedData.TechnicianRoleId;
    private static readonly Guid OperatorRoleId = SeedData.OperatorRoleId;
    private static readonly Guid ReportRoleId = SeedData.ReportRoleId;

    private static readonly string[] TechnicalDepartments = ["Elektrik", "Mekanik", "Otomasyon", "HVAC", "Enerji", "Saha Bakım"];
    private static readonly string[] AreaCodes = ["TA", "TB", "LC", "TBK", "APR", "KGO", "KGP", "OTK", "BHS", "KRG"];
    private static readonly string[] AreaNames = ["Terminal A", "Terminal B", "Level Kontrol Merkezi", "Teknik Blok", "Apron", "Kargo Operasyon", "Kapı Bölgesi", "Otopark", "Bagaj Sistemi", "Kritik Güç Odası"];
    private static readonly string[] LocationTypes = ["Terminal", "Teknik Alan", "Saha", "Enerji Odası", "Operasyon Alanı", "Bakım Bölgesi"];
    private static readonly string[] SystemFamilies = ["Jeneratör", "UPS", "HVAC", "Elektrik Dağıtım", "Otomasyon", "Yangın Algılama", "Aydınlatma", "Pompaj", "Bina Yönetim", "Bagaj Konveyör"];
    private static readonly string[] SystemCodes = ["GEN", "UPS", "HVAC", "ELC", "AUT", "FAS", "LGT", "PMP", "BMS", "BHS"];
    private static readonly string[] BrandFamilies = ["AtlasPower", "DeltaUPS", "ClimaTech", "Schneider Electric", "Siemens", "Honeywell", "ABB", "Grundfos", "Johnson Controls", "Vanderlande"];
    private static readonly string[] ModelFamilies = ["PX-750", "RT-300", "AHU-450", "NSX-630", "S7-1500", "EBI-410", "DALI-220", "CR-90", "BMS-800", "BC-1200"];
    private static readonly string[] EquipmentPrefixes = ["GEN", "UPS", "AHU", "MDB", "PLC", "FAS", "LGT", "PMP", "BMS", "CNV"];
    private static readonly string[] FirstNames = ["Ahmet", "Mehmet", "Ayşe", "Fatma", "Murat", "Zeynep", "Emre", "Elif", "Can", "Derya", "Burak", "Selin", "Okan", "Merve", "Kerem", "Ece", "Hakan", "Seda", "Tolga", "Büşra", "Onur", "Gizem", "Serkan", "İrem", "Barış", "Esra", "Kaan", "Deniz", "Cem", "Nazlı", "Uğur"];
    private static readonly string[] LastNames = ["Yılmaz", "Kaya", "Demir", "Çelik", "Şahin", "Arslan", "Koç", "Aydın", "Öztürk", "Kılıç", "Aslan", "Polat", "Güneş", "Aksoy", "Eren", "Yalçın", "Bulut", "Kurt", "Özdemir", "Taş", "Avcı", "Kaplan", "Keskin", "Yıldırım", "Özer", "Doğan", "Uslu", "Turan", "Karaca", "Ergin", "Sarı", "Bozkurt", "Güler", "Acar", "Sezer", "Çetin", "Başar"];
    private static readonly string[] MaintenanceTypes = ["Haftalık", "Aylık", "3 Aylık", "6 Aylık", "Yıllık", "Kestirimci", "Kalibrasyon", "Güvenlik Kontrolü"];
    private static readonly string[] TestTypes = ["Jeneratör Yük Transfer Testi", "UPS Otonomi Testi", "HVAC Performans Testi", "PLC I/O Doğrulama", "Yangın Algılama Senaryo Testi", "Aydınlatma Acil Durum Testi", "Pompa Debi Testi", "BMS Alarm Entegrasyon Testi"];

    public async Task SeedIfNeededAsync(CancellationToken cancellationToken = default)
    {
        if (await NeedsSeedingAsync(cancellationToken))
        {
            await SeedAsync(forceReset: true, cancellationToken);
        }
    }

    public async Task SeedAsync(bool forceReset, CancellationToken cancellationToken = default)
    {
        if (!forceReset && !await NeedsSeedingAsync(cancellationToken))
        {
            return;
        }

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        await ClearAsync(cancellationToken);

        var roles = BuildRoles();
        var locations = BuildLocations();
        var systems = BuildTechnicalSystems();
        var users = BuildUsers();
        var equipment = BuildEquipment(locations, systems);
        var faults = BuildFaults(equipment);
        var faultActions = BuildFaultActions(faults);
        var maintenancePlans = BuildMaintenancePlans(equipment);
        var maintenanceRecords = BuildMaintenanceRecords(maintenancePlans);
        var testPlans = BuildTestPlans(equipment);
        var testRecords = BuildTestRecords(testPlans);
        var handovers = BuildShiftHandovers();
        var shiftItems = BuildShiftItems(handovers, equipment, faults, maintenancePlans);
        var shiftAssignments = BuildShiftAssignments();
        var auditLogs = BuildAuditLogs(faults, maintenancePlans, testRecords, handovers, equipment);
        var notifications = BuildNotifications(faults, maintenancePlans, testRecords, handovers, equipment);

        dbContext.Roles.AddRange(roles);
        dbContext.Locations.AddRange(locations);
        dbContext.TechnicalSystems.AddRange(systems);
        dbContext.Users.AddRange(users);
        dbContext.Equipment.AddRange(equipment);
        dbContext.Faults.AddRange(faults);
        dbContext.FaultActions.AddRange(faultActions);
        dbContext.MaintenancePlans.AddRange(maintenancePlans);
        dbContext.MaintenanceRecords.AddRange(maintenanceRecords);
        dbContext.TestPlans.AddRange(testPlans);
        dbContext.TestRecords.AddRange(testRecords);
        dbContext.ShiftHandovers.AddRange(handovers);
        dbContext.ShiftItems.AddRange(shiftItems);
        dbContext.ShiftAssignments.AddRange(shiftAssignments);
        dbContext.AuditLogs.AddRange(auditLogs);
        dbContext.Notifications.AddRange(notifications);

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    private async Task<bool> NeedsSeedingAsync(CancellationToken cancellationToken)
    {
        if (!await dbContext.Users.AnyAsync(cancellationToken))
        {
            return true;
        }

        return await dbContext.Users.AnyAsync(x => x.Email.EndsWith("@demo.local"), cancellationToken)
            || await dbContext.Users.GroupBy(x => x.FullName).AnyAsync(group => group.Count() > 1, cancellationToken)
            || await dbContext.Equipment.AnyAsync(x => x.Description != null && (x.Description.Contains("Sentetik") || x.Description.Contains("demo") || x.Description.Contains("Demo")), cancellationToken)
            || await dbContext.Faults.AnyAsync(x => x.Description.Contains("Sentetik") || x.Description.Contains("demo") || x.Description.Contains("Demo"), cancellationToken);
    }

    private async Task ClearAsync(CancellationToken cancellationToken)
    {
        await dbContext.Notifications.ExecuteDeleteAsync(cancellationToken);
        await dbContext.AuditLogs.ExecuteDeleteAsync(cancellationToken);
        await dbContext.ShiftAssignments.ExecuteDeleteAsync(cancellationToken);
        await dbContext.ShiftItems.ExecuteDeleteAsync(cancellationToken);
        await dbContext.ShiftHandovers.ExecuteDeleteAsync(cancellationToken);
        await dbContext.TestRecords.ExecuteDeleteAsync(cancellationToken);
        await dbContext.TestPlans.ExecuteDeleteAsync(cancellationToken);
        await dbContext.MaintenanceRecords.ExecuteDeleteAsync(cancellationToken);
        await dbContext.MaintenancePlans.ExecuteDeleteAsync(cancellationToken);
        await dbContext.FaultActions.ExecuteDeleteAsync(cancellationToken);
        await dbContext.Faults.ExecuteDeleteAsync(cancellationToken);
        await dbContext.Equipment.ExecuteDeleteAsync(cancellationToken);
        await dbContext.TechnicalSystems.ExecuteDeleteAsync(cancellationToken);
        await dbContext.Locations.ExecuteDeleteAsync(cancellationToken);
        await dbContext.Users.ExecuteDeleteAsync(cancellationToken);
        await dbContext.Roles.ExecuteDeleteAsync(cancellationToken);
    }

    private static IReadOnlyList<Role> BuildRoles() =>
    [
        new() { Id = AdminRoleId, Name = "Admin", Description = "Sistem yöneticisi", IsSystemRole = true, CreatedAt = SeedCreatedAt },
        new() { Id = ManagerRoleId, Name = "Yönetici", Description = "Operasyonu ve raporları izler", IsSystemRole = true, CreatedAt = SeedCreatedAt },
        new() { Id = TechnicianRoleId, Name = "Teknik Personel", Description = "Arıza, bakım ve test işlemlerini yürütür", IsSystemRole = true, CreatedAt = SeedCreatedAt },
        new() { Id = OperatorRoleId, Name = "Operatör", Description = "Olay ve arıza kaydı oluşturur", IsSystemRole = true, CreatedAt = SeedCreatedAt },
        new() { Id = ReportRoleId, Name = "Rapor Kullanıcısı", Description = "Dashboard ve raporları görüntüler", IsSystemRole = true, CreatedAt = SeedCreatedAt }
    ];

    private static IReadOnlyList<Location> BuildLocations()
    {
        var locations = new List<Location>();
        for (var i = 1; i <= 120; i++)
        {
            var areaIndex = PositiveModulo(i - 1, AreaCodes.Length);
            var floor = i % 6 == 0 ? "Çatı" : i % 5 == 0 ? "Bodrum" : $"Kat {PositiveModulo(i, 4) + 1}";
            locations.Add(new Location
            {
                Id = LocationId(i),
                Code = $"LOC-{AreaCodes[areaIndex]}-{i:000}",
                Name = $"{AreaNames[areaIndex]} {floor} Bölge {i:000}",
                Type = LocationTypes[PositiveModulo(i, LocationTypes.Length)],
                Description = $"{AreaNames[areaIndex]} içinde operasyon, bakım ve arıza kayıtlarında kullanılan saha lokasyonu.",
                IsActive = i % 37 != 0,
                CreatedAt = DateTimeInRange(i, 7)
            });
        }

        return locations;
    }

    private static IReadOnlyList<TechnicalSystem> BuildTechnicalSystems()
    {
        var systems = new List<TechnicalSystem>();
        for (var i = 1; i <= 110; i++)
        {
            var familyIndex = PositiveModulo(i - 1, SystemFamilies.Length);
            systems.Add(new TechnicalSystem
            {
                Id = TechnicalSystemId(i),
                Code = $"SYS-{SystemCodes[familyIndex]}-{i:000}",
                Name = $"{SystemFamilies[familyIndex]} Altyapısı {i:000}",
                Description = $"{SystemFamilies[familyIndex]} izleme, bakım ve raporlama kırılımı.",
                IsActive = i % 41 != 0,
                CreatedAt = DateTimeInRange(i * 2, 8)
            });
        }

        return systems;
    }

    private static IReadOnlyList<User> BuildUsers()
    {
        const string sharedPasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=";
        var users = new List<User>
        {
            new() { Id = UserId(1), RoleId = AdminRoleId, FullName = "Admin Kullanıcı", Username = "admin", Email = "admin@techops.local", PasswordHash = sharedPasswordHash, Title = "Sistem Yöneticisi", Department = "Bilgi Teknolojileri", IsActive = true, LastLoginAt = DataEnd.AddHours(-2), CreatedAt = SeedCreatedAt },
            new() { Id = UserId(2), RoleId = ManagerRoleId, FullName = "Teknik Operasyon Müdürü", Username = "yonetici", Email = "yonetici@techops.local", PasswordHash = sharedPasswordHash, Title = "Teknik Operasyon Müdürü", Department = "Teknik Operasyon", IsActive = true, LastLoginAt = DataEnd.AddHours(-5), CreatedAt = SeedCreatedAt }
        };

        for (var i = 1; i <= 75; i++)
        {
            var index = i + 2;
            users.Add(new User
            {
                Id = UserId(index),
                RoleId = TechnicianRoleId,
                FullName = PersonName(i),
                Username = $"teknik{i}",
                Email = $"teknik{i}@techops.local",
                PasswordHash = sharedPasswordHash,
                Title = i % 8 == 0 ? "Kıdemli Teknik Personel" : "Teknik Personel",
                Department = TechnicalDepartments[PositiveModulo(i, TechnicalDepartments.Length)],
                IsActive = i % 29 != 0,
                LastLoginAt = DataEnd.AddHours(-PositiveModulo(i * 7, 240)),
                CreatedAt = DateTimeInRange(i, 9)
            });
        }

        for (var i = 1; i <= 35; i++)
        {
            var index = i + 77;
            users.Add(new User
            {
                Id = UserId(index),
                RoleId = OperatorRoleId,
                FullName = PersonName(i + 100),
                Username = $"operator{i}",
                Email = $"operator{i}@techops.local",
                PasswordHash = sharedPasswordHash,
                Title = "Operatör",
                Department = i % 2 == 0 ? "Terminal Operasyon" : "Saha Operasyon",
                IsActive = i % 31 != 0,
                LastLoginAt = DataEnd.AddHours(-PositiveModulo(i * 11, 180)),
                CreatedAt = DateTimeInRange(i + 90, 9)
            });
        }

        for (var i = 1; i <= 13; i++)
        {
            var index = i + 112;
            users.Add(new User
            {
                Id = UserId(index),
                RoleId = ReportRoleId,
                FullName = i == 1 ? "Rapor Kullanıcısı" : PersonName(i + 200),
                Username = i == 1 ? "raporcu" : $"raporcu{i}",
                Email = i == 1 ? "raporcu@techops.local" : $"raporcu{i}@techops.local",
                PasswordHash = sharedPasswordHash,
                Title = "Rapor Uzmanı",
                Department = "Operasyon Analiz",
                IsActive = true,
                LastLoginAt = DataEnd.AddHours(-PositiveModulo(i * 13, 300)),
                CreatedAt = DateTimeInRange(i + 130, 10)
            });
        }

        return users;
    }

    private static IReadOnlyList<Equipment> BuildEquipment(IReadOnlyList<Location> locations, IReadOnlyList<TechnicalSystem> systems)
    {
        var equipment = new List<Equipment>();
        for (var i = 1; i <= 240; i++)
        {
            var familyIndex = PositiveModulo(i - 1, EquipmentPrefixes.Length);
            var status = i % 53 == 0 ? EquipmentStatus.Passive : i % 19 == 0 ? EquipmentStatus.Faulted : i % 11 == 0 ? EquipmentStatus.Maintenance : EquipmentStatus.Active;
            var location = locations[PositiveModulo(i * 7, locations.Count)];
            var system = systems[PositiveModulo(i * 5, systems.Count)];
            equipment.Add(new Equipment
            {
                Id = EquipmentId(i),
                LocationId = location.Id,
                TechnicalSystemId = system.Id,
                Code = $"EQ-{EquipmentPrefixes[familyIndex]}-{i:0000}",
                Name = $"{EquipmentPrefixes[familyIndex]}-{AreaCodes[PositiveModulo(i, AreaCodes.Length)]}-{i:000}",
                Brand = BrandFamilies[familyIndex],
                Model = ModelFamilies[familyIndex],
                SerialNo = $"SN-{AreaCodes[PositiveModulo(i, AreaCodes.Length)]}-{2020 + PositiveModulo(i, 6)}-{i:00000}",
                Status = status,
                CommissionedAt = new DateOnly(2016 + PositiveModulo(i, 9), PositiveModulo(i * 2, 12) + 1, PositiveModulo(i * 5, 25) + 1),
                Description = $"{location.Name} lokasyonunda izlenen {system.Name.ToLowerInvariant()} ekipmanı.",
                IsActive = status != EquipmentStatus.Passive,
                CreatedAt = DateTimeInRange(i * 3, 8),
                UpdatedAt = status is EquipmentStatus.Faulted or EquipmentStatus.Maintenance ? DateTimeInRange(i * 7, 14) : null
            });
        }

        return equipment;
    }

    private static IReadOnlyList<Fault> BuildFaults(IReadOnlyList<Equipment> equipment)
    {
        var faults = new List<Fault>();
        var sources = new[] { FaultSource.ScadaObservation, FaultSource.HoneywellEbiObservation, FaultSource.FieldObservation, FaultSource.OperatorReport, FaultSource.MaintenanceFinding };
        for (var i = 1; i <= 380; i++)
        {
            var equipmentItem = equipment[PositiveModulo(i * 11, equipment.Count)];
            var createdAt = i > 340 ? RecentDateTime(i, 7 + PositiveModulo(i, 12)) : DateTimeInRange(i * 17, 7 + PositiveModulo(i, 12));
            var isRecent = createdAt >= DataEnd.AddDays(-35);
            var status = FaultStatusFor(i, isRecent);
            var priority = PriorityFor(i);
            var assignedAt = status == FaultStatus.New ? (DateTime?)null : createdAt.AddMinutes(15 + PositiveModulo(i * 3, 90));
            var resolvedAt = status is FaultStatus.Resolved or FaultStatus.Closed ? assignedAt?.AddHours(2 + PositiveModulo(i, 18)).AddMinutes(PositiveModulo(i * 7, 55)) : null;
            var closedAt = status == FaultStatus.Closed ? resolvedAt?.AddHours(1 + PositiveModulo(i, 8)) : null;

            faults.Add(new Fault
            {
                Id = FaultId(i),
                FaultNo = $"ARZ-{createdAt.Year}-{i:0000}",
                EquipmentId = equipmentItem.Id,
                LocationId = equipmentItem.LocationId,
                TechnicalSystemId = equipmentItem.TechnicalSystemId,
                CreatedByUserId = i % 4 == 0 ? UserId(1) : OperatorUserIdFor(i),
                AssignedToUserId = assignedAt.HasValue ? TechnicianUserIdFor(i) : null,
                ResolvedByUserId = resolvedAt.HasValue ? TechnicianUserIdFor(i + 2) : null,
                ClosedByUserId = closedAt.HasValue ? UserId(2) : null,
                Source = sources[PositiveModulo(i, sources.Length)],
                Priority = priority,
                Status = status,
                Description = FaultDescriptionFor(equipmentItem, priority, i),
                ResolutionDescription = resolvedAt.HasValue ? FaultResolutionFor(equipmentItem, i) : null,
                WaitingReason = status == FaultStatus.Waiting ? WaitingReasonFor(i) : null,
                AssignedAt = assignedAt,
                ResolvedAt = resolvedAt,
                ClosedAt = closedAt,
                CreatedAt = createdAt,
                UpdatedAt = closedAt ?? resolvedAt ?? assignedAt
            });
        }

        return faults;
    }

    private static IReadOnlyList<FaultAction> BuildFaultActions(IReadOnlyList<Fault> faults)
    {
        var actions = new List<FaultAction>();
        var actionIndex = 1;
        foreach (var fault in faults)
        {
            actions.Add(new FaultAction
            {
                Id = FaultActionId(actionIndex++),
                FaultId = fault.Id,
                UserId = fault.CreatedByUserId,
                ActionType = "Created",
                Note = "Arıza kaydı operasyon ekranından oluşturuldu.",
                Metadata = "{}",
                CreatedAt = fault.CreatedAt
            });

            if (fault.AssignedToUserId.HasValue && fault.AssignedAt.HasValue)
            {
                actions.Add(new FaultAction
                {
                    Id = FaultActionId(actionIndex++),
                    FaultId = fault.Id,
                    UserId = UserId(2),
                    ActionType = "Assigned",
                    OldStatus = FaultStatus.New,
                    NewStatus = FaultStatus.Assigned,
                    Note = "Sorumlu teknik personel atandı.",
                    Metadata = "{}",
                    CreatedAt = fault.AssignedAt.Value
                });
            }

            if (fault.Status is FaultStatus.InReview or FaultStatus.InProgress or FaultStatus.Waiting or FaultStatus.Resolved or FaultStatus.Closed)
            {
                actions.Add(new FaultAction
                {
                    Id = FaultActionId(actionIndex++),
                    FaultId = fault.Id,
                    UserId = fault.AssignedToUserId ?? TechnicianUserIdFor(actionIndex),
                    ActionType = "StatusChanged",
                    OldStatus = FaultStatus.Assigned,
                    NewStatus = fault.Status is FaultStatus.Closed ? FaultStatus.Resolved : fault.Status,
                    Note = FaultProgressNoteFor(fault.Status),
                    Metadata = "{}",
                    CreatedAt = (fault.AssignedAt ?? fault.CreatedAt).AddMinutes(45)
                });
            }

            if (fault.ResolvedAt.HasValue)
            {
                actions.Add(new FaultAction
                {
                    Id = FaultActionId(actionIndex++),
                    FaultId = fault.Id,
                    UserId = fault.ResolvedByUserId ?? TechnicianUserIdFor(actionIndex),
                    ActionType = "Resolved",
                    OldStatus = FaultStatus.InProgress,
                    NewStatus = FaultStatus.Resolved,
                    Note = fault.ResolutionDescription,
                    Metadata = "{}",
                    CreatedAt = fault.ResolvedAt.Value
                });
            }

            if (fault.ClosedAt.HasValue)
            {
                actions.Add(new FaultAction
                {
                    Id = FaultActionId(actionIndex++),
                    FaultId = fault.Id,
                    UserId = fault.ClosedByUserId ?? UserId(2),
                    ActionType = "Closed",
                    OldStatus = FaultStatus.Resolved,
                    NewStatus = FaultStatus.Closed,
                    Note = "Yönetici kontrolü sonrası kayıt kapatıldı.",
                    Metadata = "{}",
                    CreatedAt = fault.ClosedAt.Value
                });
            }
        }

        return actions;
    }

    private static IReadOnlyList<MaintenancePlan> BuildMaintenancePlans(IReadOnlyList<Equipment> equipment)
    {
        var plans = new List<MaintenancePlan>();
        for (var i = 1; i <= 280; i++)
        {
            var equipmentItem = equipment[PositiveModulo(i * 13, equipment.Count)];
            var plannedDate = i > 250 ? RecentDateOnly(i) : DateOnlyInRange(i * 19);
            var status = MaintenanceStatusFor(i, plannedDate);
            var startedAt = status is MaintenanceStatus.Started or MaintenanceStatus.Completed ? plannedDate.ToDateTime(new TimeOnly(7 + PositiveModulo(i, 8), PositiveModulo(i * 5, 50)), DateTimeKind.Utc) : (DateTime?)null;
            var completedAt = status == MaintenanceStatus.Completed ? startedAt?.AddHours(1 + PositiveModulo(i, 6)).AddMinutes(PositiveModulo(i * 7, 45)) : null;
            var maintenanceType = MaintenanceTypes[PositiveModulo(i, MaintenanceTypes.Length)];

            plans.Add(new MaintenancePlan
            {
                Id = MaintenancePlanId(i),
                PlanNo = $"BKM-{plannedDate.Year}-{i:0000}",
                EquipmentId = equipmentItem.Id,
                ResponsibleUserId = TechnicianUserIdFor(i),
                CreatedByUserId = UserId(2),
                MaintenanceType = maintenanceType,
                PlannedDate = plannedDate,
                Frequency = maintenanceType,
                Priority = PriorityFor(i + 5),
                Status = status,
                Description = MaintenanceDescriptionFor(equipmentItem, maintenanceType),
                StartedAt = startedAt,
                CompletedAt = completedAt,
                CreatedAt = plannedDate.AddDays(-PositiveModulo(i, 21)).ToDateTime(new TimeOnly(9, 0), DateTimeKind.Utc),
                UpdatedAt = completedAt ?? startedAt
            });
        }

        return plans;
    }

    private static IReadOnlyList<MaintenanceRecord> BuildMaintenanceRecords(IReadOnlyList<MaintenancePlan> plans)
    {
        var records = new List<MaintenanceRecord>();
        var completedPlans = plans.Where(x => x.CompletedAt.HasValue).ToList();
        for (var i = 1; i <= 210; i++)
        {
            var plan = completedPlans[PositiveModulo(i * 3, completedPlans.Count)];
            var completedAt = plan.CompletedAt!.Value.AddMinutes(PositiveModulo(i * 11, 45));
            records.Add(new MaintenanceRecord
            {
                Id = MaintenanceRecordId(i),
                MaintenancePlanId = plan.Id,
                EquipmentId = plan.EquipmentId,
                PerformedByUserId = plan.ResponsibleUserId,
                MaintenanceType = plan.MaintenanceType,
                StartedAt = plan.StartedAt,
                CompletedAt = completedAt,
                ResultStatus = i % 18 == 0 ? MaintenanceResultStatus.Failed : i % 11 == 0 ? MaintenanceResultStatus.PartiallyCompleted : MaintenanceResultStatus.Completed,
                Description = MaintenanceRecordDescriptionFor(i),
                UsedMaterials = MaintenanceMaterialsFor(i),
                ChecklistJson = ChecklistFor(i),
                CreatedAt = completedAt,
                UpdatedAt = completedAt.AddMinutes(PositiveModulo(i, 30))
            });
        }

        return records;
    }

    private static IReadOnlyList<TestPlan> BuildTestPlans(IReadOnlyList<Equipment> equipment)
    {
        var plans = new List<TestPlan>();
        for (var i = 1; i <= 250; i++)
        {
            var equipmentItem = equipment[PositiveModulo(i * 17, equipment.Count)];
            var plannedDate = i > 225 ? RecentDateOnly(i + 20) : DateOnlyInRange(i * 23);
            var status = TestPlanStatusFor(i, plannedDate);
            var testType = TestTypes[PositiveModulo(i, TestTypes.Length)];
            plans.Add(new TestPlan
            {
                Id = TestPlanId(i),
                EquipmentId = equipmentItem.Id,
                ResponsibleUserId = TechnicianUserIdFor(i + 3),
                TestType = testType,
                PlannedDate = plannedDate,
                Frequency = i % 4 == 0 ? "Haftalık" : i % 4 == 1 ? "Aylık" : i % 4 == 2 ? "3 Aylık" : "6 Aylık",
                Status = status,
                Description = TestPlanDescriptionFor(testType),
                CreatedAt = plannedDate.AddDays(-PositiveModulo(i, 14)).ToDateTime(new TimeOnly(10, 0), DateTimeKind.Utc),
                UpdatedAt = status == TestPlanStatus.Completed ? plannedDate.ToDateTime(new TimeOnly(15, 0), DateTimeKind.Utc) : null
            });
        }

        return plans;
    }

    private static IReadOnlyList<TestRecord> BuildTestRecords(IReadOnlyList<TestPlan> plans)
    {
        var records = new List<TestRecord>();
        var eligiblePlans = plans.Where(x => x.Status is TestPlanStatus.Completed or TestPlanStatus.Delayed).ToList();
        for (var i = 1; i <= 220; i++)
        {
            var plan = eligiblePlans[PositiveModulo(i * 5, eligiblePlans.Count)];
            var testDate = plan.PlannedDate.ToDateTime(new TimeOnly(8 + PositiveModulo(i, 9), PositiveModulo(i * 7, 55)), DateTimeKind.Utc);
            var result = TestResultFor(i);
            records.Add(new TestRecord
            {
                Id = TestRecordId(i),
                TestPlanId = plan.Id,
                EquipmentId = plan.EquipmentId,
                TestedByUserId = TechnicianUserIdFor(i + 5),
                TestDate = testDate,
                TestType = plan.TestType,
                DurationMinutes = 20 + PositiveModulo(i * 4, 85),
                Result = result,
                AbnormalCondition = result is TestResult.Failed or TestResult.RetestRequired ? AbnormalConditionFor(plan.TestType) : null,
                Description = TestRecordDescriptionFor(plan.TestType, result),
                CreatedAt = testDate,
                UpdatedAt = testDate.AddMinutes(10 + PositiveModulo(i, 40))
            });
        }

        return records;
    }

    private static IReadOnlyList<ShiftHandover> BuildShiftHandovers()
    {
        var handovers = new List<ShiftHandover>();
        var shiftTypes = new[] { ShiftType.Morning, ShiftType.Evening, ShiftType.Night };
        for (var i = 1; i <= 240; i++)
        {
            var shiftDate = i > 210 ? RecentDateOnly(i) : DateOnlyInRange(i * 11);
            var shiftType = shiftTypes[PositiveModulo(i, shiftTypes.Length)];
            handovers.Add(new ShiftHandover
            {
                Id = ShiftHandoverId(i),
                HandoverNo = $"VDT-{shiftDate.Year}-{i:0000}",
                ShiftType = shiftType,
                ShiftDate = shiftDate,
                HandoverFromUserId = TechnicianUserIdFor(i),
                HandoverToUserId = TechnicianUserIdFor(i + 1),
                Summary = ShiftSummaryFor(i, shiftType),
                CriticalNotes = i % 6 == 0 ? "Kritik güç odası, UPS alarm trendi ve açık bakım penceresi sonraki vardiyada tekrar kontrol edilecek." : "Rutin saha turu, alarm listesi ve açık iş maddeleri sonraki vardiyaya aktarıldı.",
                CreatedAt = shiftDate.ToDateTime(new TimeOnly(shiftType == ShiftType.Morning ? 8 : shiftType == ShiftType.Evening ? 16 : 23, PositiveModulo(i * 3, 45)), DateTimeKind.Utc)
            });
        }

        return handovers;
    }

    private static IReadOnlyList<ShiftItem> BuildShiftItems(IReadOnlyList<ShiftHandover> handovers, IReadOnlyList<Equipment> equipment, IReadOnlyList<Fault> faults, IReadOnlyList<MaintenancePlan> maintenancePlans)
    {
        var items = new List<ShiftItem>();
        var itemTypes = new[] { ShiftItemType.OpenFault, ShiftItemType.OngoingWork, ShiftItemType.EquipmentToWatch, ShiftItemType.PendingMaintenance, ShiftItemType.CriticalNote };
        var openFaults = faults.Where(x => x.Status is not FaultStatus.Closed and not FaultStatus.Resolved).ToList();
        var openMaintenancePlans = maintenancePlans.Where(x => x.Status is not MaintenanceStatus.Completed and not MaintenanceStatus.Cancelled).ToList();

        for (var i = 1; i <= 430; i++)
        {
            var handover = i > 390 ? handovers[^(PositiveModulo(i, Math.Min(30, handovers.Count)) + 1)] : handovers[PositiveModulo(i * 2, handovers.Count)];
            var itemType = itemTypes[PositiveModulo(i, itemTypes.Length)];
            var equipmentItem = equipment[PositiveModulo(i * 19, equipment.Count)];
            var fault = itemType == ShiftItemType.OpenFault && openFaults.Count > 0 ? openFaults[PositiveModulo(i, openFaults.Count)] : null;
            var maintenancePlan = itemType == ShiftItemType.PendingMaintenance && openMaintenancePlans.Count > 0 ? openMaintenancePlans[PositiveModulo(i * 2, openMaintenancePlans.Count)] : null;
            var createdAt = handover.CreatedAt.AddMinutes(PositiveModulo(i * 7, 90));
            var isCompleted = handover.ShiftDate < DataEndDate.AddDays(-14) && i % 5 != 0;
            items.Add(new ShiftItem
            {
                Id = ShiftItemId(i),
                ShiftHandoverId = handover.Id,
                ItemType = itemType,
                Title = ShiftItemTitleFor(itemType, fault, maintenancePlan, equipmentItem),
                Description = ShiftItemDescriptionFor(itemType, equipmentItem),
                FaultId = fault?.Id,
                EquipmentId = fault?.EquipmentId ?? maintenancePlan?.EquipmentId ?? (itemType == ShiftItemType.CriticalNote ? null : equipmentItem.Id),
                MaintenancePlanId = maintenancePlan?.Id,
                Priority = PriorityFor(i + 9),
                IsCompleted = isCompleted,
                CreatedAt = createdAt,
                UpdatedAt = isCompleted ? createdAt.AddHours(1 + PositiveModulo(i, 7)) : null
            });
        }

        return items;
    }

    private static IReadOnlyList<ShiftAssignment> BuildShiftAssignments()
    {
        var assignments = new List<ShiftAssignment>();
        var assignmentId = 1;
        var selectedDays = 320;
        var shiftTypes = new[] { ShiftType.Morning, ShiftType.Evening, ShiftType.Night };
        for (var dayIndex = 0; dayIndex < selectedDays; dayIndex++)
        {
            var dayOffset = (int)Math.Round(dayIndex * (TotalDays - 1m) / (selectedDays - 1));
            var shiftDate = DataStartDate.AddDays(dayOffset);
            for (var shiftIndex = 0; shiftIndex < shiftTypes.Length; shiftIndex++)
            {
                assignments.Add(new ShiftAssignment
                {
                    Id = ShiftAssignmentId(assignmentId),
                    UserId = TechnicianUserIdFor(dayIndex + shiftIndex * 17),
                    CreatedByUserId = UserId(2),
                    ShiftType = shiftTypes[shiftIndex],
                    ShiftDate = shiftDate,
                    Notes = shiftIndex == 2 && dayIndex % 9 == 0 ? "Gece vardiyasında kritik güç odası saha turu önceliklendirilecek." : null,
                    CreatedAt = shiftDate.AddDays(-PositiveModulo(dayIndex, 10)).ToDateTime(new TimeOnly(9, PositiveModulo(dayIndex * 3, 50)), DateTimeKind.Utc),
                    UpdatedAt = dayIndex % 12 == 0 ? shiftDate.ToDateTime(new TimeOnly(11, 0), DateTimeKind.Utc) : null
                });
                assignmentId++;
            }
        }

        return assignments;
    }

    private static IReadOnlyList<AuditLog> BuildAuditLogs(IReadOnlyList<Fault> faults, IReadOnlyList<MaintenancePlan> maintenancePlans, IReadOnlyList<TestRecord> testRecords, IReadOnlyList<ShiftHandover> handovers, IReadOnlyList<Equipment> equipment)
    {
        var logs = new List<AuditLog>();
        var actions = new[] { "Create", "Update", "StatusChange", "Export", "View", "Assign", "Complete" };
        for (var i = 1; i <= 650; i++)
        {
            var target = AuditTargetFor(i, faults, maintenancePlans, testRecords, handovers, equipment);
            logs.Add(new AuditLog
            {
                Id = AuditLogId(i),
                UserId = i % 8 == 0 ? null : ActiveUserIdFor(i),
                EntityName = target.EntityName,
                EntityId = target.EntityId,
                Action = actions[PositiveModulo(i, actions.Length)],
                OldValues = i % 5 == 0 ? "{\"status\":\"Previous\"}" : "{}",
                NewValues = i % 5 == 0 ? "{\"status\":\"Updated\"}" : "{}",
                IpAddress = $"10.{PositiveModulo(i, 40)}.{PositiveModulo(i * 3, 240)}.{PositiveModulo(i * 7, 240)}",
                UserAgent = i % 3 == 0 ? "TechOpsPortal/1.0" : "TechOpsMobile/1.0",
                CreatedAt = DateTimeInRange(i * 29, 6 + PositiveModulo(i, 14))
            });
        }

        return logs;
    }

    private static IReadOnlyList<Notification> BuildNotifications(IReadOnlyList<Fault> faults, IReadOnlyList<MaintenancePlan> maintenancePlans, IReadOnlyList<TestRecord> testRecords, IReadOnlyList<ShiftHandover> handovers, IReadOnlyList<Equipment> equipment)
    {
        var notifications = new List<Notification>();
        var templates = new (NotificationType Type, string Title, string Message, string Entity)[]
        {
            (NotificationType.Critical, "Kritik arıza eskalasyonu", "Kritik öncelikli arıza için müdahale süresi hedefe yaklaştı. Atama, yedek güç ve saha erişim durumunu kontrol edin.", "Fault"),
            (NotificationType.Warning, "Bakım planı yaklaşan son tarih", "Planlanan bakım penceresi yaklaşıyor. Sorumlu ekip, malzeme ve çalışma izni hazırlığını doğrulayın.", "MaintenancePlan"),
            (NotificationType.Info, "Operasyon raporu hazır", "Güncel operasyon özeti Excel ve PDF formatlarında indirilmeye hazır.", "Report"),
            (NotificationType.Warning, "Vardiya devrinde açık iş var", "Son vardiya devrinde tamamlanmamış iş maddeleri bulunuyor. Kritik notlar sonraki vardiyada takip edilmeli.", "ShiftHandover"),
            (NotificationType.Critical, "Başarısız test sonucu", "Periyodik testte limit dışı değer görüldü. Tekrar test ve düzeltici aksiyon planı oluşturulmalı.", "TestRecord"),
            (NotificationType.Info, "Ekipman geçmişi güncellendi", "Ekipmanın arıza, bakım ve test geçmişi yeni kayıtlarla güncellendi.", "Equipment"),
            (NotificationType.Warning, "Tekrarlayan arıza eğilimi", "Aynı ekipmanda kısa aralıklarla tekrar eden arıza kayıtları tespit edildi. Kök neden analizi önerilir.", "Fault")
        };

        for (var i = 1; i <= 420; i++)
        {
            var template = templates[PositiveModulo(i, templates.Length)];
            notifications.Add(new Notification
            {
                Id = NotificationId(i),
                UserId = ActiveUserIdFor(i),
                Title = template.Title,
                Message = template.Message,
                Type = template.Type,
                RelatedEntityName = template.Entity,
                RelatedEntityId = NotificationTargetIdFor(template.Entity, i, faults, maintenancePlans, testRecords, handovers, equipment),
                IsRead = i % 4 != 0,
                CreatedAt = DateTimeInRange(i * 31, 8 + PositiveModulo(i, 10))
            });
        }

        return notifications;
    }

    private static (string EntityName, Guid EntityId) AuditTargetFor(int seed, IReadOnlyList<Fault> faults, IReadOnlyList<MaintenancePlan> maintenancePlans, IReadOnlyList<TestRecord> testRecords, IReadOnlyList<ShiftHandover> handovers, IReadOnlyList<Equipment> equipment)
    {
        return PositiveModulo(seed, 5) switch
        {
            0 => ("Fault", faults[PositiveModulo(seed, faults.Count)].Id),
            1 => ("MaintenancePlan", maintenancePlans[PositiveModulo(seed * 2, maintenancePlans.Count)].Id),
            2 => ("TestRecord", testRecords[PositiveModulo(seed * 3, testRecords.Count)].Id),
            3 => ("ShiftHandover", handovers[PositiveModulo(seed * 4, handovers.Count)].Id),
            _ => ("Equipment", equipment[PositiveModulo(seed * 5, equipment.Count)].Id)
        };
    }

    private static Guid? NotificationTargetIdFor(string entity, int seed, IReadOnlyList<Fault> faults, IReadOnlyList<MaintenancePlan> maintenancePlans, IReadOnlyList<TestRecord> testRecords, IReadOnlyList<ShiftHandover> handovers, IReadOnlyList<Equipment> equipment)
    {
        return entity switch
        {
            "Fault" => faults[PositiveModulo(seed, faults.Count)].Id,
            "MaintenancePlan" => maintenancePlans[PositiveModulo(seed, maintenancePlans.Count)].Id,
            "TestRecord" => testRecords[PositiveModulo(seed, testRecords.Count)].Id,
            "ShiftHandover" => handovers[PositiveModulo(seed, handovers.Count)].Id,
            "Equipment" => equipment[PositiveModulo(seed, equipment.Count)].Id,
            _ => null
        };
    }

    private static FaultStatus FaultStatusFor(int seed, bool isRecent)
    {
        if (isRecent)
        {
            return PositiveModulo(seed, 6) switch
            {
                0 => FaultStatus.New,
                1 => FaultStatus.Assigned,
                2 => FaultStatus.InProgress,
                3 => FaultStatus.Waiting,
                4 => FaultStatus.InReview,
                _ => FaultStatus.Resolved
            };
        }

        return PositiveModulo(seed, 10) switch
        {
            0 => FaultStatus.Resolved,
            1 => FaultStatus.Waiting,
            2 => FaultStatus.InProgress,
            _ => FaultStatus.Closed
        };
    }

    private static MaintenanceStatus MaintenanceStatusFor(int seed, DateOnly plannedDate)
    {
        if (plannedDate >= DataEndDate.AddDays(-20))
        {
            return PositiveModulo(seed, 5) switch
            {
                0 => MaintenanceStatus.Planned,
                1 => MaintenanceStatus.Started,
                2 => MaintenanceStatus.Delayed,
                _ => MaintenanceStatus.Completed
            };
        }

        return PositiveModulo(seed, 12) switch
        {
            0 => MaintenanceStatus.Delayed,
            1 => MaintenanceStatus.Cancelled,
            _ => MaintenanceStatus.Completed
        };
    }

    private static TestPlanStatus TestPlanStatusFor(int seed, DateOnly plannedDate)
    {
        if (plannedDate >= DataEndDate.AddDays(-20))
        {
            return PositiveModulo(seed, 5) switch
            {
                0 => TestPlanStatus.Planned,
                1 => TestPlanStatus.Delayed,
                2 => TestPlanStatus.Cancelled,
                _ => TestPlanStatus.Completed
            };
        }

        return PositiveModulo(seed, 13) switch
        {
            0 => TestPlanStatus.Delayed,
            1 => TestPlanStatus.Cancelled,
            _ => TestPlanStatus.Completed
        };
    }

    private static FaultPriority PriorityFor(int seed) => PositiveModulo(seed, 20) switch
    {
        0 or 1 => FaultPriority.Critical,
        2 or 3 or 4 or 5 => FaultPriority.High,
        6 or 7 or 8 or 9 or 10 or 11 or 12 => FaultPriority.Medium,
        _ => FaultPriority.Low
    };

    private static TestResult TestResultFor(int seed) => PositiveModulo(seed, 12) switch
    {
        0 => TestResult.Failed,
        1 => TestResult.RetestRequired,
        2 or 3 => TestResult.ConditionalSuccess,
        _ => TestResult.Success
    };

    private static string FaultDescriptionFor(Equipment equipment, FaultPriority priority, int seed)
    {
        var prefix = priority == FaultPriority.Critical ? "Kritik alarm" : priority == FaultPriority.High ? "Yüksek öncelikli uyarı" : "Operasyon uyarısı";
        var details = new[]
        {
            "SCADA ekranında kısa süreli iletişim kesintisi izlendi.",
            "Saha turunda normal dışı titreşim ve ses bildirildi.",
            "Performans değeri kabul aralığının dışına çıktı.",
            "Besleme sıcaklığı hedef değere geç ulaştı.",
            "Kontaktör ve pano içi sıcaklık değeri yükseldi.",
            "Alarm tekrarı vardiya boyunca takip gerektiriyor."
        };
        return $"{prefix}: {equipment.Code} ekipmanında {details[PositiveModulo(seed, details.Length)]}";
    }

    private static string FaultResolutionFor(Equipment equipment, int seed)
    {
        var resolutions = new[]
        {
            "Klemens sıkılık kontrolü yapıldı, alarm tekrarı görülmedi.",
            "Sensör okuması doğrulandı ve kalibrasyon değeri güncellendi.",
            "Filtre ve hava akışı kontrol edildi, değerler normal aralığa döndü.",
            "Enerji besleme hattı ölçümleri tamamlandı, bağlantı noktaları güvence altına alındı.",
            "Kontrol yazılımı yeniden başlatıldı ve haberleşme stabil hale geldi."
        };
        return $"{equipment.Code} için {resolutions[PositiveModulo(seed, resolutions.Length)]}";
    }

    private static string WaitingReasonFor(int seed)
    {
        var reasons = new[]
        {
            "Yedek parça temini bekleniyor.",
            "Operasyon yoğunluğu nedeniyle çalışma penceresi planlanıyor.",
            "Yetkili servis saha erişimi için onay bekleniyor.",
            "Enerji kesinti izni ve iş güvenliği formu bekleniyor."
        };
        return reasons[PositiveModulo(seed, reasons.Length)];
    }

    private static string FaultProgressNoteFor(FaultStatus status) => status switch
    {
        FaultStatus.InReview => "Kök neden analizi için ölçüm ve alarm geçmişi inceleniyor.",
        FaultStatus.InProgress => "Saha müdahalesi başladı, teknik ekip ölçümleri sürdürüyor.",
        FaultStatus.Waiting => "İş emri beklemeye alındı, gerekli kaynak planlanıyor.",
        FaultStatus.Resolved or FaultStatus.Closed => "Müdahale tamamlandı, değerler izleme aralığına alındı.",
        _ => "Arıza durumu güncellendi."
    };

    private static string MaintenanceDescriptionFor(Equipment equipment, string maintenanceType) => $"{equipment.Code} için {maintenanceType.ToLowerInvariant()} bakım kapsamında görsel kontrol, temizlik, bağlantı sıkılık kontrolü ve fonksiyon doğrulaması yapılacak.";

    private static string MaintenanceRecordDescriptionFor(int seed)
    {
        var descriptions = new[]
        {
            "Bakım adımları tamamlandı, çalışma değerleri kabul aralığında kaydedildi.",
            "Filtre ve pano içi temizlik yapıldı, gevşek bağlantı tespit edilmedi.",
            "Fonksiyon testi tamamlandı, alarm geçmişi kontrol edildi.",
            "Saha etiketi ve bakım formu güncellendi, takip gerektiren bulgu yok.",
            "Kısmi bakım tamamlandı, yedek parça sonrası tekrar kontrol planlandı."
        };
        return descriptions[PositiveModulo(seed, descriptions.Length)];
    }

    private static string MaintenanceMaterialsFor(int seed)
    {
        var materials = new[]
        {
            "Kontrol formu, pano temizlik spreyi",
            "Filtre seti, kablo etiketi, temizlik bezi",
            "Sigorta etiketi, klemens işaretleme aparatı",
            "Yağ numune kabı, yakıt seviye formu",
            "Sensör kalibrasyon etiketi"
        };
        return materials[PositiveModulo(seed, materials.Length)];
    }

    private static string ChecklistFor(int seed) => seed % 11 == 0
        ? "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi kısmi tamamlandı.\",\"IsChecked\":true},{\"Text\":\"Tekrar kontrol planlandı.\",\"IsChecked\":false}]"
        : "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Bağlantılar kontrol edildi.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi tamamlandı.\",\"IsChecked\":true}]";

    private static string TestPlanDescriptionFor(string testType) => $"{testType} için ölçüm, alarm ve senaryo doğrulaması planlandı.";

    private static string AbnormalConditionFor(string testType) => testType.Contains("UPS", StringComparison.OrdinalIgnoreCase)
        ? "Otonomi süresi kabul limitine yakın ölçüldü."
        : testType.Contains("HVAC", StringComparison.OrdinalIgnoreCase)
            ? "Besleme havası sıcaklığı hedef değere geç ulaştı."
            : "Test sırasında limit dışı veya tekrar doğrulama gerektiren değer görüldü.";

    private static string TestRecordDescriptionFor(string testType, TestResult result) => result switch
    {
        TestResult.Success => $"{testType} başarıyla tamamlandı, ölçüm değerleri kabul aralığında.",
        TestResult.ConditionalSuccess => $"{testType} şartlı başarılı tamamlandı, sonraki bakımda tekrar izleme önerildi.",
        TestResult.Failed => $"{testType} başarısız sonuçlandı, düzeltici aksiyon açılması gerekiyor.",
        _ => $"{testType} için tekrar test planlanmalı."
    };

    private static string ShiftSummaryFor(int seed, ShiftType shiftType)
    {
        var shiftLabel = shiftType == ShiftType.Morning ? "Sabah" : shiftType == ShiftType.Evening ? "Akşam" : "Gece";
        var summaries = new[]
        {
            $"{shiftLabel} vardiyasında açık arızalar, bakım pencereleri ve alarm listesi kontrol edildi.",
            $"{shiftLabel} vardiyasında kritik güç odası saha turu tamamlandı ve takip notları aktarıldı.",
            $"{shiftLabel} vardiyasında HVAC performans değerleri, UPS alarmları ve devam eden işler devredildi.",
            $"{shiftLabel} vardiyasında planlı bakım ekipleriyle koordinasyon sağlandı, açık maddeler kayda alındı."
        };
        return summaries[PositiveModulo(seed, summaries.Length)];
    }

    private static string ShiftItemTitleFor(ShiftItemType itemType, Fault? fault, MaintenancePlan? maintenancePlan, Equipment equipment) => itemType switch
    {
        ShiftItemType.OpenFault => $"{fault?.FaultNo ?? "Açık arıza"} - müdahale takibi",
        ShiftItemType.PendingMaintenance => $"{maintenancePlan?.PlanNo ?? "Bakım planı"} - bakım penceresi takibi",
        ShiftItemType.EquipmentToWatch => $"{equipment.Code} - ekipman izleme",
        ShiftItemType.CriticalNote => "Kritik saha notu ve çalışma izni kontrolü",
        _ => "Devam eden operasyon işi"
    };

    private static string ShiftItemDescriptionFor(ShiftItemType itemType, Equipment equipment) => itemType switch
    {
        ShiftItemType.OpenFault => "Açık arıza için alarm tekrarı, saha erişimi ve müdahale durumu sonraki vardiyada izlenecek.",
        ShiftItemType.PendingMaintenance => "Planlı bakım penceresi, malzeme hazırlığı ve sorumlu ekip durumu kontrol edilecek.",
        ShiftItemType.EquipmentToWatch => $"{equipment.Code} ekipmanı için trend değerleri ve aktif alarm listesi takip edilecek.",
        ShiftItemType.CriticalNote => "Çalışma izni, enerji kesinti onayı ve saha güvenliği notu sonraki ekibe aktarıldı.",
        _ => "Devam eden işin saha durumu ve tamamlanma aksiyonu sonraki vardiyada takip edilecek."
    };

    private static Guid ActiveUserIdFor(int seed)
    {
        if (seed % 9 == 0)
        {
            return UserId(2);
        }

        if (seed % 5 == 0)
        {
            return OperatorUserIdFor(seed);
        }

        return TechnicianUserIdFor(seed);
    }

    private static string PersonName(int seed)
    {
        var firstName = FirstNames[PositiveModulo(seed - 1, FirstNames.Length)];
        var lastName = LastNames[PositiveModulo(((seed - 1) / FirstNames.Length) + (seed * 7), LastNames.Length)];
        return $"{firstName} {lastName}";
    }

    private static Guid TechnicianUserIdFor(int seed) => UserId(3 + PositiveModulo(seed, 75));
    private static Guid OperatorUserIdFor(int seed) => UserId(78 + PositiveModulo(seed, 35));

    private static DateTime DateTimeInRange(int seed, int startHour)
    {
        var date = DataStartDate.AddDays(PositiveModulo(seed * 37, TotalDays));
        var hour = PositiveModulo(startHour, 24);
        var minute = PositiveModulo(seed * 7, 60);
        return date.ToDateTime(new TimeOnly(hour, minute), DateTimeKind.Utc);
    }

    private static DateOnly DateOnlyInRange(int seed) => DataStartDate.AddDays(PositiveModulo(seed * 37, TotalDays));

    private static DateTime RecentDateTime(int seed, int startHour)
    {
        var date = RecentDateOnly(seed);
        return date.ToDateTime(new TimeOnly(PositiveModulo(startHour, 24), PositiveModulo(seed * 11, 60)), DateTimeKind.Utc);
    }

    private static DateOnly RecentDateOnly(int seed) => DataEndDate.AddDays(-PositiveModulo(seed, 21));

    private static int PositiveModulo(int value, int length) => ((value % length) + length) % length;

    private static Guid LocationId(int index) => Guid.Parse($"20000000-0000-0000-0000-{index:000000000000}");
    private static Guid TechnicalSystemId(int index) => Guid.Parse($"30000000-0000-0000-0000-{index:000000000000}");
    private static Guid UserId(int index) => Guid.Parse($"40000000-0000-0000-0000-{index:000000000000}");
    private static Guid EquipmentId(int index) => Guid.Parse($"50000000-0000-0000-0000-{index:000000000000}");
    private static Guid FaultId(int index) => Guid.Parse($"60000000-0000-0000-0000-{index:000000000000}");
    private static Guid FaultActionId(int index) => Guid.Parse($"61000000-0000-0000-0000-{index:000000000000}");
    private static Guid MaintenancePlanId(int index) => Guid.Parse($"70000000-0000-0000-0000-{index:000000000000}");
    private static Guid MaintenanceRecordId(int index) => Guid.Parse($"71000000-0000-0000-0000-{index:000000000000}");
    private static Guid TestPlanId(int index) => Guid.Parse($"72000000-0000-0000-0000-{index:000000000000}");
    private static Guid TestRecordId(int index) => Guid.Parse($"73000000-0000-0000-0000-{index:000000000000}");
    private static Guid ShiftHandoverId(int index) => Guid.Parse($"74000000-0000-0000-0000-{index:000000000000}");
    private static Guid ShiftItemId(int index) => Guid.Parse($"74100000-0000-0000-0000-{index:000000000000}");
    private static Guid ShiftAssignmentId(int index) => Guid.Parse($"74200000-0000-0000-0000-{index:000000000000}");
    private static Guid AuditLogId(int index) => Guid.Parse($"80000000-0000-0000-0000-{index:000000000000}");
    private static Guid NotificationId(int index) => Guid.Parse($"81000000-0000-0000-0000-{index:000000000000}");
}
