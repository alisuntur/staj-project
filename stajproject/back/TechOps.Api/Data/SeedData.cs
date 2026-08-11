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

    public static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = AdminRoleId, Name = "Admin", Description = "Sistem yöneticisi", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = ManagerRoleId, Name = "Yönetici", Description = "Operasyonu ve raporları izler", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = TechnicianRoleId, Name = "Teknik Personel", Description = "Arıza, bakım ve test işlemlerini yürütür", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = OperatorRoleId, Name = "Operatör", Description = "Olay ve arıza kaydı oluşturur", IsSystemRole = true, CreatedAt = CreatedAt },
            new Role { Id = ReportRoleId, Name = "Rapor Kullanıcısı", Description = "Dashboard ve raporları görüntüler", IsSystemRole = true, CreatedAt = CreatedAt }
        );

        var terminal1Id = Guid.Parse("20000000-0000-0000-0000-000000000001");
        var terminal2Id = Guid.Parse("20000000-0000-0000-0000-000000000002");
        var energyCenterId = Guid.Parse("20000000-0000-0000-0000-000000000003");
        var technicalBlockId = Guid.Parse("20000000-0000-0000-0000-000000000004");
        var apronId = Guid.Parse("20000000-0000-0000-0000-000000000005");

        modelBuilder.Entity<Location>().HasData(
            new Location { Id = terminal1Id, Code = "LOC-T1", Name = "Terminal 1", Type = "Terminal", IsActive = true, CreatedAt = CreatedAt },
            new Location { Id = terminal2Id, Code = "LOC-T2", Name = "Terminal 2", Type = "Terminal", IsActive = true, CreatedAt = CreatedAt },
            new Location { Id = energyCenterId, Code = "LOC-EM", Name = "Enerji Merkezi", Type = "Teknik Alan", IsActive = true, CreatedAt = CreatedAt },
            new Location { Id = technicalBlockId, Code = "LOC-TB", Name = "Teknik Blok", Type = "Teknik Alan", IsActive = true, CreatedAt = CreatedAt },
            new Location { Id = apronId, Code = "LOC-APR", Name = "Apron Bölgesi", Type = "Saha", IsActive = true, CreatedAt = CreatedAt }
        );

        var generatorSystemId = Guid.Parse("30000000-0000-0000-0000-000000000001");
        var upsSystemId = Guid.Parse("30000000-0000-0000-0000-000000000002");
        var hvacSystemId = Guid.Parse("30000000-0000-0000-0000-000000000003");
        var electricalSystemId = Guid.Parse("30000000-0000-0000-0000-000000000004");
        var automationSystemId = Guid.Parse("30000000-0000-0000-0000-000000000005");

        modelBuilder.Entity<TechnicalSystem>().HasData(
            new TechnicalSystem { Id = generatorSystemId, Code = "SYS-GEN", Name = "Jeneratör", IsActive = true, CreatedAt = CreatedAt },
            new TechnicalSystem { Id = upsSystemId, Code = "SYS-UPS", Name = "UPS", IsActive = true, CreatedAt = CreatedAt },
            new TechnicalSystem { Id = hvacSystemId, Code = "SYS-HVAC", Name = "HVAC", IsActive = true, CreatedAt = CreatedAt },
            new TechnicalSystem { Id = electricalSystemId, Code = "SYS-ELC", Name = "Elektrik", IsActive = true, CreatedAt = CreatedAt },
            new TechnicalSystem { Id = automationSystemId, Code = "SYS-AUT", Name = "Otomasyon Paneli", IsActive = true, CreatedAt = CreatedAt }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.Parse("40000000-0000-0000-0000-000000000001"), RoleId = AdminRoleId, FullName = "Admin Kullanıcı", Username = "admin", Email = "admin@demo.local", PasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", Title = "Sistem Yöneticisi", Department = "BT", IsActive = true, CreatedAt = CreatedAt },
            new User { Id = Guid.Parse("40000000-0000-0000-0000-000000000002"), RoleId = ManagerRoleId, FullName = "Teknik Yönetici", Username = "yonetici", Email = "yonetici@demo.local", PasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy1tYW5hZ2VyMQ==$2JU5bt9x2uS/3kp8oY1vE/qobOLfoTy1SkB90ybtopU=", Title = "Teknik Yönetici", Department = "Teknik Otomasyon", IsActive = true, CreatedAt = CreatedAt },
            new User { Id = Guid.Parse("40000000-0000-0000-0000-000000000003"), RoleId = TechnicianRoleId, FullName = "Teknik Personel 1", Username = "teknik1", Email = "teknik1@demo.local", PasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy10ZWNoLTAwMQ==$sf498N38LrE5MyaWcpBXOto0kRMQNFh+bvhz0I6fpSQ=", Title = "Teknik Personel", Department = "Teknik Otomasyon", IsActive = true, CreatedAt = CreatedAt },
            new User { Id = Guid.Parse("40000000-0000-0000-0000-000000000004"), RoleId = OperatorRoleId, FullName = "Operatör 1", Username = "operator1", Email = "operator1@demo.local", PasswordHash = "pbkdf2-sha256$100000$dGVjaG9wcy1vcGVyLTAwMQ==$f3lnNMIH5Qx0gyXdU4xxnWGdeU3DhcO+MKX/Xooisp0=", Title = "Operatör", Department = "Operasyon", IsActive = true, CreatedAt = CreatedAt }
        );

        modelBuilder.Entity<Equipment>().HasData(
            new Equipment { Id = Guid.Parse("50000000-0000-0000-0000-000000000001"), LocationId = terminal2Id, TechnicalSystemId = generatorSystemId, Code = "EQ-00032", Name = "Generator-T2-01", Brand = "DemoPower", Model = "G-750X", SerialNo = "SN-DEMO-00032", Status = EquipmentStatus.Active, CommissionedAt = new DateOnly(2018, 3, 15), IsActive = true, CreatedAt = CreatedAt },
            new Equipment { Id = Guid.Parse("50000000-0000-0000-0000-000000000002"), LocationId = energyCenterId, TechnicalSystemId = upsSystemId, Code = "EQ-00045", Name = "UPS-EM-02", Brand = "DemoUPS", Model = "UPS-200", SerialNo = "SN-DEMO-00045", Status = EquipmentStatus.Active, IsActive = true, CreatedAt = CreatedAt },
            new Equipment { Id = Guid.Parse("50000000-0000-0000-0000-000000000003"), LocationId = terminal1Id, TechnicalSystemId = hvacSystemId, Code = "EQ-00051", Name = "AHU-T1-04", Brand = "DemoAir", Model = "AHU-400", SerialNo = "SN-DEMO-00051", Status = EquipmentStatus.Maintenance, IsActive = true, CreatedAt = CreatedAt },
            new Equipment { Id = Guid.Parse("50000000-0000-0000-0000-000000000004"), LocationId = technicalBlockId, TechnicalSystemId = automationSystemId, Code = "EQ-00067", Name = "PLC-PNL-03", Brand = "DemoPLC", Model = "PLC-1500", SerialNo = "SN-DEMO-00067", Status = EquipmentStatus.Active, IsActive = true, CreatedAt = CreatedAt }
        );

        modelBuilder.Entity<MaintenancePlan>().HasData(
            new MaintenancePlan { Id = Guid.Parse("70000000-0000-0000-0000-000000000001"), PlanNo = "BKM-2026-001", EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000001"), ResponsibleUserId = Guid.Parse("40000000-0000-0000-0000-000000000003"), CreatedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000001"), MaintenanceType = "6 Aylık", PlannedDate = new DateOnly(2026, 8, 20), Frequency = "6 Aylık", Priority = FaultPriority.Medium, Status = MaintenanceStatus.Planned, Description = "Jeneratör yakıt, yağ, filtre ve otomatik transfer panosu kontrolleri yapılacak.", CreatedAt = CreatedAt },
            new MaintenancePlan { Id = Guid.Parse("70000000-0000-0000-0000-000000000002"), PlanNo = "BKM-2026-002", EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000003"), ResponsibleUserId = Guid.Parse("40000000-0000-0000-0000-000000000003"), CreatedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000001"), MaintenanceType = "Aylık", PlannedDate = new DateOnly(2026, 8, 11), Frequency = "Aylık", Priority = FaultPriority.High, Status = MaintenanceStatus.Started, Description = "HVAC ünitesi filtre, kayış, drenaj hattı ve sıcaklık sensörü kontrolleri yapılacak.", StartedAt = new DateTime(2026, 8, 11, 8, 30, 0, DateTimeKind.Utc), CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 11, 8, 30, 0, DateTimeKind.Utc) },
            new MaintenancePlan { Id = Guid.Parse("70000000-0000-0000-0000-000000000003"), PlanNo = "BKM-2026-003", EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000002"), ResponsibleUserId = Guid.Parse("40000000-0000-0000-0000-000000000002"), CreatedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000001"), MaintenanceType = "Yıllık", PlannedDate = new DateOnly(2026, 8, 5), Frequency = "Yıllık", Priority = FaultPriority.Critical, Status = MaintenanceStatus.Planned, Description = "UPS batarya bloğu, bypass hattı ve yük aktarım testi planlandı.", CreatedAt = CreatedAt },
            new MaintenancePlan { Id = Guid.Parse("70000000-0000-0000-0000-000000000004"), PlanNo = "BKM-2026-004", EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000004"), ResponsibleUserId = Guid.Parse("40000000-0000-0000-0000-000000000003"), CreatedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000001"), MaintenanceType = "3 Aylık", PlannedDate = new DateOnly(2026, 8, 1), Frequency = "3 Aylık", Priority = FaultPriority.Medium, Status = MaintenanceStatus.Completed, Description = "PLC panel klemens, güç kaynağı ve haberleşme modülü bakımı tamamlandı.", StartedAt = new DateTime(2026, 8, 1, 9, 0, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc), CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc) },
            new MaintenancePlan { Id = Guid.Parse("70000000-0000-0000-0000-000000000005"), PlanNo = "BKM-2026-005", EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000001"), ResponsibleUserId = Guid.Parse("40000000-0000-0000-0000-000000000003"), CreatedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000001"), MaintenanceType = "Haftalık", PlannedDate = new DateOnly(2026, 7, 28), Frequency = "Haftalık", Priority = FaultPriority.Low, Status = MaintenanceStatus.Completed, Description = "Haftalık jeneratör saha kontrolü tamamlandı.", StartedAt = new DateTime(2026, 7, 28, 7, 45, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc), CreatedAt = CreatedAt, UpdatedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc) }
        );

        modelBuilder.Entity<MaintenanceRecord>().HasData(
            new MaintenanceRecord { Id = Guid.Parse("71000000-0000-0000-0000-000000000001"), MaintenancePlanId = Guid.Parse("70000000-0000-0000-0000-000000000004"), EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000004"), PerformedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000003"), MaintenanceType = "3 Aylık", StartedAt = new DateTime(2026, 8, 1, 9, 0, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc), ResultStatus = MaintenanceResultStatus.Completed, Description = "PLC panel içi temizlik, klemens sıkılık kontrolü ve yedek güç kaynağı testi tamamlandı.", UsedMaterials = "Klemens etiketi, temizlik spreyi", ChecklistJson = "[{\"Text\":\"Fiziksel hasar kontrolü yapıldı.\",\"IsChecked\":true},{\"Text\":\"Bağlantı klemensleri sıkıldı.\",\"IsChecked\":true},{\"Text\":\"Haberleşme testi yapıldı.\",\"IsChecked\":true}]", CreatedAt = new DateTime(2026, 8, 1, 11, 20, 0, DateTimeKind.Utc) },
            new MaintenanceRecord { Id = Guid.Parse("71000000-0000-0000-0000-000000000002"), MaintenancePlanId = Guid.Parse("70000000-0000-0000-0000-000000000005"), EquipmentId = Guid.Parse("50000000-0000-0000-0000-000000000001"), PerformedByUserId = Guid.Parse("40000000-0000-0000-0000-000000000003"), MaintenanceType = "Haftalık", StartedAt = new DateTime(2026, 7, 28, 7, 45, 0, DateTimeKind.Utc), CompletedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc), ResultStatus = MaintenanceResultStatus.Completed, Description = "Jeneratör çalışma testi, sıvı seviye kontrolleri ve görsel saha kontrolü tamamlandı.", UsedMaterials = "Kontrol formu", ChecklistJson = "[{\"Text\":\"Yağ ve yakıt seviyesi kontrol edildi.\",\"IsChecked\":true},{\"Text\":\"Sızıntı kontrolü yapıldı.\",\"IsChecked\":true},{\"Text\":\"Test çalıştırması tamamlandı.\",\"IsChecked\":true}]", CreatedAt = new DateTime(2026, 7, 28, 8, 25, 0, DateTimeKind.Utc) }
        );
    }
}
