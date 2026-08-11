using Microsoft.EntityFrameworkCore;
using TechOps.Api.Entities;

namespace TechOps.Api.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<TechnicalSystem> TechnicalSystems => Set<TechnicalSystem>();
    public DbSet<Equipment> Equipment => Set<Equipment>();
    public DbSet<Fault> Faults => Set<Fault>();
    public DbSet<FaultAction> FaultActions => Set<FaultAction>();
    public DbSet<MaintenancePlan> MaintenancePlans => Set<MaintenancePlan>();
    public DbSet<MaintenanceRecord> MaintenanceRecords => Set<MaintenanceRecord>();
    public DbSet<TestPlan> TestPlans => Set<TestPlan>();
    public DbSet<TestRecord> TestRecords => Set<TestRecord>();
    public DbSet<ShiftHandover> ShiftHandovers => Set<ShiftHandover>();
    public DbSet<ShiftItem> ShiftItems => Set<ShiftItem>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(x => x.Username).IsUnique();
            entity.HasIndex(x => x.Email).IsUnique();
            entity.HasIndex(x => x.RoleId);
            entity.Property(x => x.FullName).HasMaxLength(120);
            entity.Property(x => x.Username).HasMaxLength(80);
            entity.Property(x => x.Email).HasMaxLength(160);
            entity.Property(x => x.Title).HasMaxLength(100);
            entity.Property(x => x.Department).HasMaxLength(100);
            entity.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasIndex(x => x.Code).IsUnique();
            entity.HasIndex(x => x.ParentLocationId);
            entity.Property(x => x.Code).HasMaxLength(30);
            entity.Property(x => x.Name).HasMaxLength(120);
            entity.Property(x => x.Type).HasMaxLength(50);
            entity.HasOne(x => x.ParentLocation).WithMany(x => x.ChildLocations).HasForeignKey(x => x.ParentLocationId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TechnicalSystem>(entity =>
        {
            entity.HasIndex(x => x.Code).IsUnique();
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Code).HasMaxLength(30);
            entity.Property(x => x.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasIndex(x => x.Code).IsUnique();
            entity.HasIndex(x => x.LocationId);
            entity.HasIndex(x => x.TechnicalSystemId);
            entity.HasIndex(x => x.Status);
            entity.Property(x => x.Code).HasMaxLength(40);
            entity.Property(x => x.Name).HasMaxLength(120);
            entity.Property(x => x.Brand).HasMaxLength(80);
            entity.Property(x => x.Model).HasMaxLength(80);
            entity.Property(x => x.SerialNo).HasMaxLength(100);
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            entity.HasOne(x => x.Location).WithMany(x => x.Equipment).HasForeignKey(x => x.LocationId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.TechnicalSystem).WithMany(x => x.Equipment).HasForeignKey(x => x.TechnicalSystemId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Fault>(entity =>
        {
            entity.HasIndex(x => x.FaultNo).IsUnique();
            entity.HasIndex(x => x.EquipmentId);
            entity.HasIndex(x => x.LocationId);
            entity.HasIndex(x => x.TechnicalSystemId);
            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.Priority);
            entity.HasIndex(x => x.CreatedAt);
            entity.HasIndex(x => x.AssignedToUserId);
            entity.HasIndex(x => new { x.Status, x.Priority });
            entity.Property(x => x.FaultNo).HasMaxLength(40);
            entity.Property(x => x.Source).HasConversion<string>().HasMaxLength(50);
            entity.Property(x => x.Priority).HasConversion<string>().HasMaxLength(20);
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            entity.HasOne(x => x.Equipment).WithMany(x => x.Faults).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Location).WithMany(x => x.Faults).HasForeignKey(x => x.LocationId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.TechnicalSystem).WithMany(x => x.Faults).HasForeignKey(x => x.TechnicalSystemId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedFaults).HasForeignKey(x => x.CreatedByUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.AssignedToUser).WithMany(x => x.AssignedFaults).HasForeignKey(x => x.AssignedToUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.ResolvedByUser).WithMany(x => x.ResolvedFaults).HasForeignKey(x => x.ResolvedByUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.ClosedByUser).WithMany(x => x.ClosedFaults).HasForeignKey(x => x.ClosedByUserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<FaultAction>(entity =>
        {
            entity.HasIndex(x => x.FaultId);
            entity.HasIndex(x => x.UserId);
            entity.HasIndex(x => x.CreatedAt);
            entity.Property(x => x.ActionType).HasMaxLength(50);
            entity.Property(x => x.OldStatus).HasConversion<string>().HasMaxLength(30);
            entity.Property(x => x.NewStatus).HasConversion<string>().HasMaxLength(30);
            entity.Property(x => x.Metadata).HasColumnType("jsonb");
            entity.HasOne(x => x.Fault).WithMany(x => x.Actions).HasForeignKey(x => x.FaultId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.User).WithMany(x => x.FaultActions).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MaintenancePlan>(entity =>
        {
            entity.HasIndex(x => x.PlanNo).IsUnique();
            entity.HasIndex(x => x.EquipmentId);
            entity.HasIndex(x => x.ResponsibleUserId);
            entity.HasIndex(x => x.PlannedDate);
            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.StartedAt);
            entity.HasIndex(x => x.CompletedAt);
            entity.Property(x => x.PlanNo).HasMaxLength(40);
            entity.Property(x => x.MaintenanceType).HasMaxLength(80);
            entity.Property(x => x.Frequency).HasMaxLength(50);
            entity.Property(x => x.Priority).HasConversion<string>().HasMaxLength(20);
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            entity.HasOne(x => x.Equipment).WithMany(x => x.MaintenancePlans).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.ResponsibleUser).WithMany(x => x.ResponsibleMaintenancePlans).HasForeignKey(x => x.ResponsibleUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedMaintenancePlans).HasForeignKey(x => x.CreatedByUserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MaintenanceRecord>(entity =>
        {
            entity.HasIndex(x => x.EquipmentId);
            entity.HasIndex(x => x.CompletedAt);
            entity.HasIndex(x => x.PerformedByUserId);
            entity.Property(x => x.MaintenanceType).HasMaxLength(80);
            entity.Property(x => x.ResultStatus).HasConversion<string>().HasMaxLength(30);
            entity.Property(x => x.ChecklistJson).HasColumnType("jsonb");
            entity.HasOne(x => x.MaintenancePlan).WithMany(x => x.Records).HasForeignKey(x => x.MaintenancePlanId).OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(x => x.Equipment).WithMany(x => x.MaintenanceRecords).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.PerformedByUser).WithMany(x => x.MaintenanceRecords).HasForeignKey(x => x.PerformedByUserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TestPlan>(entity =>
        {
            entity.HasIndex(x => x.EquipmentId);
            entity.HasIndex(x => x.PlannedDate);
            entity.HasIndex(x => x.Status);
            entity.Property(x => x.TestType).HasMaxLength(80);
            entity.Property(x => x.Frequency).HasMaxLength(50);
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            entity.HasOne(x => x.Equipment).WithMany(x => x.TestPlans).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.ResponsibleUser).WithMany(x => x.ResponsibleTestPlans).HasForeignKey(x => x.ResponsibleUserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TestRecord>(entity =>
        {
            entity.HasIndex(x => x.EquipmentId);
            entity.HasIndex(x => x.TestDate);
            entity.HasIndex(x => x.Result);
            entity.Property(x => x.TestType).HasMaxLength(80);
            entity.Property(x => x.Result).HasConversion<string>().HasMaxLength(30);
            entity.HasOne(x => x.TestPlan).WithMany(x => x.Records).HasForeignKey(x => x.TestPlanId).OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(x => x.Equipment).WithMany(x => x.TestRecords).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.TestedByUser).WithMany(x => x.TestRecords).HasForeignKey(x => x.TestedByUserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ShiftHandover>(entity =>
        {
            entity.HasIndex(x => x.HandoverNo).IsUnique();
            entity.HasIndex(x => x.ShiftDate);
            entity.HasIndex(x => x.ShiftType);
            entity.Property(x => x.HandoverNo).HasMaxLength(40);
            entity.Property(x => x.ShiftType).HasConversion<string>().HasMaxLength(30);
            entity.HasOne(x => x.HandoverFromUser).WithMany(x => x.ShiftHandoversFrom).HasForeignKey(x => x.HandoverFromUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.HandoverToUser).WithMany(x => x.ShiftHandoversTo).HasForeignKey(x => x.HandoverToUserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ShiftItem>(entity =>
        {
            entity.HasIndex(x => x.ShiftHandoverId);
            entity.HasIndex(x => x.FaultId);
            entity.HasIndex(x => x.EquipmentId);
            entity.Property(x => x.ItemType).HasConversion<string>().HasMaxLength(50);
            entity.Property(x => x.Title).HasMaxLength(160);
            entity.Property(x => x.Priority).HasConversion<string>().HasMaxLength(20);
            entity.HasOne(x => x.ShiftHandover).WithMany(x => x.Items).HasForeignKey(x => x.ShiftHandoverId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Fault).WithMany(x => x.ShiftItems).HasForeignKey(x => x.FaultId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Equipment).WithMany(x => x.ShiftItems).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.MaintenancePlan).WithMany(x => x.ShiftItems).HasForeignKey(x => x.MaintenancePlanId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.Property(x => x.EntityName).HasMaxLength(80);
            entity.Property(x => x.Action).HasMaxLength(80);
            entity.Property(x => x.IpAddress).HasMaxLength(60);
            entity.Property(x => x.OldValues).HasColumnType("jsonb");
            entity.Property(x => x.NewValues).HasColumnType("jsonb");
            entity.HasOne(x => x.User).WithMany(x => x.AuditLogs).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(x => x.Title).HasMaxLength(160);
            entity.Property(x => x.Type).HasConversion<string>().HasMaxLength(50);
            entity.Property(x => x.RelatedEntityName).HasMaxLength(80);
            entity.HasOne(x => x.User).WithMany(x => x.Notifications).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        SeedData.Apply(modelBuilder);
    }
}
