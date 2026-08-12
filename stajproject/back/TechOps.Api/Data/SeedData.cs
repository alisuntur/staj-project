using Microsoft.EntityFrameworkCore;
using TechOps.Api.Entities;
using TechOps.Api.Enums;

namespace TechOps.Api.Data;

public static class SeedData
{
    public static readonly Guid AdminRoleId = Guid.Parse("10000000-0000-0000-0000-000000000001");
    public static readonly Guid ManagerRoleId = Guid.Parse("10000000-0000-0000-0000-000000000002");
    public static readonly Guid TechnicianRoleId = Guid.Parse("10000000-0000-0000-0000-000000000003");
    public static readonly Guid OperatorRoleId = Guid.Parse("10000000-0000-0000-0000-000000000004");
    public static readonly Guid ReportRoleId = Guid.Parse("10000000-0000-0000-0000-000000000006");

    private static readonly DateTime CreatedAt = new(2026, 8, 11, 0, 0, 0, DateTimeKind.Utc);

    private static readonly Guid TerminalAId = Guid.Parse("20000000-0000-0000-0000-000000000001");
    private static readonly Guid TerminalBId = Guid.Parse("20000000-0000-0000-0000-000000000002");
    private static readonly Guid LevelCenterId = Guid.Parse("20000000-0000-0000-0000-000000000003");
    private static readonly Guid TechnicalBlockId = Guid.Parse("20000000-0000-0000-0000-000000000004");
    private static readonly Guid ApronId = Guid.Parse("20000000-0000-0000-0000-000000000005");

    private static readonly Guid GeneratorSystemId = Guid.Parse("30000000-0000-0000-0000-000000000001");
    private static readonly Guid UpsSystemId = Guid.Parse("30000000-0000-0000-0000-000000000002");
    private static readonly Guid HvacSystemId = Guid.Parse("30000000-0000-0000-0000-000000000003");
    private static readonly Guid ElectricalSystemId = Guid.Parse("30000000-0000-0000-0000-000000000004");
    private static readonly Guid AutomationSystemId = Guid.Parse("30000000-0000-0000-0000-000000000005");

    public static void Apply(ModelBuilder modelBuilder)
    {
        var locations = BuildLocations();
        var systems = BuildTechnicalSystems();
        var users = BuildUsers();
        var equipment = BuildEquipment();
        var faults = BuildFaults(equipment);
        var faultActions = BuildFaultActions(faults);
        var maintenancePlans = BuildMaintenancePlans(equipment);
        var maintenanceRecords = BuildMaintenanceRecords(maintenancePlans);
        var testPlans = BuildTestPlans(equipment);
        var testRecords = BuildTestRecords(testPlans);
        var handovers = BuildShiftHandovers();
        var shiftItems = BuildShiftItems(handovers, equipment, faults, maintenancePlans);
        var auditLogs = BuildAuditLogs();
        var notifications = BuildNotifications();

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = AdminRoleId, Name = "Admin", Description = "Sistem yöneticisi", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = ManagerRoleId, Name = "Yönetici", Description = "Operasyonu ve raporları izler", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = TechnicianRoleId, Name = "Teknik Personel", Description = "Arıza, bakım ve test işlemlerini yürütür", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = OperatorRoleId, Name = "Operatör", Description = "Olay ve arıza kaydı oluşturur", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = ReportRoleId, Name = "Rapor Kullanıcısı", Description = "Dashboard ve raporları görüntüler", IsSystemRole = true, CreatedAt = CreatedAt }
        );

        modelBuilder.Entity<Location>().HasData(locations);
        modelBuilder.Entity<TechnicalSystem>().HasData(systems);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Equipment>().HasData(equipment);
        modelBuilder.Entity<Fault>().HasData(faults);
        modelBuilder.Entity<FaultAction>().HasData(faultActions);
        modelBuilder.Entity<MaintenancePlan>().HasData(maintenancePlans);
        modelBuilder.Entity<MaintenanceRecord>().HasData(maintenanceRecords);
        modelBuilder.Entity<TestPlan>().HasData(testPlans);
        modelBuilder.Entity<TestRecord>().HasData(testRecords);
        modelBuilder.Entity<ShiftHandover>().HasData(handovers);
        modelBuilder.Entity<ShiftItem>().HasData(shiftItems);
        modelBuilder.Entity<AuditLog>().HasData(auditLogs);
        modelBuilder.Entity<Notification>().HasData(notifications);
    }

    private static IReadOnlyList<Location> BuildLocations() => new List<Location>
    {
        new() { Id = TerminalAId, Code = "LOC-T1", Name = "Terminal A", Type = "Terminal", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = TerminalBId, Code = "LOC-T2", Name = "Terminal B", Type = "Terminal", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = LevelCenterId, Code = "LOC-EM", Name = "Level Merkez", Type = "Teknik Alan", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = TechnicalBlockId, Code = "LOC-TB", Name = "Teknik Blok", Type = "Teknik Alan", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = ApronId, Code = "LOC-APR", Name = "Apron Bölgesi", Type = "Saha", IsActive = true, CreatedAt = CreatedAt }
    };

    private static IReadOnlyList<TechnicalSystem> BuildTechnicalSystems() => new List<TechnicalSystem>
    {
        new() { Id = GeneratorSystemId, Code = "SYS-GEN", Name = "Jeneratör", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = UpsSystemId, Code = "SYS-UPS", Name = "UPS", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = HvacSystemId, Code = "SYS-HVAC", Name = "HVAC", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = ElectricalSystemId, Code = "SYS-ELC", Name = "Elektrik", IsActive = true, CreatedAt = CreatedAt },
        new() { Id = AutomationSystemId, Code = "SYS-AUT", Name = "Otomasyon Paneli", IsActive = true, CreatedAt = CreatedAt }
    };

    private static IReadOnlyList<User> BuildUsers()
    {
        const string passwordHash = "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=";
        var users = new List<User>
        {
            new() { Id = UserId(1), RoleId = AdminRoleId, FullName = "Admin Kullanıcı", Username = "admin", Email = "admin@demo.local", PasswordHash = passwordHash, Title = "Sistem Yöneticisi", Department = "BT", IsActive = true, CreatedAt = CreatedAt },
            new() { Id = UserId(2), RoleId = ManagerRoleId, FullName = "Teknik Yönetici", Username = "yonetici", Email = "yonetici@demo.local", PasswordHash = passwordHash, Title = "Teknik Yönetici", Department = "Teknik Otomasyon", IsActive = true, CreatedAt = CreatedAt },
            new() { Id = UserId(3), RoleId = TechnicianRoleId, FullName = "Teknik Personel 1", Username = "teknik1", Email = "teknik1@demo.local", PasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy10ZWNoLTAwMQ==$sf498N38LrE5MyaWcpBXOto0kRMQNFh+bvhz0I6fpSQ=", Title = "Teknik Personel", Department = "Teknik Otomasyon", IsActive = true, CreatedAt = CreatedAt },
            new() { Id = UserId(4), RoleId = OperatorRoleId, FullName = "Operatör 1", Username = "operator1", Email = "operator1@demo.local", PasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy1vcGVyLTAwMQ==$f3lnNMIH5Qx0gyXdU4xxnWGdeU3DhcO+MKX/Xooisp0=", Title = "Operatör", Department = "Operasyon", IsActive = true, CreatedAt = CreatedAt }
        };

        var names = new[]
        {
            "Teknik Personel 2", "Teknik Personel 3", "Teknik Personel 4", "Teknik Personel 5", "Teknik Personel 6", "Teknik Personel 7", "Teknik Personel 8", "Teknik Personel 9",
            "Operatör 2", "Operatör 3", "Operatör 4", "Operatör 5",
            "Rapor Kullanıcısı"
        };

        for (var i = 0; i < names.Length; i++)
        {
            var number = i + 5;
            var roleId = number <= 12 ? TechnicianRoleId : number <= 16 ? OperatorRoleId : ReportRoleId;
            var username = roleId == TechnicianRoleId ? $"teknik{number - 3}" : roleId == OperatorRoleId ? $"operator{number - 11}" : "raporcu";
            users.Add(new User
            {
                Id = UserId(number),
                RoleId = roleId,
                FullName = names[i],
                Username = username,
                Email = $"{username}@demo.local",
                PasswordHash = passwordHash,
                Title = roleId == TechnicianRoleId ? "Teknik Personel" : roleId == OperatorRoleId ? "Operatör" : "Rapor Uzmanı",
                Department = roleId == OperatorRoleId ? "Operasyon" : "Teknik Otomasyon",
                IsActive = true,
                CreatedAt = CreatedAt
            });
        }

        return users;
    }

    private static IReadOnlyList<Equipment> BuildEquipment()
    {
        var locationIds = new[] { TerminalAId, TerminalBId, LevelCenterId, TechnicalBlockId, ApronId };
        var systemIds = new[] { GeneratorSystemId, UpsSystemId, HvacSystemId, ElectricalSystemId, AutomationSystemId };
        var systemCodes = new[] { "GEN", "UPS", "AHU", "ELC", "PLC" };
        var brands = new[] { "DemoPower", "DemoUPS", "DemoAir", "DemoVolt", "DemoPLC" };
        var models = new[] { "G-750X", "UPS-200", "AHU-400", "ELC-90", "PLC-1500" };
        var equipment = new List<Equipment>();

        equipment.AddRange(new[]
        {
            new Equipment { Id = EquipmentId(1), LocationId = TerminalBId, TechnicalSystemId = GeneratorSystemId, Code = "EQ-00032", Name = "Generator-T2-01", Brand = "DemoPower", Model = "G-750X", SerialNo = "SN-DEMO-00032", Status = EquipmentStatus.Active, CommissionedAt = new DateOnly(2018, 3, 15), IsActive = true, CreatedAt = CreatedAt },
            new Equipment { Id = EquipmentId(2), LocationId = LevelCenterId, TechnicalSystemId = UpsSystemId, Code = "EQ-00045", Name = "UPS-LM-02", Brand = "DemoUPS", Model = "UPS-200", SerialNo = "SN-DEMO-00045", Status = EquipmentStatus.Active, IsActive = true, CreatedAt = CreatedAt },
            new Equipment { Id = EquipmentId(3), LocationId = TerminalAId, TechnicalSystemId = HvacSystemId, Code = "EQ-00051", Name = "AHU-T1-04", Brand = "DemoAir", Model = "AHU-400", SerialNo = "SN-DEMO-00051", Status = EquipmentStatus.Maintenance, IsActive = true, CreatedAt = CreatedAt },
            new Equipment { Id = EquipmentId(4), LocationId = TechnicalBlockId, TechnicalSystemId = AutomationSystemId, Code = "EQ-00067", Name = "PLC-PNL-03", Brand = "DemoPLC", Model = "PLC-1500", SerialNo = "SN-DEMO-00067", Status = EquipmentStatus.Active, IsActive = true, CreatedAt = CreatedAt }
        });

        for (var i = 1001; i <= 1120; i++)
        {
            var systemIndex = (i - 1) % systemIds.Length;
            var locationIndex = (i + systemIndex) % locationIds.Length;
            var status = i % 19 == 0 ? EquipmentStatus.Faulted : i % 11 == 0 ? EquipmentStatus.Maintenance : EquipmentStatus.Active;
            var displayNo = i - 1000;
            equipment.Add(new Equipment
            {
                Id = EquipmentId(i),
                LocationId = locationIds[locationIndex],
                TechnicalSystemId = systemIds[systemIndex],
                Code = $"EQ-{displayNo + 1000:00000}",
                Name = $"{systemCodes[systemIndex]}-{LocationShortCode(locationIndex)}-{displayNo:000}",
                Brand = brands[systemIndex],
                Model = models[systemIndex],
                SerialNo = $"SN-DEMO-{displayNo + 1000:00000}",
                Status = status,
                CommissionedAt = new DateOnly(2016 + (i % 8), ((i - 1) % 12) + 1, ((i - 1) % 24) + 1),
                Description = "Sentetik demo ekipmanı.",
                IsActive = true,
                CreatedAt = CreatedAt
            });
        }

        return equipment;
    }

    private static IReadOnlyList<Fault> BuildFaults(IReadOnlyList<Equipment> equipment)
    {
        var faults = new List<Fault>();
        var sources = new[] { FaultSource.ScadaObservation, FaultSource.HoneywellEbiObservation, FaultSource.FieldObservation, FaultSource.OperatorReport, FaultSource.MaintenanceFinding };
        var priorities = new[] { FaultPriority.Low, FaultPriority.Medium, FaultPriority.High, FaultPriority.Critical };
        var statuses = new[] { FaultStatus.New, FaultStatus.Assigned, FaultStatus.InReview, FaultStatus.InProgress, FaultStatus.Waiting, FaultStatus.Resolved, FaultStatus.Closed };
        var descriptions = new[]
        {
            "Alarm değeri beklenen aralığın dışına çıktı.", "Saha kontrolünde anormal ses veya titreşim bildirildi.", "Operasyon ekranında kesintili haberleşme gözlendi.",
            "Periyodik kontrolde performans düşüşü tespit edildi.", "Vardiya sırasında takip gerektiren uyarı kaydedildi."
        };

        faults.AddRange(new[]
        {
            new Fault { Id = FaultId(10), FaultNo = "ARZ-2026-010", EquipmentId = EquipmentId(2), LocationId = LevelCenterId, TechnicalSystemId = UpsSystemId, CreatedByUserId = UserId(1), AssignedToUserId = UserId(3), Source = FaultSource.ScadaObservation, Priority = FaultPriority.Critical, Status = FaultStatus.InProgress, Description = "UPS bypass hattında kısa süreli alarm gözlendi. Yük transferi ve alarm eşiği takip edilecek.", AssignedAt = new DateTime(2026, 8, 12, 7, 30, 0, DateTimeKind.Utc), CreatedAt = new DateTime(2026, 8, 12, 7, 10, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 8, 12, 7, 30, 0, DateTimeKind.Utc) },
            new Fault { Id = FaultId(11), FaultNo = "ARZ-2026-011", EquipmentId = EquipmentId(3), LocationId = TerminalAId, TechnicalSystemId = HvacSystemId, CreatedByUserId = UserId(4), AssignedToUserId = UserId(3), Source = FaultSource.FieldObservation, Priority = FaultPriority.High, Status = FaultStatus.Assigned, Description = "AHU-T1-04 besleme havası sıcaklığı hedef aralığa düşmüyor. Filtre ve sensör kontrolleri takip edilecek.", AssignedAt = new DateTime(2026, 8, 12, 9, 15, 0, DateTimeKind.Utc), CreatedAt = new DateTime(2026, 8, 12, 9, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 8, 12, 9, 15, 0, DateTimeKind.Utc) }
        });

        for (var i = 1001; i <= 1150; i++)
        {
            var equipmentItem = equipment[(i * 7) % equipment.Count];
            var status = statuses[i % statuses.Length];
            var priority = i % 13 == 0 ? FaultPriority.Critical : priorities[i % priorities.Length];
            var createdAt = new DateTime(2026, 1, 1, 7, 0, 0, DateTimeKind.Utc).AddDays(i % 220).AddHours(i % 11).AddMinutes((i * 7) % 60);
            var assignedAt = status == FaultStatus.New ? (DateTime?)null : createdAt.AddMinutes(20 + (i % 40));
            var resolvedAt = status is FaultStatus.Resolved or FaultStatus.Closed ? createdAt.AddHours(1 + (i % 8)).AddMinutes(i % 45) : (DateTime?)null;
            var closedAt = status == FaultStatus.Closed ? resolvedAt?.AddHours(1 + (i % 3)) : null;
            var updatedAt = closedAt ?? resolvedAt ?? assignedAt ?? createdAt;

            faults.Add(new Fault
            {
                Id = FaultId(i),
                FaultNo = $"ARZ-2026-{i - 900:000}",
                EquipmentId = equipmentItem.Id,
                LocationId = equipmentItem.LocationId,
                TechnicalSystemId = equipmentItem.TechnicalSystemId,
                CreatedByUserId = UserId(i % 3 == 0 ? 1 : 4),
                AssignedToUserId = assignedAt.HasValue ? UserId(3) : null,
                ResolvedByUserId = resolvedAt.HasValue ? UserId(3) : null,
                ClosedByUserId = closedAt.HasValue ? UserId(2) : null,
                Source = sources[i % sources.Length],
                Priority = priority,
                Status = status,
                Description = descriptions[i % descriptions.Length],
                ResolutionDescription = resolvedAt.HasValue ? "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü." : null,
                WaitingReason = status == FaultStatus.Waiting ? "Yedek parça ve uygun çalışma zamanı bekleniyor." : null,
                AssignedAt = assignedAt,
                ResolvedAt = resolvedAt,
                ClosedAt = closedAt,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt == createdAt ? null : updatedAt
            });
        }

        return faults;
    }

    private static IReadOnlyList<MaintenancePlan> BuildMaintenancePlans(IReadOnlyList<Equipment> equipment)
    {
        var plans = new List<MaintenancePlan>();
        var types = new[] { "Haftalık", "Aylık", "3 Aylık", "6 Aylık", "Yıllık" };
        var priorities = new[] { FaultPriority.Low, FaultPriority.Medium, FaultPriority.High, FaultPriority.Critical };
        var statuses = new[] { MaintenanceStatus.Planned, MaintenanceStatus.Started, MaintenanceStatus.Completed, MaintenanceStatus.Delayed };

        plans.AddRange(new[]
        {
            new MaintenancePlan { Id = MaintenancePlanId(1), PlanNo = "BKM-2026-001", EquipmentId = EquipmentId(1), ResponsibleUserId = UserId(3), CreatedByUserId = UserId(1), MaintenanceType = "6 Aylık", PlannedDate = new DateOnly(2026, 8, 20), Frequency = "6 Aylık", Priority = FaultPriority.Medium, Status = MaintenanceStatus.Planned, Description = "Jeneratör yakıt, yağ, filtre ve otomatik transfer panosu kontrolleri yapılacak.", CreatedAt = CreatedAt },
            new MaintenancePlan { Id = MaintenancePlanId(2), PlanNo = "BKM-2026-002", EquipmentId = EquipmentId(3), ResponsibleUserId = UserId(3), CreatedByUserId = UserId(1), MaintenanceType = "Aylık", PlannedDate = new DateOnly(2026, 8, 11), Frequency = "Aylık", Priority = FaultPriority.High, Status = MaintenanceStatus.Started, Description = "HVAC ünitesi filtre, kayış, drenaj hattı ve sıcaklık sensörü kontrolleri yapılacak.", StartedAt = new DateTime(2026, 8, 11, 8, 30, 0, DateTimeKind.Utc), CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 11, 8, 30, 0, DateTimeKind.Utc) },
            new MaintenancePlan { Id = MaintenancePlanId(3), PlanNo = "BKM-2026-003", EquipmentId = EquipmentId(2), ResponsibleUserId = UserId(2), CreatedByUserId = UserId(1), MaintenanceType = "Yıllık", PlannedDate = new DateOnly(2026, 8, 5), Frequency = "Yıllık", Priority = FaultPriority.Critical, Status = MaintenanceStatus.Planned, Description = "UPS batarya bloğu, bypass hattı ve yük aktarım testi planlandı.", CreatedAt = CreatedAt },
            new MaintenancePlan { Id = MaintenancePlanId(4), PlanNo = "BKM-2026-004", EquipmentId = EquipmentId(4), ResponsibleUserId = UserId(3), CreatedByUserId = UserId(1), MaintenanceType = "3 Aylık", PlannedDate = new DateOnly(2026, 8, 1), Frequency = "3 Aylık", Priority = FaultPriority.Medium, Status = MaintenanceStatus.Completed, Description = "PLC panel klemens, güç kaynağı ve haberleşme modülü bakımı tamamlandı.", StartedAt = new DateTime(2026, 8, 1, 9, 0, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc), CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc) },
            new MaintenancePlan { Id = MaintenancePlanId(5), PlanNo = "BKM-2026-005", EquipmentId = EquipmentId(1), ResponsibleUserId = UserId(3), CreatedByUserId = UserId(1), MaintenanceType = "Haftalık", PlannedDate = new DateOnly(2026, 7, 28), Frequency = "Haftalık", Priority = FaultPriority.Low, Status = MaintenanceStatus.Completed, Description = "Haftalık jeneratör saha kontrolü tamamlandı.", StartedAt = new DateTime(2026, 7, 28, 7, 45, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc), CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc) }
        });

        for (var i = 1001; i <= 1130; i++)
        {
            var equipmentItem = equipment[(i * 5) % equipment.Count];
            var status = i % 5 == 0 ? MaintenanceStatus.Planned : i % 5 == 1 ? MaintenanceStatus.Started : MaintenanceStatus.Completed;
            var plannedDate = new DateOnly(2026, 1, 1).AddDays(i % 230);
            var startedAt = status is MaintenanceStatus.Started or MaintenanceStatus.Completed ? plannedDate.ToDateTime(new TimeOnly(8 + (i % 6), 0), DateTimeKind.Utc) : (DateTime?)null;
            var completedAt = status == MaintenanceStatus.Completed ? startedAt?.AddHours(1 + (i % 5)).AddMinutes((i * 3) % 45) : null;

            plans.Add(new MaintenancePlan
            {
                Id = MaintenancePlanId(i),
                PlanNo = $"BKM-2026-{i - 900:000}",
                EquipmentId = equipmentItem.Id,
                ResponsibleUserId = UserId(3),
                CreatedByUserId = UserId(2),
                MaintenanceType = types[i % types.Length],
                PlannedDate = plannedDate,
                Frequency = types[i % types.Length],
                Priority = i % 17 == 0 ? FaultPriority.Critical : priorities[i % priorities.Length],
                Status = status,
                Description = "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.",
                StartedAt = startedAt,
                CompletedAt = completedAt,
                CreatedAt = CreatedAt,
                UpdatedAt = completedAt ?? startedAt
            });
        }

        return plans;
    }

    private static IReadOnlyList<MaintenanceRecord> BuildMaintenanceRecords(IReadOnlyList<MaintenancePlan> plans)
    {
        var records = new List<MaintenanceRecord>();
        records.AddRange(new[]
        {
            new MaintenanceRecord { Id = MaintenanceRecordId(1), MaintenancePlanId = MaintenancePlanId(4), EquipmentId = EquipmentId(4), PerformedByUserId = UserId(3), MaintenanceType = "3 Aylık", StartedAt = new DateTime(2026, 8, 1, 9, 0, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc), ResultStatus = MaintenanceResultStatus.Completed, Description = "PLC panel içi temizlik, klemens sıkılık kontrolü ve yedek güç kaynağı testi tamamlandı.", UsedMaterials = "Klemens etiketi, temizlik spreyi", ChecklistJson = "[{\"Text\":\"Fiziksel hasar kontrolü yapıldı.\",\"IsChecked\":true},{\"Text\":\"Bağlantı klemensleri sıkıldı.\",\"IsChecked\":true},{\"Text\":\"Haberleşme testi yapıldı.\",\"IsChecked\":true}]", CreatedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc) },
            new MaintenanceRecord { Id = MaintenanceRecordId(2), MaintenancePlanId = MaintenancePlanId(5), EquipmentId = EquipmentId(1), PerformedByUserId = UserId(3), MaintenanceType = "Haftalık", StartedAt = new DateTime(2026, 7, 28, 7, 45, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc), ResultStatus = MaintenanceResultStatus.Completed, Description = "Jeneratör çalışma testi, sıvı seviye kontrolleri ve görsel saha kontrolü tamamlandı.", UsedMaterials = "Kontrol formu", ChecklistJson = "[{\"Text\":\"Yağ ve yakıt seviyesi kontrol edildi.\",\"IsChecked\":true},{\"Text\":\"Sızıntı kontrolü yapıldı.\",\"IsChecked\":true},{\"Text\":\"Test çalıştırması tamamlandı.\",\"IsChecked\":true}]", CreatedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc) }
        });

        var completedPlans = plans.Where(x => x.Id != MaintenancePlanId(4) && x.Id != MaintenancePlanId(5) && x.Status == MaintenanceStatus.Completed && x.CompletedAt.HasValue).ToList();

        for (var i = 0; i < 100; i++)
        {
            var plan = completedPlans[i % completedPlans.Count];
            var cycleOffsetDays = (i / completedPlans.Count) * 7;
            var completedAt = plan.CompletedAt!.Value.AddDays(cycleOffsetDays);

            records.Add(new MaintenanceRecord
            {
                Id = MaintenanceRecordId(i + 1001),
                MaintenancePlanId = plan.Id,
                EquipmentId = plan.EquipmentId,
                PerformedByUserId = plan.ResponsibleUserId,
                MaintenanceType = plan.MaintenanceType,
                StartedAt = plan.StartedAt?.AddDays(cycleOffsetDays),
                CompletedAt = completedAt,
                ResultStatus = i % 14 == 0 ? MaintenanceResultStatus.PartiallyCompleted : MaintenanceResultStatus.Completed,
                Description = "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.",
                UsedMaterials = i % 5 == 0 ? "Filtre, etiket, temizlik spreyi" : "Kontrol formu",
                ChecklistJson = "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]",
                CreatedAt = completedAt
            });
        }

        return records;
    }

    private static IReadOnlyList<TestPlan> BuildTestPlans(IReadOnlyList<Equipment> equipment)
    {
        var plans = new List<TestPlan>();
        var testTypes = new[] { "Haftalık Jeneratör Testi", "UPS Yük Transfer Testi", "HVAC Çalışma Testi", "PLC I/O Testi", "Acil Durum Senaryo Testi" };
        var statuses = new[] { TestPlanStatus.Planned, TestPlanStatus.Completed, TestPlanStatus.Delayed, TestPlanStatus.Cancelled };

        plans.AddRange(new[]
        {
            new TestPlan { Id = TestPlanId(1), EquipmentId = EquipmentId(1), ResponsibleUserId = UserId(3), TestType = "Haftalık Jeneratör Testi", PlannedDate = new DateOnly(2026, 8, 3), Frequency = "Haftalık", Status = TestPlanStatus.Completed, Description = "Jeneratör otomatik çalışma ve transfer senaryosu doğrulaması.", CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 3, 8, 30, 0, DateTimeKind.Utc) },
            new TestPlan { Id = TestPlanId(2), EquipmentId = EquipmentId(2), ResponsibleUserId = UserId(2), TestType = "UPS Yük Transfer Testi", PlannedDate = new DateOnly(2026, 8, 4), Frequency = "Aylık", Status = TestPlanStatus.Completed, Description = "UPS bypass ve yük transfer testi.", CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 4, 10, 10, 0, DateTimeKind.Utc) },
            new TestPlan { Id = TestPlanId(3), EquipmentId = EquipmentId(3), ResponsibleUserId = UserId(3), TestType = "HVAC Çalışma Testi", PlannedDate = new DateOnly(2026, 8, 6), Frequency = "Aylık", Status = TestPlanStatus.Completed, Description = "AHU çalışma, sıcaklık ve drenaj testleri.", CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 6, 14, 5, 0, DateTimeKind.Utc) },
            new TestPlan { Id = TestPlanId(4), EquipmentId = EquipmentId(4), ResponsibleUserId = UserId(3), TestType = "PLC I/O Testi", PlannedDate = new DateOnly(2026, 8, 7), Frequency = "3 Aylık", Status = TestPlanStatus.Completed, Description = "PLC panel giriş/çıkış sinyal doğrulaması.", CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 7, 11, 40, 0, DateTimeKind.Utc) },
            new TestPlan { Id = TestPlanId(5), EquipmentId = EquipmentId(1), ResponsibleUserId = UserId(2), TestType = "Acil Durum Senaryo Testi", PlannedDate = new DateOnly(2026, 8, 9), Frequency = "Tek Seferlik", Status = TestPlanStatus.Completed, Description = "Acil durum yük devreye alma senaryosu.", CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 9, 9, 45, 0, DateTimeKind.Utc) },
            new TestPlan { Id = TestPlanId(6), EquipmentId = EquipmentId(2), ResponsibleUserId = UserId(3), TestType = "UPS Batarya Otonomi Testi", PlannedDate = new DateOnly(2026, 8, 18), Frequency = "6 Aylık", Status = TestPlanStatus.Planned, Description = "UPS batarya otonomi süresi ve alarm eşikleri test edilecek.", CreatedAt = CreatedAt }
        });

        for (var i = 1001; i <= 1120; i++)
        {
            var equipmentItem = equipment[(i * 3) % equipment.Count];
            var status = statuses[i % statuses.Length];
            var plannedDate = new DateOnly(2026, 1, 1).AddDays(i % 220);
            plans.Add(new TestPlan
            {
                Id = TestPlanId(i),
                EquipmentId = equipmentItem.Id,
                ResponsibleUserId = UserId(3),
                TestType = testTypes[i % testTypes.Length],
                PlannedDate = plannedDate,
                Frequency = i % 4 == 0 ? "Aylık" : i % 4 == 1 ? "Haftalık" : i % 4 == 2 ? "3 Aylık" : "Tek Seferlik",
                Status = status,
                Description = "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.",
                CreatedAt = CreatedAt,
                UpdatedAt = status == TestPlanStatus.Completed ? plannedDate.ToDateTime(new TimeOnly(10, 0), DateTimeKind.Utc) : null
            });
        }

        return plans;
    }

    private static IReadOnlyList<TestRecord> BuildTestRecords(IReadOnlyList<TestPlan> plans)
    {
        var records = new List<TestRecord>();
        var results = new[] { TestResult.Success, TestResult.ConditionalSuccess, TestResult.Failed, TestResult.RetestRequired };

        records.AddRange(new[]
        {
            new TestRecord { Id = TestRecordId(1), TestPlanId = TestPlanId(1), EquipmentId = EquipmentId(1), TestedByUserId = UserId(3), TestDate = new DateTime(2026, 8, 3, 8, 30, 0, DateTimeKind.Utc), TestType = "Haftalık Jeneratör Testi", DurationMinutes = 35, Result = TestResult.Success, Description = "Jeneratör otomatik olarak devreye girdi, gerilim ve frekans değerleri normal aralıkta izlendi.", CreatedAt = new DateTime(2026, 8, 3, 8, 30, 0, DateTimeKind.Utc) },
            new TestRecord { Id = TestRecordId(2), TestPlanId = TestPlanId(2), EquipmentId = EquipmentId(2), TestedByUserId = UserId(2), TestDate = new DateTime(2026, 8, 4, 10, 10, 0, DateTimeKind.Utc), TestType = "UPS Yük Transfer Testi", DurationMinutes = 25, Result = TestResult.ConditionalSuccess, AbnormalCondition = "Transfer sonrası kısa süreli bypass alarmı izlendi.", Description = "Yük transferi tamamlandı ancak alarm eşiği bakımda yeniden değerlendirilecek.", CreatedAt = new DateTime(2026, 8, 4, 10, 10, 0, DateTimeKind.Utc) },
            new TestRecord { Id = TestRecordId(3), TestPlanId = TestPlanId(3), EquipmentId = EquipmentId(3), TestedByUserId = UserId(3), TestDate = new DateTime(2026, 8, 6, 14, 5, 0, DateTimeKind.Utc), TestType = "HVAC Çalışma Testi", DurationMinutes = 40, Result = TestResult.Failed, AbnormalCondition = "Besleme havası sıcaklığı hedef aralığa düşmedi.", Description = "AHU soğutma performansı yetersiz. Bakım planı ile filtre ve sensör kontrolleri takip edilecek.", CreatedAt = new DateTime(2026, 8, 6, 14, 5, 0, DateTimeKind.Utc) },
            new TestRecord { Id = TestRecordId(4), TestPlanId = TestPlanId(4), EquipmentId = EquipmentId(4), TestedByUserId = UserId(3), TestDate = new DateTime(2026, 8, 7, 11, 40, 0, DateTimeKind.Utc), TestType = "PLC I/O Testi", DurationMinutes = 55, Result = TestResult.Success, Description = "Tüm dijital giriş/çıkış noktaları SCADA üzerinden doğrulandı.", CreatedAt = new DateTime(2026, 8, 7, 11, 40, 0, DateTimeKind.Utc) },
            new TestRecord { Id = TestRecordId(5), TestPlanId = TestPlanId(5), EquipmentId = EquipmentId(1), TestedByUserId = UserId(2), TestDate = new DateTime(2026, 8, 9, 9, 45, 0, DateTimeKind.Utc), TestType = "Acil Durum Senaryo Testi", DurationMinutes = 30, Result = TestResult.RetestRequired, AbnormalCondition = "Yük alma süresi kabul kriterine çok yakın ölçüldü.", Description = "Değer sınırda olduğu için tekrar test planlanacak.", CreatedAt = new DateTime(2026, 8, 9, 9, 45, 0, DateTimeKind.Utc) }
        });

        for (var i = 1001; i <= 1110; i++)
        {
            var plan = plans[(i * 2) % plans.Count];
            var testDate = plan.PlannedDate.ToDateTime(new TimeOnly(8 + (i % 8), (i * 5) % 60), DateTimeKind.Utc);
            var result = results[i % results.Length];
            records.Add(new TestRecord
            {
                Id = TestRecordId(i),
                TestPlanId = plan.Id,
                EquipmentId = plan.EquipmentId,
                TestedByUserId = UserId(3),
                TestDate = testDate,
                TestType = plan.TestType,
                DurationMinutes = 20 + (i % 70),
                Result = result,
                AbnormalCondition = result is TestResult.Failed or TestResult.RetestRequired ? "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü." : null,
                Description = "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.",
                CreatedAt = testDate,
                UpdatedAt = testDate.AddMinutes(5)
            });
        }

        return records;
    }

    private static IReadOnlyList<ShiftHandover> BuildShiftHandovers()
    {
        var handovers = new List<ShiftHandover>();
        var shiftTypes = new[] { ShiftType.Morning, ShiftType.Evening, ShiftType.Night };

        handovers.AddRange(new[]
        {
            new ShiftHandover { Id = ShiftHandoverId(1), HandoverNo = "VDT-2026-001", ShiftType = ShiftType.Morning, ShiftDate = new DateOnly(2026, 8, 12), HandoverFromUserId = UserId(3), HandoverToUserId = UserId(2), Summary = "Gece vardiyasından devralınan UPS alarmı ve bekleyen bakım faaliyetleri sabah vardiyasına aktarıldı.", CriticalNotes = "Level Merkez UPS alarm eşiği ve yük transfer davranışı yakından izlenecek.", CreatedAt = new DateTime(2026, 8, 12, 8, 0, 0, DateTimeKind.Utc) },
            new ShiftHandover { Id = ShiftHandoverId(2), HandoverNo = "VDT-2026-002", ShiftType = ShiftType.Evening, ShiftDate = new DateOnly(2026, 8, 12), HandoverFromUserId = UserId(2), HandoverToUserId = UserId(3), Summary = "Sabah vardiyasındaki açık arıza ve saha takip maddeleri akşam vardiyasına devredildi.", CriticalNotes = "Terminal A HVAC sıcaklık takibi operasyon saatleri boyunca sürdürülecek.", CreatedAt = new DateTime(2026, 8, 12, 16, 0, 0, DateTimeKind.Utc) },
            new ShiftHandover { Id = ShiftHandoverId(3), HandoverNo = "VDT-2026-003", ShiftType = ShiftType.Night, ShiftDate = new DateOnly(2026, 8, 12), HandoverFromUserId = UserId(3), HandoverToUserId = UserId(2), Summary = "Akşam vardiyasından gece vardiyasına takip edilecek cihazlar ve kritik saha notları aktarıldı.", CriticalNotes = "Level Merkez çalışma izni ve PLC panel alarm listesi gece vardiyasında tekrar kontrol edilecek.", CreatedAt = new DateTime(2026, 8, 12, 23, 45, 0, DateTimeKind.Utc) }
        });

        for (var i = 1001; i <= 1100; i++)
        {
            var shiftDate = new DateOnly(2026, 5, 1).AddDays(i / 3);
            var shiftType = shiftTypes[i % shiftTypes.Length];
            handovers.Add(new ShiftHandover
            {
                Id = ShiftHandoverId(i),
                HandoverNo = $"VDT-2026-{i - 900:000}",
                ShiftType = shiftType,
                ShiftDate = shiftDate,
                HandoverFromUserId = UserId(i % 2 == 0 ? 3 : 2),
                HandoverToUserId = UserId(i % 2 == 0 ? 2 : 3),
                Summary = "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.",
                CriticalNotes = i % 5 == 0 ? "Kritik ekipman alarm trendi vardiya boyunca takip edilecek." : "Standart vardiya takip notları aktarıldı.",
                CreatedAt = shiftDate.ToDateTime(new TimeOnly(shiftType == ShiftType.Morning ? 8 : shiftType == ShiftType.Evening ? 16 : 23, 45), DateTimeKind.Utc)
            });
        }

        return handovers;
    }

    private static IReadOnlyList<ShiftItem> BuildShiftItems(IReadOnlyList<ShiftHandover> handovers, IReadOnlyList<Equipment> equipment, IReadOnlyList<Fault> faults, IReadOnlyList<MaintenancePlan> maintenancePlans)
    {
        var items = new List<ShiftItem>();
        var itemTypes = new[] { ShiftItemType.OpenFault, ShiftItemType.OngoingWork, ShiftItemType.EquipmentToWatch, ShiftItemType.PendingMaintenance, ShiftItemType.CriticalNote };

        items.AddRange(new[]
        {
            new ShiftItem { Id = ShiftItemId(1), ShiftHandoverId = ShiftHandoverId(1), ItemType = ShiftItemType.OpenFault, Title = "ARZ-2026-010 - UPS bypass alarmı takibi", Description = "UPS bypass alarmının tekrarlayıp tekrarlamadığı SCADA üzerinden izlenecek.", FaultId = FaultId(10), EquipmentId = EquipmentId(2), Priority = FaultPriority.Critical, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 8, 0, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(2), ShiftHandoverId = ShiftHandoverId(1), ItemType = ShiftItemType.PendingMaintenance, Title = "BKM-2026-003 - UPS yıllık bakım takibi", Description = "UPS batarya bloğu ve bypass hattı bakım planı teknik yönetici onayıyla takip edilecek.", EquipmentId = EquipmentId(2), MaintenancePlanId = MaintenancePlanId(3), Priority = FaultPriority.Critical, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 8, 2, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(3), ShiftHandoverId = ShiftHandoverId(1), ItemType = ShiftItemType.CriticalNote, Title = "Level Merkez yük transferi sırasında haber verilecek", Description = "Yük transfer testi veya bypass işlemi öncesinde operasyon merkezi bilgilendirilecek.", Priority = FaultPriority.High, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 8, 4, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(4), ShiftHandoverId = ShiftHandoverId(2), ItemType = ShiftItemType.OpenFault, Title = "ARZ-2026-011 - AHU sıcaklık takibi", Description = "Terminal A AHU besleme sıcaklığı ve sensör okumaları akşam vardiyasında kontrol edilecek.", FaultId = FaultId(11), EquipmentId = EquipmentId(3), Priority = FaultPriority.High, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 16, 0, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(5), ShiftHandoverId = ShiftHandoverId(2), ItemType = ShiftItemType.EquipmentToWatch, Title = "EQ-00032 - Jeneratör çalışma sesi izlenecek", Description = "Haftalık test sonrası jeneratör çalışma sesi ve yağ basıncı değerleri vardiya boyunca izlenecek.", EquipmentId = EquipmentId(1), Priority = FaultPriority.Medium, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 16, 3, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(6), ShiftHandoverId = ShiftHandoverId(2), ItemType = ShiftItemType.OngoingWork, Title = "Jeneratör yakıt seviyesi manuel kontrolü", Description = "Saha turunda jeneratör yakıt seviyesi ve sızıntı kontrolü yapılacak.", EquipmentId = EquipmentId(1), Priority = FaultPriority.Medium, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 16, 5, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(7), ShiftHandoverId = ShiftHandoverId(3), ItemType = ShiftItemType.EquipmentToWatch, Title = "EQ-00067 - PLC panel haberleşme durumu", Description = "PLC panel haberleşme alarmları gece vardiyasında kontrol edildi.", EquipmentId = EquipmentId(4), Priority = FaultPriority.Low, IsCompleted = true, CreatedAt = new DateTime(2026, 8, 12, 23, 45, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 8, 12, 23, 58, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(8), ShiftHandoverId = ShiftHandoverId(3), ItemType = ShiftItemType.OngoingWork, Title = "SCADA alarm listesi nöbet kontrolü", Description = "Saat başı SCADA aktif alarm listesi kontrol edilip kritik alarmlar not alınacak.", Priority = FaultPriority.Medium, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 23, 47, 0, DateTimeKind.Utc) },
            new ShiftItem { Id = ShiftItemId(9), ShiftHandoverId = ShiftHandoverId(3), ItemType = ShiftItemType.CriticalNote, Title = "Level Merkez girişinde çalışma izni kontrolü", Description = "Gece vardiyasında Level Merkez girişinde plan dışı çalışma olup olmadığı kontrol edilecek.", Priority = FaultPriority.Critical, IsCompleted = false, CreatedAt = new DateTime(2026, 8, 12, 23, 49, 0, DateTimeKind.Utc) }
        });

        for (var i = 1001; i <= 1220; i++)
        {
            var handover = handovers[(i - 1) % handovers.Count];
            var itemType = itemTypes[i % itemTypes.Length];
            var equipmentItem = equipment[(i * 4) % equipment.Count];
            var fault = itemType == ShiftItemType.OpenFault ? faults[(i * 3) % faults.Count] : null;
            var maintenancePlan = itemType == ShiftItemType.PendingMaintenance ? maintenancePlans[(i * 5) % maintenancePlans.Count] : null;
            items.Add(new ShiftItem
            {
                Id = ShiftItemId(i),
                ShiftHandoverId = handover.Id,
                ItemType = itemType,
                Title = BuildShiftItemTitle(itemType, fault, maintenancePlan, equipmentItem),
                Description = "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.",
                FaultId = fault?.Id,
                EquipmentId = fault?.EquipmentId ?? maintenancePlan?.EquipmentId ?? (itemType == ShiftItemType.CriticalNote ? null : equipmentItem.Id),
                MaintenancePlanId = maintenancePlan?.Id,
                Priority = i % 17 == 0 ? FaultPriority.Critical : i % 5 == 0 ? FaultPriority.High : i % 3 == 0 ? FaultPriority.Medium : FaultPriority.Low,
                IsCompleted = i % 4 == 0,
                CreatedAt = handover.CreatedAt.AddMinutes(i % 50),
                UpdatedAt = i % 4 == 0 ? handover.CreatedAt.AddMinutes(60 + (i % 40)) : null
            });
        }

        return items;
    }

    private static string BuildShiftItemTitle(ShiftItemType itemType, Fault? fault, MaintenancePlan? maintenancePlan, Equipment equipment)
    {
        return itemType switch
        {
            ShiftItemType.OpenFault => $"{fault!.FaultNo} - açık arıza takibi",
            ShiftItemType.PendingMaintenance => $"{maintenancePlan!.PlanNo} - bekleyen bakım takibi",
            ShiftItemType.EquipmentToWatch => $"{equipment.Code} - ekipman izleme",
            ShiftItemType.CriticalNote => "Kritik saha notu ve çalışma izni kontrolü",
            _ => "Devam eden operasyon işi"
        };
    }

    private static IReadOnlyList<FaultAction> BuildFaultActions(IReadOnlyList<Fault> faults)
    {
        var actions = new List<FaultAction>();
        var actionTypes = new[] { "Created", "Assigned", "StatusChanged", "NoteAdded", "Resolved", "Closed" };

        for (var i = 1001; i <= 1150; i++)
        {
            var fault = faults[(i * 2) % faults.Count];
            var actionType = actionTypes[i % actionTypes.Length];
            actions.Add(new FaultAction
            {
                Id = FaultActionId(i),
                FaultId = fault.Id,
                UserId = UserId(3),
                ActionType = actionType,
                OldStatus = actionType == "StatusChanged" ? FaultStatus.Assigned : null,
                NewStatus = actionType == "StatusChanged" ? fault.Status : null,
                Note = "Sentetik arıza işlem kaydı.",
                Metadata = "{}",
                CreatedAt = fault.CreatedAt.AddMinutes(10 + (i % 90))
            });
        }

        return actions;
    }

    private static IReadOnlyList<AuditLog> BuildAuditLogs()
    {
        var logs = new List<AuditLog>();
        var entities = new[] { "Fault", "MaintenancePlan", "TestRecord", "ShiftHandover", "Equipment" };
        var actions = new[] { "Create", "Update", "StatusChange", "Export", "View" };

        for (var i = 1001; i <= 1100; i++)
        {
            logs.Add(new AuditLog
            {
                Id = AuditLogId(i),
                UserId = UserId(1 + (i % 4)),
                EntityName = entities[i % entities.Length],
                EntityId = null,
                Action = actions[i % actions.Length],
                OldValues = "{}",
                NewValues = "{}",
                IpAddress = $"10.10.0.{i % 200}",
                UserAgent = "SyntheticDemo/1.0",
                CreatedAt = new DateTime(2026, 7, 1, 8, 0, 0, DateTimeKind.Utc).AddHours(i % 240)
            });
        }

        return logs;
    }

    private static IReadOnlyList<Notification> BuildNotifications()
    {
        var notifications = new List<Notification>();
        var types = new[] { NotificationType.Info, NotificationType.Warning, NotificationType.Critical };

        for (var i = 1001; i <= 1100; i++)
        {
            var type = types[i % types.Length];
            notifications.Add(new Notification
            {
                Id = NotificationId(i),
                UserId = UserId(1 + (i % 4)),
                Title = type == NotificationType.Critical ? "Kritik operasyon uyarısı" : type == NotificationType.Warning ? "Takip gerektiren kayıt" : "Bilgilendirme",
                Message = "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.",
                Type = type,
                RelatedEntityName = i % 2 == 0 ? "Fault" : "MaintenancePlan",
                RelatedEntityId = null,
                IsRead = i % 3 == 0,
                CreatedAt = new DateTime(2026, 7, 1, 9, 0, 0, DateTimeKind.Utc).AddHours(i % 180)
            });
        }

        return notifications;
    }

    private static string LocationShortCode(int locationIndex) => locationIndex switch
    {
        0 => "TA",
        1 => "TB",
        2 => "LM",
        3 => "TK",
        _ => "AP"
    };

    private static Guid UserId(int index) => Guid.Parse($"40000000-0000-0000-0000-{index:000000000000}");
    private static Guid EquipmentId(int index) => Guid.Parse($"50000000-0000-0000-0000-{index:000000000000}");
    private static Guid FaultId(int index) => Guid.Parse($"60000000-0000-0000-0000-{index:000000000000}");
    private static Guid MaintenancePlanId(int index) => Guid.Parse($"70000000-0000-0000-0000-{index:000000000000}");
    private static Guid MaintenanceRecordId(int index) => Guid.Parse($"71000000-0000-0000-0000-{index:000000000000}");
    private static Guid TestPlanId(int index) => Guid.Parse($"72000000-0000-0000-0000-{index:000000000000}");
    private static Guid TestRecordId(int index) => Guid.Parse($"73000000-0000-0000-0000-{index:000000000000}");
    private static Guid ShiftHandoverId(int index) => Guid.Parse($"74000000-0000-0000-0000-{index:000000000000}");
    private static Guid ShiftItemId(int index) => Guid.Parse($"74100000-0000-0000-0000-{index:000000000000}");
    private static Guid FaultActionId(int index) => Guid.Parse($"61000000-0000-0000-0000-{index:000000000000}");
    private static Guid AuditLogId(int index) => Guid.Parse($"80000000-0000-0000-0000-{index:000000000000}");
    private static Guid NotificationId(int index) => Guid.Parse($"81000000-0000-0000-0000-{index:000000000000}");
}
