using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsSystemRole = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Username = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnicalSystemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Brand = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    Model = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    SerialNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CommissionedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_TechnicalSystems_TechnicalSystemId",
                        column: x => x.TechnicalSystemId,
                        principalTable: "TechnicalSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    EntityName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Action = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    OldValues = table.Column<string>(type: "jsonb", nullable: true),
                    NewValues = table.Column<string>(type: "jsonb", nullable: true),
                    IpAddress = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RelatedEntityName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    RelatedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftHandovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HandoverNo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShiftType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ShiftDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HandoverFromUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    HandoverToUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    CriticalNotes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftHandovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftHandovers_Users_HandoverFromUserId",
                        column: x => x.HandoverFromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftHandovers_Users_HandoverToUserId",
                        column: x => x.HandoverToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FaultNo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnicalSystemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedToUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ResolvedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClosedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Source = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ResolutionDescription = table.Column<string>(type: "text", nullable: true),
                    WaitingReason = table.Column<string>(type: "text", nullable: true),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faults_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faults_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faults_TechnicalSystems_TechnicalSystemId",
                        column: x => x.TechnicalSystemId,
                        principalTable: "TechnicalSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faults_Users_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faults_Users_ClosedByUserId",
                        column: x => x.ClosedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faults_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faults_Users_ResolvedByUserId",
                        column: x => x.ResolvedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanNo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsibleUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaintenanceType = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    PlannedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Frequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Priority = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenancePlans_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenancePlans_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenancePlans_Users_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsibleUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestType = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    PlannedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Frequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPlans_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestPlans_Users_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaultActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FaultId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OldStatus = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    NewStatus = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Metadata = table.Column<string>(type: "jsonb", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaultActions_Faults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaultActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaintenancePlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerformedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaintenanceType = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResultStatus = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UsedMaterials = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_MaintenancePlans_MaintenancePlanId",
                        column: x => x.MaintenancePlanId,
                        principalTable: "MaintenancePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Users_PerformedByUserId",
                        column: x => x.PerformedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftHandoverId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FaultId = table.Column<Guid>(type: "uuid", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    MaintenancePlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    Priority = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftItems_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftItems_Faults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftItems_MaintenancePlans_MaintenancePlanId",
                        column: x => x.MaintenancePlanId,
                        principalTable: "MaintenancePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftItems_ShiftHandovers_ShiftHandoverId",
                        column: x => x.ShiftHandoverId,
                        principalTable: "ShiftHandovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TestType = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: true),
                    Result = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AbnormalCondition = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRecords_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRecords_TestPlans_TestPlanId",
                        column: x => x.TestPlanId,
                        principalTable: "TestPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TestRecords_Users_TestedByUserId",
                        column: x => x.TestedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "ParentLocationId", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "LOC-T1", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Terminal 1", null, "Terminal", null },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "LOC-T2", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Terminal 2", null, "Terminal", null },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "LOC-EM", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Enerji Merkezi", null, "Teknik Alan", null },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "LOC-TB", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Teknik Blok", null, "Teknik Alan", null },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "LOC-APR", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Apron Bölgesi", null, "Saha", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "IsSystemRole", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sistem yöneticisi", true, "Admin", null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Operasyonu ve raporları izler", true, "Yönetici", null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Arıza, bakım ve test işlemlerini yürütür", true, "Teknik Personel", null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Olay ve arıza kaydı oluşturur", true, "Operatör", null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Devir teslim süreçlerini yönetir", true, "Vardiya Personeli", null },
                    { new Guid("10000000-0000-0000-0000-000000000006"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Dashboard ve raporları görüntüler", true, "Rapor Kullanıcısı", null }
                });

            migrationBuilder.InsertData(
                table: "TechnicalSystems",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "SYS-GEN", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Jeneratör", null },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "SYS-UPS", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "UPS", null },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "SYS-HVAC", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "HVAC", null },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "SYS-ELC", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Elektrik", null },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "SYS-AUT", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "Otomasyon Paneli", null }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Brand", "Code", "CommissionedAt", "CreatedAt", "Description", "IsActive", "LocationId", "Model", "Name", "SerialNo", "Status", "TechnicalSystemId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), "DemoPower", "EQ-00032", new DateOnly(2018, 3, 15), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "Generator-T2-01", "SN-DEMO-00032", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000000002"), "DemoUPS", "EQ-00045", null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, new Guid("20000000-0000-0000-0000-000000000003"), "UPS-200", "UPS-EM-02", "SN-DEMO-00045", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000000003"), "DemoAir", "EQ-00051", null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-T1-04", "SN-DEMO-00051", "Maintenance", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000000004"), "DemoPLC", "EQ-00067", null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, true, new Guid("20000000-0000-0000-0000-000000000004"), "PLC-1500", "PLC-PNL-03", "SN-DEMO-00067", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Department", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "RoleId", "Title", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "BT", "admin@demo.local", "Admin Kullanıcı", true, null, "demo-hash", new Guid("10000000-0000-0000-0000-000000000001"), "Sistem Yöneticisi", null, "admin" },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "yonetici@demo.local", "Teknik Yönetici", true, null, "demo-hash", new Guid("10000000-0000-0000-0000-000000000002"), "Teknik Yönetici", null, "yonetici" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik1@demo.local", "Teknik Personel 1", true, null, "demo-hash", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik1" },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Operasyon", "operator1@demo.local", "Operatör 1", true, null, "demo-hash", new Guid("10000000-0000-0000-0000-000000000004"), "Operatör", null, "operator1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Code",
                table: "Equipment",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_LocationId",
                table: "Equipment",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Status",
                table: "Equipment",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_TechnicalSystemId",
                table: "Equipment",
                column: "TechnicalSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultActions_CreatedAt",
                table: "FaultActions",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_FaultActions_FaultId",
                table: "FaultActions",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultActions_UserId",
                table: "FaultActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_AssignedToUserId",
                table: "Faults",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_ClosedByUserId",
                table: "Faults",
                column: "ClosedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_CreatedAt",
                table: "Faults",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_CreatedByUserId",
                table: "Faults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_EquipmentId",
                table: "Faults",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_FaultNo",
                table: "Faults",
                column: "FaultNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faults_LocationId",
                table: "Faults",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_Priority",
                table: "Faults",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_ResolvedByUserId",
                table: "Faults",
                column: "ResolvedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_Status",
                table: "Faults",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_Status_Priority",
                table: "Faults",
                columns: new[] { "Status", "Priority" });

            migrationBuilder.CreateIndex(
                name: "IX_Faults_TechnicalSystemId",
                table: "Faults",
                column: "TechnicalSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Code",
                table: "Locations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParentLocationId",
                table: "Locations",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_CreatedByUserId",
                table: "MaintenancePlans",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_EquipmentId",
                table: "MaintenancePlans",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_PlannedDate",
                table: "MaintenancePlans",
                column: "PlannedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_PlanNo",
                table: "MaintenancePlans",
                column: "PlanNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_ResponsibleUserId",
                table: "MaintenancePlans",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_Status",
                table: "MaintenancePlans",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_CompletedAt",
                table: "MaintenanceRecords",
                column: "CompletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_EquipmentId",
                table: "MaintenanceRecords",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_MaintenancePlanId",
                table: "MaintenanceRecords",
                column: "MaintenancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_PerformedByUserId",
                table: "MaintenanceRecords",
                column: "PerformedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHandovers_HandoverFromUserId",
                table: "ShiftHandovers",
                column: "HandoverFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHandovers_HandoverNo",
                table: "ShiftHandovers",
                column: "HandoverNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHandovers_HandoverToUserId",
                table: "ShiftHandovers",
                column: "HandoverToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHandovers_ShiftDate",
                table: "ShiftHandovers",
                column: "ShiftDate");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftHandovers_ShiftType",
                table: "ShiftHandovers",
                column: "ShiftType");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftItems_EquipmentId",
                table: "ShiftItems",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftItems_FaultId",
                table: "ShiftItems",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftItems_MaintenancePlanId",
                table: "ShiftItems",
                column: "MaintenancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftItems_ShiftHandoverId",
                table: "ShiftItems",
                column: "ShiftHandoverId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSystems_Code",
                table: "TechnicalSystems",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSystems_Name",
                table: "TechnicalSystems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_EquipmentId",
                table: "TestPlans",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_PlannedDate",
                table: "TestPlans",
                column: "PlannedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_ResponsibleUserId",
                table: "TestPlans",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_Status",
                table: "TestPlans",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_EquipmentId",
                table: "TestRecords",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_Result",
                table: "TestRecords",
                column: "Result");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestDate",
                table: "TestRecords",
                column: "TestDate");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestedByUserId",
                table: "TestRecords",
                column: "TestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestPlanId",
                table: "TestRecords",
                column: "TestPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "FaultActions");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ShiftItems");

            migrationBuilder.DropTable(
                name: "TestRecords");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "MaintenancePlans");

            migrationBuilder.DropTable(
                name: "ShiftHandovers");

            migrationBuilder.DropTable(
                name: "TestPlans");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "TechnicalSystems");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
