using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExpandSyntheticDemoDataForAnalysis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "EntityId", "EntityName", "IpAddress", "NewValues", "OldValues", "UpdatedAt", "UserAgent", "UserId" },
                values: new object[,]
                {
                    { new Guid("80000000-0000-0000-0000-000000001001"), "Update", new DateTime(2026, 7, 3, 1, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.1", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001002"), "StatusChange", new DateTime(2026, 7, 3, 2, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.2", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001003"), "Export", new DateTime(2026, 7, 3, 3, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.3", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001004"), "View", new DateTime(2026, 7, 3, 4, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.4", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001005"), "Create", new DateTime(2026, 7, 3, 5, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.5", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001006"), "Update", new DateTime(2026, 7, 3, 6, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.6", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001007"), "StatusChange", new DateTime(2026, 7, 3, 7, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.7", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001008"), "Export", new DateTime(2026, 7, 3, 8, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.8", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001009"), "View", new DateTime(2026, 7, 3, 9, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.9", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001010"), "Create", new DateTime(2026, 7, 3, 10, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.10", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001011"), "Update", new DateTime(2026, 7, 3, 11, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.11", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001012"), "StatusChange", new DateTime(2026, 7, 3, 12, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.12", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001013"), "Export", new DateTime(2026, 7, 3, 13, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.13", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001014"), "View", new DateTime(2026, 7, 3, 14, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.14", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001015"), "Create", new DateTime(2026, 7, 3, 15, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.15", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001016"), "Update", new DateTime(2026, 7, 3, 16, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.16", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001017"), "StatusChange", new DateTime(2026, 7, 3, 17, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.17", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001018"), "Export", new DateTime(2026, 7, 3, 18, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.18", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001019"), "View", new DateTime(2026, 7, 3, 19, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.19", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001020"), "Create", new DateTime(2026, 7, 3, 20, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.20", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001021"), "Update", new DateTime(2026, 7, 3, 21, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.21", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001022"), "StatusChange", new DateTime(2026, 7, 3, 22, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.22", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001023"), "Export", new DateTime(2026, 7, 3, 23, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.23", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001024"), "View", new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.24", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001025"), "Create", new DateTime(2026, 7, 4, 1, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.25", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001026"), "Update", new DateTime(2026, 7, 4, 2, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.26", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001027"), "StatusChange", new DateTime(2026, 7, 4, 3, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.27", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001028"), "Export", new DateTime(2026, 7, 4, 4, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.28", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001029"), "View", new DateTime(2026, 7, 4, 5, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.29", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001030"), "Create", new DateTime(2026, 7, 4, 6, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.30", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001031"), "Update", new DateTime(2026, 7, 4, 7, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.31", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001032"), "StatusChange", new DateTime(2026, 7, 4, 8, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.32", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001033"), "Export", new DateTime(2026, 7, 4, 9, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.33", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001034"), "View", new DateTime(2026, 7, 4, 10, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.34", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001035"), "Create", new DateTime(2026, 7, 4, 11, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.35", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001036"), "Update", new DateTime(2026, 7, 4, 12, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.36", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001037"), "StatusChange", new DateTime(2026, 7, 4, 13, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.37", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001038"), "Export", new DateTime(2026, 7, 4, 14, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.38", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001039"), "View", new DateTime(2026, 7, 4, 15, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.39", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001040"), "Create", new DateTime(2026, 7, 4, 16, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.40", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001041"), "Update", new DateTime(2026, 7, 4, 17, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.41", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001042"), "StatusChange", new DateTime(2026, 7, 4, 18, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.42", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001043"), "Export", new DateTime(2026, 7, 4, 19, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.43", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001044"), "View", new DateTime(2026, 7, 4, 20, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.44", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001045"), "Create", new DateTime(2026, 7, 4, 21, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.45", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001046"), "Update", new DateTime(2026, 7, 4, 22, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.46", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001047"), "StatusChange", new DateTime(2026, 7, 4, 23, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.47", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001048"), "Export", new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.48", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001049"), "View", new DateTime(2026, 7, 5, 1, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.49", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001050"), "Create", new DateTime(2026, 7, 5, 2, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.50", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001051"), "Update", new DateTime(2026, 7, 5, 3, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.51", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001052"), "StatusChange", new DateTime(2026, 7, 5, 4, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.52", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001053"), "Export", new DateTime(2026, 7, 5, 5, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.53", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001054"), "View", new DateTime(2026, 7, 5, 6, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.54", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001055"), "Create", new DateTime(2026, 7, 5, 7, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.55", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001056"), "Update", new DateTime(2026, 7, 5, 8, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.56", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001057"), "StatusChange", new DateTime(2026, 7, 5, 9, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.57", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001058"), "Export", new DateTime(2026, 7, 5, 10, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.58", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001059"), "View", new DateTime(2026, 7, 5, 11, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.59", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001060"), "Create", new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.60", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001061"), "Update", new DateTime(2026, 7, 5, 13, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.61", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001062"), "StatusChange", new DateTime(2026, 7, 5, 14, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.62", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001063"), "Export", new DateTime(2026, 7, 5, 15, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.63", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001064"), "View", new DateTime(2026, 7, 5, 16, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.64", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001065"), "Create", new DateTime(2026, 7, 5, 17, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.65", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001066"), "Update", new DateTime(2026, 7, 5, 18, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.66", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001067"), "StatusChange", new DateTime(2026, 7, 5, 19, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.67", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001068"), "Export", new DateTime(2026, 7, 5, 20, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.68", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001069"), "View", new DateTime(2026, 7, 5, 21, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.69", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001070"), "Create", new DateTime(2026, 7, 5, 22, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.70", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001071"), "Update", new DateTime(2026, 7, 5, 23, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.71", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001072"), "StatusChange", new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.72", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001073"), "Export", new DateTime(2026, 7, 6, 1, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.73", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001074"), "View", new DateTime(2026, 7, 6, 2, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.74", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001075"), "Create", new DateTime(2026, 7, 6, 3, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.75", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001076"), "Update", new DateTime(2026, 7, 6, 4, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.76", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001077"), "StatusChange", new DateTime(2026, 7, 6, 5, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.77", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001078"), "Export", new DateTime(2026, 7, 6, 6, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.78", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001079"), "View", new DateTime(2026, 7, 6, 7, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.79", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001080"), "Create", new DateTime(2026, 7, 6, 8, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.80", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001081"), "Update", new DateTime(2026, 7, 6, 9, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.81", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001082"), "StatusChange", new DateTime(2026, 7, 6, 10, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.82", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001083"), "Export", new DateTime(2026, 7, 6, 11, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.83", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001084"), "View", new DateTime(2026, 7, 6, 12, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.84", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001085"), "Create", new DateTime(2026, 7, 6, 13, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.85", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001086"), "Update", new DateTime(2026, 7, 6, 14, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.86", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001087"), "StatusChange", new DateTime(2026, 7, 6, 15, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.87", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001088"), "Export", new DateTime(2026, 7, 6, 16, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.88", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001089"), "View", new DateTime(2026, 7, 6, 17, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.89", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001090"), "Create", new DateTime(2026, 7, 6, 18, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.90", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001091"), "Update", new DateTime(2026, 7, 6, 19, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.91", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001092"), "StatusChange", new DateTime(2026, 7, 6, 20, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.92", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001093"), "Export", new DateTime(2026, 7, 6, 21, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.93", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001094"), "View", new DateTime(2026, 7, 6, 22, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.94", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001095"), "Create", new DateTime(2026, 7, 6, 23, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.95", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001096"), "Update", new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, "MaintenancePlan", "10.10.0.96", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("80000000-0000-0000-0000-000000001097"), "StatusChange", new DateTime(2026, 7, 7, 1, 0, 0, 0, DateTimeKind.Utc), null, "TestRecord", "10.10.0.97", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("80000000-0000-0000-0000-000000001098"), "Export", new DateTime(2026, 7, 7, 2, 0, 0, 0, DateTimeKind.Utc), null, "ShiftHandover", "10.10.0.98", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("80000000-0000-0000-0000-000000001099"), "View", new DateTime(2026, 7, 7, 3, 0, 0, 0, DateTimeKind.Utc), null, "Equipment", "10.10.0.99", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("80000000-0000-0000-0000-000000001100"), "Create", new DateTime(2026, 7, 7, 4, 0, 0, 0, DateTimeKind.Utc), null, "Fault", "10.10.0.100", "{}", "{}", null, "SyntheticDemo/1.0", new Guid("40000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Brand", "Code", "CommissionedAt", "CreatedAt", "Description", "IsActive", "LocationId", "Model", "Name", "SerialNo", "Status", "TechnicalSystemId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000001001"), "DemoPower", "EQ-01001", new DateOnly(2017, 5, 17), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-001", "SN-DEMO-01001", "Maintenance", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001002"), "DemoUPS", "EQ-01002", new DateOnly(2018, 6, 18), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-002", "SN-DEMO-01002", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001003"), "DemoAir", "EQ-01003", new DateOnly(2019, 7, 19), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-003", "SN-DEMO-01003", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001004"), "DemoVolt", "EQ-01004", new DateOnly(2020, 8, 20), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-004", "SN-DEMO-01004", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001005"), "DemoPLC", "EQ-01005", new DateOnly(2021, 9, 21), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-005", "SN-DEMO-01005", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001006"), "DemoPower", "EQ-01006", new DateOnly(2022, 10, 22), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-006", "SN-DEMO-01006", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001007"), "DemoUPS", "EQ-01007", new DateOnly(2023, 11, 23), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-007", "SN-DEMO-01007", "Faulted", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001008"), "DemoAir", "EQ-01008", new DateOnly(2016, 12, 24), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-008", "SN-DEMO-01008", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001009"), "DemoVolt", "EQ-01009", new DateOnly(2017, 1, 1), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-009", "SN-DEMO-01009", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001010"), "DemoPLC", "EQ-01010", new DateOnly(2018, 2, 2), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-010", "SN-DEMO-01010", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001011"), "DemoPower", "EQ-01011", new DateOnly(2019, 3, 3), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-011", "SN-DEMO-01011", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001012"), "DemoUPS", "EQ-01012", new DateOnly(2020, 4, 4), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-012", "SN-DEMO-01012", "Maintenance", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001013"), "DemoAir", "EQ-01013", new DateOnly(2021, 5, 5), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-013", "SN-DEMO-01013", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001014"), "DemoVolt", "EQ-01014", new DateOnly(2022, 6, 6), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-014", "SN-DEMO-01014", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001015"), "DemoPLC", "EQ-01015", new DateOnly(2023, 7, 7), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-015", "SN-DEMO-01015", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001016"), "DemoPower", "EQ-01016", new DateOnly(2016, 8, 8), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-016", "SN-DEMO-01016", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001017"), "DemoUPS", "EQ-01017", new DateOnly(2017, 9, 9), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-017", "SN-DEMO-01017", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001018"), "DemoAir", "EQ-01018", new DateOnly(2018, 10, 10), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-018", "SN-DEMO-01018", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001019"), "DemoVolt", "EQ-01019", new DateOnly(2019, 11, 11), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-019", "SN-DEMO-01019", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001020"), "DemoPLC", "EQ-01020", new DateOnly(2020, 12, 12), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-020", "SN-DEMO-01020", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001021"), "DemoPower", "EQ-01021", new DateOnly(2021, 1, 13), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-021", "SN-DEMO-01021", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001022"), "DemoUPS", "EQ-01022", new DateOnly(2022, 2, 14), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-022", "SN-DEMO-01022", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001023"), "DemoAir", "EQ-01023", new DateOnly(2023, 3, 15), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-023", "SN-DEMO-01023", "Maintenance", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001024"), "DemoVolt", "EQ-01024", new DateOnly(2016, 4, 16), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-024", "SN-DEMO-01024", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001025"), "DemoPLC", "EQ-01025", new DateOnly(2017, 5, 17), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-025", "SN-DEMO-01025", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001026"), "DemoPower", "EQ-01026", new DateOnly(2018, 6, 18), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-026", "SN-DEMO-01026", "Faulted", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001027"), "DemoUPS", "EQ-01027", new DateOnly(2019, 7, 19), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-027", "SN-DEMO-01027", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001028"), "DemoAir", "EQ-01028", new DateOnly(2020, 8, 20), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-028", "SN-DEMO-01028", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001029"), "DemoVolt", "EQ-01029", new DateOnly(2021, 9, 21), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-029", "SN-DEMO-01029", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001030"), "DemoPLC", "EQ-01030", new DateOnly(2022, 10, 22), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-030", "SN-DEMO-01030", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001031"), "DemoPower", "EQ-01031", new DateOnly(2023, 11, 23), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-031", "SN-DEMO-01031", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001032"), "DemoUPS", "EQ-01032", new DateOnly(2016, 12, 24), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-032", "SN-DEMO-01032", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001033"), "DemoAir", "EQ-01033", new DateOnly(2017, 1, 1), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-033", "SN-DEMO-01033", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001034"), "DemoVolt", "EQ-01034", new DateOnly(2018, 2, 2), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-034", "SN-DEMO-01034", "Maintenance", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001035"), "DemoPLC", "EQ-01035", new DateOnly(2019, 3, 3), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-035", "SN-DEMO-01035", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001036"), "DemoPower", "EQ-01036", new DateOnly(2020, 4, 4), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-036", "SN-DEMO-01036", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001037"), "DemoUPS", "EQ-01037", new DateOnly(2021, 5, 5), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-037", "SN-DEMO-01037", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001038"), "DemoAir", "EQ-01038", new DateOnly(2022, 6, 6), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-038", "SN-DEMO-01038", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001039"), "DemoVolt", "EQ-01039", new DateOnly(2023, 7, 7), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-039", "SN-DEMO-01039", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001040"), "DemoPLC", "EQ-01040", new DateOnly(2016, 8, 8), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-040", "SN-DEMO-01040", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001041"), "DemoPower", "EQ-01041", new DateOnly(2017, 9, 9), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-041", "SN-DEMO-01041", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001042"), "DemoUPS", "EQ-01042", new DateOnly(2018, 10, 10), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-042", "SN-DEMO-01042", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001043"), "DemoAir", "EQ-01043", new DateOnly(2019, 11, 11), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-043", "SN-DEMO-01043", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001044"), "DemoVolt", "EQ-01044", new DateOnly(2020, 12, 12), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-044", "SN-DEMO-01044", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001045"), "DemoPLC", "EQ-01045", new DateOnly(2021, 1, 13), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-045", "SN-DEMO-01045", "Faulted", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001046"), "DemoPower", "EQ-01046", new DateOnly(2022, 2, 14), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-046", "SN-DEMO-01046", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001047"), "DemoUPS", "EQ-01047", new DateOnly(2023, 3, 15), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-047", "SN-DEMO-01047", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001048"), "DemoAir", "EQ-01048", new DateOnly(2016, 4, 16), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-048", "SN-DEMO-01048", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001049"), "DemoVolt", "EQ-01049", new DateOnly(2017, 5, 17), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-049", "SN-DEMO-01049", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001050"), "DemoPLC", "EQ-01050", new DateOnly(2018, 6, 18), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-050", "SN-DEMO-01050", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001051"), "DemoPower", "EQ-01051", new DateOnly(2019, 7, 19), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-051", "SN-DEMO-01051", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001052"), "DemoUPS", "EQ-01052", new DateOnly(2020, 8, 20), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-052", "SN-DEMO-01052", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001053"), "DemoAir", "EQ-01053", new DateOnly(2021, 9, 21), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-053", "SN-DEMO-01053", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001054"), "DemoVolt", "EQ-01054", new DateOnly(2022, 10, 22), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-054", "SN-DEMO-01054", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001055"), "DemoPLC", "EQ-01055", new DateOnly(2023, 11, 23), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-055", "SN-DEMO-01055", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001056"), "DemoPower", "EQ-01056", new DateOnly(2016, 12, 24), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-056", "SN-DEMO-01056", "Maintenance", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001057"), "DemoUPS", "EQ-01057", new DateOnly(2017, 1, 1), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-057", "SN-DEMO-01057", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001058"), "DemoAir", "EQ-01058", new DateOnly(2018, 2, 2), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-058", "SN-DEMO-01058", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001059"), "DemoVolt", "EQ-01059", new DateOnly(2019, 3, 3), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-059", "SN-DEMO-01059", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001060"), "DemoPLC", "EQ-01060", new DateOnly(2020, 4, 4), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-060", "SN-DEMO-01060", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001061"), "DemoPower", "EQ-01061", new DateOnly(2021, 5, 5), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-061", "SN-DEMO-01061", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001062"), "DemoUPS", "EQ-01062", new DateOnly(2022, 6, 6), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-062", "SN-DEMO-01062", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001063"), "DemoAir", "EQ-01063", new DateOnly(2023, 7, 7), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-063", "SN-DEMO-01063", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001064"), "DemoVolt", "EQ-01064", new DateOnly(2016, 8, 8), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-064", "SN-DEMO-01064", "Faulted", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001065"), "DemoPLC", "EQ-01065", new DateOnly(2017, 9, 9), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-065", "SN-DEMO-01065", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001066"), "DemoPower", "EQ-01066", new DateOnly(2018, 10, 10), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-066", "SN-DEMO-01066", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001067"), "DemoUPS", "EQ-01067", new DateOnly(2019, 11, 11), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-067", "SN-DEMO-01067", "Maintenance", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001068"), "DemoAir", "EQ-01068", new DateOnly(2020, 12, 12), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-068", "SN-DEMO-01068", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001069"), "DemoVolt", "EQ-01069", new DateOnly(2021, 1, 13), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-069", "SN-DEMO-01069", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001070"), "DemoPLC", "EQ-01070", new DateOnly(2022, 2, 14), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-070", "SN-DEMO-01070", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001071"), "DemoPower", "EQ-01071", new DateOnly(2023, 3, 15), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-071", "SN-DEMO-01071", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001072"), "DemoUPS", "EQ-01072", new DateOnly(2016, 4, 16), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-072", "SN-DEMO-01072", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001073"), "DemoAir", "EQ-01073", new DateOnly(2017, 5, 17), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-073", "SN-DEMO-01073", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001074"), "DemoVolt", "EQ-01074", new DateOnly(2018, 6, 18), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-074", "SN-DEMO-01074", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001075"), "DemoPLC", "EQ-01075", new DateOnly(2019, 7, 19), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-075", "SN-DEMO-01075", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001076"), "DemoPower", "EQ-01076", new DateOnly(2020, 8, 20), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-076", "SN-DEMO-01076", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001077"), "DemoUPS", "EQ-01077", new DateOnly(2021, 9, 21), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-077", "SN-DEMO-01077", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001078"), "DemoAir", "EQ-01078", new DateOnly(2022, 10, 22), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-078", "SN-DEMO-01078", "Maintenance", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001079"), "DemoVolt", "EQ-01079", new DateOnly(2023, 11, 23), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-079", "SN-DEMO-01079", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001080"), "DemoPLC", "EQ-01080", new DateOnly(2016, 12, 24), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-080", "SN-DEMO-01080", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001081"), "DemoPower", "EQ-01081", new DateOnly(2017, 1, 1), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-081", "SN-DEMO-01081", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001082"), "DemoUPS", "EQ-01082", new DateOnly(2018, 2, 2), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-082", "SN-DEMO-01082", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001083"), "DemoAir", "EQ-01083", new DateOnly(2019, 3, 3), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-083", "SN-DEMO-01083", "Faulted", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001084"), "DemoVolt", "EQ-01084", new DateOnly(2020, 4, 4), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-084", "SN-DEMO-01084", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001085"), "DemoPLC", "EQ-01085", new DateOnly(2021, 5, 5), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-085", "SN-DEMO-01085", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001086"), "DemoPower", "EQ-01086", new DateOnly(2022, 6, 6), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-086", "SN-DEMO-01086", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001087"), "DemoUPS", "EQ-01087", new DateOnly(2023, 7, 7), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-087", "SN-DEMO-01087", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001088"), "DemoAir", "EQ-01088", new DateOnly(2016, 8, 8), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-088", "SN-DEMO-01088", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001089"), "DemoVolt", "EQ-01089", new DateOnly(2017, 9, 9), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-089", "SN-DEMO-01089", "Maintenance", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001090"), "DemoPLC", "EQ-01090", new DateOnly(2018, 10, 10), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-090", "SN-DEMO-01090", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001091"), "DemoPower", "EQ-01091", new DateOnly(2019, 11, 11), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-091", "SN-DEMO-01091", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001092"), "DemoUPS", "EQ-01092", new DateOnly(2020, 12, 12), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-092", "SN-DEMO-01092", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001093"), "DemoAir", "EQ-01093", new DateOnly(2021, 1, 13), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-093", "SN-DEMO-01093", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001094"), "DemoVolt", "EQ-01094", new DateOnly(2022, 2, 14), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-094", "SN-DEMO-01094", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001095"), "DemoPLC", "EQ-01095", new DateOnly(2023, 3, 15), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-095", "SN-DEMO-01095", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001096"), "DemoPower", "EQ-01096", new DateOnly(2016, 4, 16), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-096", "SN-DEMO-01096", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001097"), "DemoUPS", "EQ-01097", new DateOnly(2017, 5, 17), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-097", "SN-DEMO-01097", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001098"), "DemoAir", "EQ-01098", new DateOnly(2018, 6, 18), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-098", "SN-DEMO-01098", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001099"), "DemoVolt", "EQ-01099", new DateOnly(2019, 7, 19), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-099", "SN-DEMO-01099", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001100"), "DemoPLC", "EQ-01100", new DateOnly(2020, 8, 20), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-100", "SN-DEMO-01100", "Maintenance", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001101"), "DemoPower", "EQ-01101", new DateOnly(2021, 9, 21), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-101", "SN-DEMO-01101", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001102"), "DemoUPS", "EQ-01102", new DateOnly(2022, 10, 22), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-102", "SN-DEMO-01102", "Faulted", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001103"), "DemoAir", "EQ-01103", new DateOnly(2023, 11, 23), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-103", "SN-DEMO-01103", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001104"), "DemoVolt", "EQ-01104", new DateOnly(2016, 12, 24), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-104", "SN-DEMO-01104", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001105"), "DemoPLC", "EQ-01105", new DateOnly(2017, 1, 1), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-105", "SN-DEMO-01105", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001106"), "DemoPower", "EQ-01106", new DateOnly(2018, 2, 2), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-106", "SN-DEMO-01106", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001107"), "DemoUPS", "EQ-01107", new DateOnly(2019, 3, 3), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-107", "SN-DEMO-01107", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001108"), "DemoAir", "EQ-01108", new DateOnly(2020, 4, 4), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-108", "SN-DEMO-01108", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001109"), "DemoVolt", "EQ-01109", new DateOnly(2021, 5, 5), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-109", "SN-DEMO-01109", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001110"), "DemoPLC", "EQ-01110", new DateOnly(2022, 6, 6), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-110", "SN-DEMO-01110", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001111"), "DemoPower", "EQ-01111", new DateOnly(2023, 7, 7), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-111", "SN-DEMO-01111", "Maintenance", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001112"), "DemoUPS", "EQ-01112", new DateOnly(2016, 8, 8), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-112", "SN-DEMO-01112", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001113"), "DemoAir", "EQ-01113", new DateOnly(2017, 9, 9), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-113", "SN-DEMO-01113", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001114"), "DemoVolt", "EQ-01114", new DateOnly(2018, 10, 10), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-114", "SN-DEMO-01114", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001115"), "DemoPLC", "EQ-01115", new DateOnly(2019, 11, 11), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-115", "SN-DEMO-01115", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null },
                    { new Guid("50000000-0000-0000-0000-000000001116"), "DemoPower", "EQ-01116", new DateOnly(2020, 12, 12), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000002"), "G-750X", "GEN-TB-116", "SN-DEMO-01116", "Active", new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("50000000-0000-0000-0000-000000001117"), "DemoUPS", "EQ-01117", new DateOnly(2021, 1, 13), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000004"), "UPS-200", "UPS-TK-117", "SN-DEMO-01117", "Active", new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("50000000-0000-0000-0000-000000001118"), "DemoAir", "EQ-01118", new DateOnly(2022, 2, 14), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000001"), "AHU-400", "AHU-TA-118", "SN-DEMO-01118", "Active", new Guid("30000000-0000-0000-0000-000000000003"), null },
                    { new Guid("50000000-0000-0000-0000-000000001119"), "DemoVolt", "EQ-01119", new DateOnly(2023, 3, 15), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000003"), "ELC-90", "ELC-LM-119", "SN-DEMO-01119", "Active", new Guid("30000000-0000-0000-0000-000000000004"), null },
                    { new Guid("50000000-0000-0000-0000-000000001120"), "DemoPLC", "EQ-01120", new DateOnly(2016, 4, 16), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik demo ekipmanı.", true, new Guid("20000000-0000-0000-0000-000000000005"), "PLC-1500", "PLC-AP-120", "SN-DEMO-01120", "Active", new Guid("30000000-0000-0000-0000-000000000005"), null }
                });

            migrationBuilder.InsertData(
                table: "FaultActions",
                columns: new[] { "Id", "ActionType", "CreatedAt", "FaultId", "Metadata", "NewStatus", "Note", "OldStatus", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("61000000-0000-0000-0000-000000001064"), "StatusChanged", new DateTime(2026, 8, 12, 8, 34, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000010"), "{}", "InProgress", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001140"), "Created", new DateTime(2026, 8, 12, 8, 20, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000000010"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "AssignedAt", "AssignedToUserId", "ClosedAt", "ClosedByUserId", "CreatedAt", "CreatedByUserId", "Description", "EquipmentId", "FaultNo", "LocationId", "Priority", "ResolutionDescription", "ResolvedAt", "ResolvedByUserId", "Source", "Status", "TechnicalSystemId", "UpdatedAt", "WaitingReason" },
                values: new object[,]
                {
                    { new Guid("60000000-0000-0000-0000-000000001010"), new DateTime(2026, 5, 11, 17, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 11, 16, 50, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000000003"), "ARZ-2026-110", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "ScadaObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 11, 17, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001063"), new DateTime(2026, 7, 3, 14, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 4, 0, 29, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 3, 14, 1, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000000002"), "ARZ-2026-163", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 3, 22, 29, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Closed", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 4, 0, 29, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001081"), new DateTime(2026, 7, 21, 10, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 21, 10, 7, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000000004"), "ARZ-2026-181", new Guid("20000000-0000-0000-0000-000000000004"), "Medium", null, null, null, "HoneywellEbiObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 21, 10, 28, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001116"), new DateTime(2026, 1, 17, 13, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 17, 12, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000000001"), "ARZ-2026-216", new Guid("20000000-0000-0000-0000-000000000002"), "Low", null, null, null, "HoneywellEbiObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 17, 13, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001134"), null, null, null, null, new DateTime(2026, 2, 4, 8, 18, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000000003"), "ARZ-2026-234", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "MaintenanceFinding", "New", new Guid("30000000-0000-0000-0000-000000000003"), null, null }
                });

            migrationBuilder.InsertData(
                table: "MaintenancePlans",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "CreatedByUserId", "Description", "EquipmentId", "Frequency", "MaintenanceType", "PlanNo", "PlannedDate", "Priority", "ResponsibleUserId", "StartedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("70000000-0000-0000-0000-000000001017"), new DateTime(2026, 4, 8, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000000002"), "3 Aylık", "3 Aylık", "BKM-2026-117", new DateOnly(2026, 4, 8), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 8, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 8, 14, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001042"), new DateTime(2026, 5, 3, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000000003"), "3 Aylık", "3 Aylık", "BKM-2026-142", new DateOnly(2026, 5, 3), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 3, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 3, 15, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001067"), new DateTime(2026, 5, 28, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000000004"), "3 Aylık", "3 Aylık", "BKM-2026-167", new DateOnly(2026, 5, 28), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 28, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 28, 16, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001116"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000000001"), "Aylık", "Aylık", "BKM-2026-216", new DateOnly(2026, 7, 16), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 16, 8, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 7, 16, 8, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsRead", "Message", "RelatedEntityId", "RelatedEntityName", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("81000000-0000-0000-0000-000000001001"), new DateTime(2026, 7, 5, 14, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001002"), new DateTime(2026, 7, 5, 15, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001003"), new DateTime(2026, 7, 5, 16, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001004"), new DateTime(2026, 7, 5, 17, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001005"), new DateTime(2026, 7, 5, 18, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001006"), new DateTime(2026, 7, 5, 19, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001007"), new DateTime(2026, 7, 5, 20, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001008"), new DateTime(2026, 7, 5, 21, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001009"), new DateTime(2026, 7, 5, 22, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001010"), new DateTime(2026, 7, 5, 23, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001011"), new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001012"), new DateTime(2026, 7, 6, 1, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001013"), new DateTime(2026, 7, 6, 2, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001014"), new DateTime(2026, 7, 6, 3, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001015"), new DateTime(2026, 7, 6, 4, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001016"), new DateTime(2026, 7, 6, 5, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001017"), new DateTime(2026, 7, 6, 6, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001018"), new DateTime(2026, 7, 6, 7, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001019"), new DateTime(2026, 7, 6, 8, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001020"), new DateTime(2026, 7, 6, 9, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001021"), new DateTime(2026, 7, 6, 10, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001022"), new DateTime(2026, 7, 6, 11, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001023"), new DateTime(2026, 7, 6, 12, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001024"), new DateTime(2026, 7, 6, 13, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001025"), new DateTime(2026, 7, 6, 14, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001026"), new DateTime(2026, 7, 6, 15, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001027"), new DateTime(2026, 7, 6, 16, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001028"), new DateTime(2026, 7, 6, 17, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001029"), new DateTime(2026, 7, 6, 18, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001030"), new DateTime(2026, 7, 6, 19, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001031"), new DateTime(2026, 7, 6, 20, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001032"), new DateTime(2026, 7, 6, 21, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001033"), new DateTime(2026, 7, 6, 22, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001034"), new DateTime(2026, 7, 6, 23, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001035"), new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001036"), new DateTime(2026, 7, 7, 1, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001037"), new DateTime(2026, 7, 7, 2, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001038"), new DateTime(2026, 7, 7, 3, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001039"), new DateTime(2026, 7, 7, 4, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001040"), new DateTime(2026, 7, 7, 5, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001041"), new DateTime(2026, 7, 7, 6, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001042"), new DateTime(2026, 7, 7, 7, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001043"), new DateTime(2026, 7, 7, 8, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001044"), new DateTime(2026, 7, 7, 9, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001045"), new DateTime(2026, 7, 7, 10, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001046"), new DateTime(2026, 7, 7, 11, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001047"), new DateTime(2026, 7, 7, 12, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001048"), new DateTime(2026, 7, 7, 13, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001049"), new DateTime(2026, 7, 7, 14, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001050"), new DateTime(2026, 7, 7, 15, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001051"), new DateTime(2026, 7, 7, 16, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001052"), new DateTime(2026, 7, 7, 17, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001053"), new DateTime(2026, 7, 7, 18, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001054"), new DateTime(2026, 7, 7, 19, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001055"), new DateTime(2026, 7, 7, 20, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001056"), new DateTime(2026, 7, 7, 21, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001057"), new DateTime(2026, 7, 7, 22, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001058"), new DateTime(2026, 7, 7, 23, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001059"), new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001060"), new DateTime(2026, 7, 8, 1, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001061"), new DateTime(2026, 7, 8, 2, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001062"), new DateTime(2026, 7, 8, 3, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001063"), new DateTime(2026, 7, 8, 4, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001064"), new DateTime(2026, 7, 8, 5, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001065"), new DateTime(2026, 7, 8, 6, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001066"), new DateTime(2026, 7, 8, 7, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001067"), new DateTime(2026, 7, 8, 8, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001068"), new DateTime(2026, 7, 8, 9, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001069"), new DateTime(2026, 7, 8, 10, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001070"), new DateTime(2026, 7, 8, 11, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001071"), new DateTime(2026, 7, 8, 12, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001072"), new DateTime(2026, 7, 8, 13, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001073"), new DateTime(2026, 7, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001074"), new DateTime(2026, 7, 8, 15, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001075"), new DateTime(2026, 7, 8, 16, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001076"), new DateTime(2026, 7, 8, 17, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001077"), new DateTime(2026, 7, 8, 18, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001078"), new DateTime(2026, 7, 8, 19, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001079"), new DateTime(2026, 7, 8, 20, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001080"), new DateTime(2026, 7, 1, 9, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001081"), new DateTime(2026, 7, 1, 10, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001082"), new DateTime(2026, 7, 1, 11, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001083"), new DateTime(2026, 7, 1, 12, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001084"), new DateTime(2026, 7, 1, 13, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001085"), new DateTime(2026, 7, 1, 14, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001086"), new DateTime(2026, 7, 1, 15, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001087"), new DateTime(2026, 7, 1, 16, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001088"), new DateTime(2026, 7, 1, 17, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001089"), new DateTime(2026, 7, 1, 18, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001090"), new DateTime(2026, 7, 1, 19, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001091"), new DateTime(2026, 7, 1, 20, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001092"), new DateTime(2026, 7, 1, 21, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001093"), new DateTime(2026, 7, 1, 22, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001094"), new DateTime(2026, 7, 1, 23, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001095"), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001096"), new DateTime(2026, 7, 2, 1, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("81000000-0000-0000-0000-000000001097"), new DateTime(2026, 7, 2, 2, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000002") },
                    { new Guid("81000000-0000-0000-0000-000000001098"), new DateTime(2026, 7, 2, 3, 0, 0, 0, DateTimeKind.Utc), true, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Bilgilendirme", "Info", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("81000000-0000-0000-0000-000000001099"), new DateTime(2026, 7, 2, 4, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "MaintenancePlan", "Takip gerektiren kayıt", "Warning", null, new Guid("40000000-0000-0000-0000-000000000004") },
                    { new Guid("81000000-0000-0000-0000-000000001100"), new DateTime(2026, 7, 2, 5, 0, 0, 0, DateTimeKind.Utc), false, "Sentetik demo bildirimi: raporlama ve test senaryoları için oluşturuldu.", null, "Fault", "Kritik operasyon uyarısı", "Critical", null, new Guid("40000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "ShiftHandovers",
                columns: new[] { "Id", "CreatedAt", "CriticalNotes", "HandoverFromUserId", "HandoverNo", "HandoverToUserId", "ShiftDate", "ShiftType", "Summary", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("74000000-0000-0000-0000-000000001001"), new DateTime(2027, 3, 30, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-101", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 3, 30), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001002"), new DateTime(2027, 3, 31, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-102", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 3, 31), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001003"), new DateTime(2027, 3, 31, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-103", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 3, 31), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001004"), new DateTime(2027, 3, 31, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-104", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 3, 31), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001005"), new DateTime(2027, 4, 1, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-105", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 1), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001006"), new DateTime(2027, 4, 1, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-106", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 1), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001007"), new DateTime(2027, 4, 1, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-107", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 1), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001008"), new DateTime(2027, 4, 2, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-108", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 2), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001009"), new DateTime(2027, 4, 2, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-109", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 2), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001010"), new DateTime(2027, 4, 2, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-110", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 2), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001011"), new DateTime(2027, 4, 3, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-111", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 3), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001012"), new DateTime(2027, 4, 3, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-112", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 3), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001013"), new DateTime(2027, 4, 3, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-113", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 3), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001014"), new DateTime(2027, 4, 4, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-114", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 4), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001015"), new DateTime(2027, 4, 4, 16, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-115", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 4), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001016"), new DateTime(2027, 4, 4, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-116", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 4), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001017"), new DateTime(2027, 4, 5, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-117", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 5), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001018"), new DateTime(2027, 4, 5, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-118", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 5), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001019"), new DateTime(2027, 4, 5, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-119", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 5), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001020"), new DateTime(2027, 4, 6, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-120", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 6), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001021"), new DateTime(2027, 4, 6, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-121", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 6), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001022"), new DateTime(2027, 4, 6, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-122", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 6), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001023"), new DateTime(2027, 4, 7, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-123", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 7), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001024"), new DateTime(2027, 4, 7, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-124", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 7), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001025"), new DateTime(2027, 4, 7, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-125", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 7), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001026"), new DateTime(2027, 4, 8, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-126", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 8), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001027"), new DateTime(2027, 4, 8, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-127", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 8), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001028"), new DateTime(2027, 4, 8, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-128", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 8), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001029"), new DateTime(2027, 4, 9, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-129", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 9), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001030"), new DateTime(2027, 4, 9, 16, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-130", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 9), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001031"), new DateTime(2027, 4, 9, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-131", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 9), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001032"), new DateTime(2027, 4, 10, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-132", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 10), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001033"), new DateTime(2027, 4, 10, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-133", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 10), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001034"), new DateTime(2027, 4, 10, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-134", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 10), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001035"), new DateTime(2027, 4, 11, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-135", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 11), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001036"), new DateTime(2027, 4, 11, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-136", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 11), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001037"), new DateTime(2027, 4, 11, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-137", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 11), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001038"), new DateTime(2027, 4, 12, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-138", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 12), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001039"), new DateTime(2027, 4, 12, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-139", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 12), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001040"), new DateTime(2027, 4, 12, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-140", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 12), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001041"), new DateTime(2027, 4, 13, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-141", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 13), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001042"), new DateTime(2027, 4, 13, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-142", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 13), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001043"), new DateTime(2027, 4, 13, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-143", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 13), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001044"), new DateTime(2027, 4, 14, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-144", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 14), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001045"), new DateTime(2027, 4, 14, 16, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-145", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 14), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001046"), new DateTime(2027, 4, 14, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-146", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 14), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001047"), new DateTime(2027, 4, 15, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-147", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 15), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001048"), new DateTime(2027, 4, 15, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-148", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 15), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001049"), new DateTime(2027, 4, 15, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-149", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 15), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001050"), new DateTime(2027, 4, 16, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-150", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 16), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001051"), new DateTime(2027, 4, 16, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-151", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 16), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001052"), new DateTime(2027, 4, 16, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-152", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 16), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001053"), new DateTime(2027, 4, 17, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-153", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 17), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001054"), new DateTime(2027, 4, 17, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-154", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 17), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001055"), new DateTime(2027, 4, 17, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-155", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 17), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001056"), new DateTime(2027, 4, 18, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-156", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 18), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001057"), new DateTime(2027, 4, 18, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-157", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 18), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001058"), new DateTime(2027, 4, 18, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-158", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 18), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001059"), new DateTime(2027, 4, 19, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-159", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 19), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001060"), new DateTime(2027, 4, 19, 16, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-160", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 19), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001061"), new DateTime(2027, 4, 19, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-161", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 19), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001062"), new DateTime(2027, 4, 20, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-162", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 20), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001063"), new DateTime(2027, 4, 20, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-163", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 20), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001064"), new DateTime(2027, 4, 20, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-164", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 20), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001065"), new DateTime(2027, 4, 21, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-165", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 21), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001066"), new DateTime(2027, 4, 21, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-166", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 21), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001067"), new DateTime(2027, 4, 21, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-167", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 21), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001068"), new DateTime(2027, 4, 22, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-168", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 22), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001069"), new DateTime(2027, 4, 22, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-169", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 22), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001070"), new DateTime(2027, 4, 22, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-170", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 22), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001071"), new DateTime(2027, 4, 23, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-171", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 23), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001072"), new DateTime(2027, 4, 23, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-172", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 23), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001073"), new DateTime(2027, 4, 23, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-173", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 23), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001074"), new DateTime(2027, 4, 24, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-174", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 24), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001075"), new DateTime(2027, 4, 24, 16, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-175", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 24), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001076"), new DateTime(2027, 4, 24, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-176", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 24), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001077"), new DateTime(2027, 4, 25, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-177", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 25), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001078"), new DateTime(2027, 4, 25, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-178", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 25), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001079"), new DateTime(2027, 4, 25, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-179", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 25), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001080"), new DateTime(2027, 4, 26, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-180", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 26), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001081"), new DateTime(2027, 4, 26, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-181", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 26), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001082"), new DateTime(2027, 4, 26, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-182", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 26), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001083"), new DateTime(2027, 4, 27, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-183", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 27), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001084"), new DateTime(2027, 4, 27, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-184", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 27), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001085"), new DateTime(2027, 4, 27, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-185", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 27), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001086"), new DateTime(2027, 4, 28, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-186", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 28), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001087"), new DateTime(2027, 4, 28, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-187", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 28), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001088"), new DateTime(2027, 4, 28, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-188", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 28), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001089"), new DateTime(2027, 4, 29, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-189", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 29), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001090"), new DateTime(2027, 4, 29, 16, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-190", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 29), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001091"), new DateTime(2027, 4, 29, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-191", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 29), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001092"), new DateTime(2027, 4, 30, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-192", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 30), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001093"), new DateTime(2027, 4, 30, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-193", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 4, 30), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001094"), new DateTime(2027, 4, 30, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-194", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 4, 30), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001095"), new DateTime(2027, 5, 1, 8, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-195", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 5, 1), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001096"), new DateTime(2027, 5, 1, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-196", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 5, 1), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001097"), new DateTime(2027, 5, 1, 23, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-197", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 5, 1), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001098"), new DateTime(2027, 5, 2, 8, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-198", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 5, 2), "Morning", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001099"), new DateTime(2027, 5, 2, 16, 45, 0, 0, DateTimeKind.Utc), "Standart vardiya takip notları aktarıldı.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-199", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2027, 5, 2), "Evening", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000001100"), new DateTime(2027, 5, 2, 23, 45, 0, 0, DateTimeKind.Utc), "Kritik ekipman alarm trendi vardiya boyunca takip edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-200", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2027, 5, 2), "Night", "Sentetik vardiya devri: açık işler, takip edilecek ekipmanlar ve kritik notlar aktarıldı.", null }
                });

            migrationBuilder.InsertData(
                table: "ShiftItems",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "FaultId", "IsCompleted", "ItemType", "MaintenancePlanId", "Priority", "ShiftHandoverId", "Title", "UpdatedAt" },
                values: new object[] { new Guid("74100000-0000-0000-0000-000000001134"), new DateTime(2026, 8, 12, 8, 34, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000000001"), "Kritik saha notu ve çalışma izni kontrolü", null });

            migrationBuilder.InsertData(
                table: "TestPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "Frequency", "PlannedDate", "ResponsibleUserId", "Status", "TestType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("72000000-0000-0000-0000-000000001034"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000000003"), "3 Aylık", new DateOnly(2026, 6, 4), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001075"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000000002"), "Tek Seferlik", new DateOnly(2026, 7, 15), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001116"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000000001"), "Aylık", new DateOnly(2026, 1, 17), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001117"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000000004"), "Haftalık", new DateOnly(2026, 1, 18), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 1, 18, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "TestRecords",
                columns: new[] { "Id", "AbnormalCondition", "CreatedAt", "Description", "DurationMinutes", "EquipmentId", "Result", "TestDate", "TestPlanId", "TestType", "TestedByUserId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("73000000-0000-0000-0000-000000001008"), null, new DateTime(2026, 8, 3, 8, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 48, new Guid("50000000-0000-0000-0000-000000000001"), "Success", new DateTime(2026, 8, 3, 8, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 3, 8, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001009"), null, new DateTime(2026, 8, 6, 9, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 49, new Guid("50000000-0000-0000-0000-000000000003"), "ConditionalSuccess", new DateTime(2026, 8, 6, 9, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 6, 9, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001010"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 8, 9, 10, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 50, new Guid("50000000-0000-0000-0000-000000000001"), "Failed", new DateTime(2026, 8, 9, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000005"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 9, 10, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001071"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 8, 3, 15, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 41, new Guid("50000000-0000-0000-0000-000000000001"), "RetestRequired", new DateTime(2026, 8, 3, 15, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 3, 15, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001072"), null, new DateTime(2026, 8, 6, 8, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 42, new Guid("50000000-0000-0000-0000-000000000003"), "Success", new DateTime(2026, 8, 6, 8, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 6, 8, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001073"), null, new DateTime(2026, 8, 9, 9, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 43, new Guid("50000000-0000-0000-0000-000000000001"), "ConditionalSuccess", new DateTime(2026, 8, 9, 9, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000005"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 9, 9, 30, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Department", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "RoleId", "Title", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000005"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik2@demo.local", "Teknik Personel 2", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik2" },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik3@demo.local", "Teknik Personel 3", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik3" },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik4@demo.local", "Teknik Personel 4", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik4" },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik5@demo.local", "Teknik Personel 5", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik5" },
                    { new Guid("40000000-0000-0000-0000-000000000009"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik6@demo.local", "Teknik Personel 6", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik6" },
                    { new Guid("40000000-0000-0000-0000-000000000010"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik7@demo.local", "Teknik Personel 7", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik7" },
                    { new Guid("40000000-0000-0000-0000-000000000011"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik8@demo.local", "Teknik Personel 8", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik8" },
                    { new Guid("40000000-0000-0000-0000-000000000012"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "teknik9@demo.local", "Teknik Personel 9", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000003"), "Teknik Personel", null, "teknik9" },
                    { new Guid("40000000-0000-0000-0000-000000000013"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Operasyon", "operator2@demo.local", "Operatör 2", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000004"), "Operatör", null, "operator2" },
                    { new Guid("40000000-0000-0000-0000-000000000014"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Operasyon", "operator3@demo.local", "Operatör 3", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000004"), "Operatör", null, "operator3" },
                    { new Guid("40000000-0000-0000-0000-000000000015"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Operasyon", "operator4@demo.local", "Operatör 4", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000004"), "Operatör", null, "operator4" },
                    { new Guid("40000000-0000-0000-0000-000000000016"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Operasyon", "operator5@demo.local", "Operatör 5", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000004"), "Operatör", null, "operator5" },
                    { new Guid("40000000-0000-0000-0000-000000000017"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik Otomasyon", "raporcu@demo.local", "Rapor Kullanıcısı", true, null, "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=", new Guid("10000000-0000-0000-0000-000000000006"), "Rapor Uzmanı", null, "raporcu" }
                });

            migrationBuilder.InsertData(
                table: "FaultActions",
                columns: new[] { "Id", "ActionType", "CreatedAt", "FaultId", "Metadata", "NewStatus", "Note", "OldStatus", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("61000000-0000-0000-0000-000000001020"), "Created", new DateTime(2026, 7, 3, 14, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001063"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001029"), "NoteAdded", new DateTime(2026, 7, 21, 10, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001081"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001096"), "Resolved", new DateTime(2026, 7, 3, 14, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001063"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001105"), "Assigned", new DateTime(2026, 7, 21, 10, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001081"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "AssignedAt", "AssignedToUserId", "ClosedAt", "ClosedByUserId", "CreatedAt", "CreatedByUserId", "Description", "EquipmentId", "FaultNo", "LocationId", "Priority", "ResolutionDescription", "ResolvedAt", "ResolvedByUserId", "Source", "Status", "TechnicalSystemId", "UpdatedAt", "WaitingReason" },
                values: new object[,]
                {
                    { new Guid("60000000-0000-0000-0000-000000001001"), null, null, null, null, new DateTime(2026, 5, 2, 7, 47, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001060"), "ARZ-2026-101", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", null, null, null, "HoneywellEbiObservation", "New", new Guid("30000000-0000-0000-0000-000000000005"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001002"), new DateTime(2026, 5, 3, 9, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 3, 8, 54, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001067"), "ARZ-2026-102", new Guid("20000000-0000-0000-0000-000000000004"), "High", null, null, null, "FieldObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 3, 9, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001003"), new DateTime(2026, 5, 4, 9, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 4, 9, 1, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001074"), "ARZ-2026-103", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "OperatorReport", "InReview", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 5, 4, 9, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001004"), new DateTime(2026, 5, 5, 10, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 5, 10, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001081"), "ARZ-2026-104", new Guid("20000000-0000-0000-0000-000000000002"), "Low", null, null, null, "MaintenanceFinding", "InProgress", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 5, 10, 32, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001005"), new DateTime(2026, 5, 6, 11, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 6, 11, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001088"), "ARZ-2026-105", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "ScadaObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 6, 11, 40, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001006"), new DateTime(2026, 5, 7, 12, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 7, 12, 22, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001095"), "ARZ-2026-106", new Guid("20000000-0000-0000-0000-000000000005"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 7, 19, 38, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 5, 7, 19, 38, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001007"), new DateTime(2026, 5, 8, 13, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 9, 0, 46, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 8, 13, 29, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001102"), "ARZ-2026-107", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 8, 21, 46, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 9, 0, 46, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001008"), null, null, null, null, new DateTime(2026, 5, 9, 14, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001109"), "ARZ-2026-108", new Guid("20000000-0000-0000-0000-000000000003"), "Low", null, null, null, "OperatorReport", "New", new Guid("30000000-0000-0000-0000-000000000004"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001009"), new DateTime(2026, 5, 10, 16, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 10, 15, 43, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001116"), "ARZ-2026-109", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", null, null, null, "MaintenanceFinding", "Assigned", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 10, 16, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001011"), new DateTime(2026, 5, 12, 18, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 12, 17, 57, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001006"), "ARZ-2026-111", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", null, null, null, "HoneywellEbiObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 12, 18, 28, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001012"), new DateTime(2026, 5, 13, 7, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 13, 7, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001013"), "ARZ-2026-112", new Guid("20000000-0000-0000-0000-000000000001"), "Low", null, null, null, "FieldObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 13, 7, 36, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001013"), new DateTime(2026, 5, 14, 8, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 14, 8, 11, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001020"), "ARZ-2026-113", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 14, 14, 34, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Resolved", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 5, 14, 14, 34, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001014"), new DateTime(2026, 5, 15, 9, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 15, 17, 42, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 15, 9, 18, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001027"), "ARZ-2026-114", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 15, 16, 42, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Closed", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 15, 17, 42, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001015"), null, null, null, null, new DateTime(2026, 5, 16, 10, 25, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001034"), "ARZ-2026-115", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "ScadaObservation", "New", new Guid("30000000-0000-0000-0000-000000000004"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001016"), new DateTime(2026, 5, 17, 12, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 17, 11, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001041"), "ARZ-2026-116", new Guid("20000000-0000-0000-0000-000000000002"), "Low", null, null, null, "HoneywellEbiObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 17, 12, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001017"), new DateTime(2026, 5, 18, 13, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 18, 12, 39, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001048"), "ARZ-2026-117", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "FieldObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 18, 13, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001018"), new DateTime(2026, 5, 19, 14, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 19, 13, 46, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001055"), "ARZ-2026-118", new Guid("20000000-0000-0000-0000-000000000005"), "High", null, null, null, "OperatorReport", "InProgress", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 5, 19, 14, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001019"), new DateTime(2026, 5, 20, 15, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 20, 14, 53, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001062"), "ARZ-2026-119", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "MaintenanceFinding", "Waiting", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 20, 15, 32, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001020"), new DateTime(2026, 5, 21, 15, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 21, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001069"), "ARZ-2026-120", new Guid("20000000-0000-0000-0000-000000000003"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 21, 20, 30, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 5, 21, 20, 30, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001021"), new DateTime(2026, 5, 22, 16, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 23, 0, 38, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 22, 16, 7, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001076"), "ARZ-2026-121", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 22, 22, 38, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 23, 0, 38, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001022"), null, null, null, null, new DateTime(2026, 5, 23, 17, 14, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001083"), "ARZ-2026-122", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "FieldObservation", "New", new Guid("30000000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001023"), new DateTime(2026, 5, 24, 8, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 24, 7, 21, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001090"), "ARZ-2026-123", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", null, null, null, "OperatorReport", "Assigned", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 5, 24, 8, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001024"), new DateTime(2026, 5, 25, 9, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 25, 8, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001097"), "ARZ-2026-124", new Guid("20000000-0000-0000-0000-000000000004"), "Low", null, null, null, "MaintenanceFinding", "InReview", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 25, 9, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001025"), new DateTime(2026, 5, 26, 10, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 26, 9, 35, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001104"), "ARZ-2026-125", new Guid("20000000-0000-0000-0000-000000000003"), "Medium", null, null, null, "ScadaObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 5, 26, 10, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001026"), new DateTime(2026, 5, 27, 11, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 27, 10, 42, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001111"), "ARZ-2026-126", new Guid("20000000-0000-0000-0000-000000000002"), "High", null, null, null, "HoneywellEbiObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 27, 11, 28, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001027"), new DateTime(2026, 5, 28, 12, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 28, 11, 49, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001118"), "ARZ-2026-127", new Guid("20000000-0000-0000-0000-000000000001"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 28, 16, 26, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 28, 16, 26, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001028"), new DateTime(2026, 5, 29, 13, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 29, 21, 34, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 5, 29, 12, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001001"), "ARZ-2026-128", new Guid("20000000-0000-0000-0000-000000000002"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 5, 29, 18, 34, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Closed", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 5, 29, 21, 34, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001029"), null, null, null, null, new DateTime(2026, 5, 30, 13, 3, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001008"), "ARZ-2026-129", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "MaintenanceFinding", "New", new Guid("30000000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001030"), new DateTime(2026, 5, 31, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 5, 31, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001015"), "ARZ-2026-130", new Guid("20000000-0000-0000-0000-000000000005"), "High", null, null, null, "ScadaObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 5, 31, 15, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001031"), new DateTime(2026, 6, 1, 16, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 1, 15, 17, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001022"), "ARZ-2026-131", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "HoneywellEbiObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 1, 16, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001032"), new DateTime(2026, 6, 2, 17, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 2, 16, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001029"), "ARZ-2026-132", new Guid("20000000-0000-0000-0000-000000000003"), "Low", null, null, null, "FieldObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 6, 2, 17, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001033"), new DateTime(2026, 6, 3, 18, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 3, 17, 31, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001036"), "ARZ-2026-133", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", null, null, null, "OperatorReport", "Waiting", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 6, 3, 18, 24, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001034"), new DateTime(2026, 6, 4, 8, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 4, 7, 38, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001043"), "ARZ-2026-134", new Guid("20000000-0000-0000-0000-000000000001"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 4, 11, 22, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Resolved", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 4, 11, 22, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001035"), new DateTime(2026, 6, 5, 9, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 5, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 5, 8, 45, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001050"), "ARZ-2026-135", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 5, 12, 45, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 6, 5, 13, 45, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001036"), null, null, null, null, new DateTime(2026, 6, 6, 9, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001057"), "ARZ-2026-136", new Guid("20000000-0000-0000-0000-000000000004"), "Low", null, null, null, "HoneywellEbiObservation", "New", new Guid("30000000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001037"), new DateTime(2026, 6, 7, 11, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 7, 10, 59, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001064"), "ARZ-2026-137", new Guid("20000000-0000-0000-0000-000000000003"), "Medium", null, null, null, "FieldObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 6, 7, 11, 56, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001038"), new DateTime(2026, 6, 8, 12, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 8, 11, 6, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001071"), "ARZ-2026-138", new Guid("20000000-0000-0000-0000-000000000002"), "High", null, null, null, "OperatorReport", "InReview", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 6, 8, 12, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001039"), new DateTime(2026, 6, 9, 13, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 9, 12, 13, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001078"), "ARZ-2026-139", new Guid("20000000-0000-0000-0000-000000000001"), "Critical", null, null, null, "MaintenanceFinding", "InProgress", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 9, 13, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001040"), new DateTime(2026, 6, 10, 13, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 10, 13, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001085"), "ARZ-2026-140", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", null, null, null, "ScadaObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 6, 10, 13, 40, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001041"), new DateTime(2026, 6, 11, 14, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 11, 14, 27, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001092"), "ARZ-2026-141", new Guid("20000000-0000-0000-0000-000000000004"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 11, 16, 33, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 11, 16, 33, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001042"), new DateTime(2026, 6, 12, 15, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 12, 20, 41, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 12, 15, 34, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001099"), "ARZ-2026-142", new Guid("20000000-0000-0000-0000-000000000003"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 12, 18, 41, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 6, 12, 20, 41, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001043"), null, null, null, null, new DateTime(2026, 6, 13, 16, 41, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001106"), "ARZ-2026-143", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", null, null, null, "OperatorReport", "New", new Guid("30000000-0000-0000-0000-000000000001"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001044"), new DateTime(2026, 6, 14, 18, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 14, 17, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001113"), "ARZ-2026-144", new Guid("20000000-0000-0000-0000-000000000001"), "Low", null, null, null, "MaintenanceFinding", "Assigned", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 14, 18, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001045"), new DateTime(2026, 6, 15, 8, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 15, 7, 55, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001120"), "ARZ-2026-145", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", null, null, null, "ScadaObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 6, 15, 8, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001046"), new DateTime(2026, 6, 16, 8, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 16, 8, 2, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001003"), "ARZ-2026-146", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "HoneywellEbiObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 16, 8, 28, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001047"), new DateTime(2026, 6, 17, 9, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 17, 9, 9, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001010"), "ARZ-2026-147", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", null, null, null, "FieldObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 6, 17, 9, 36, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001048"), new DateTime(2026, 6, 18, 10, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 18, 10, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001017"), "ARZ-2026-148", new Guid("20000000-0000-0000-0000-000000000004"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 18, 11, 29, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Resolved", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 18, 11, 29, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001049"), new DateTime(2026, 6, 19, 11, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 19, 16, 37, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 19, 11, 23, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001024"), "ARZ-2026-149", new Guid("20000000-0000-0000-0000-000000000003"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 19, 13, 37, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Closed", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 6, 19, 16, 37, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001050"), null, null, null, null, new DateTime(2026, 6, 20, 12, 30, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001031"), "ARZ-2026-150", new Guid("20000000-0000-0000-0000-000000000002"), "High", null, null, null, "ScadaObservation", "New", new Guid("30000000-0000-0000-0000-000000000001"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001051"), new DateTime(2026, 6, 21, 14, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 21, 13, 37, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001038"), "ARZ-2026-151", new Guid("20000000-0000-0000-0000-000000000001"), "Critical", null, null, null, "HoneywellEbiObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 21, 14, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001052"), new DateTime(2026, 6, 22, 15, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 22, 14, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001045"), "ARZ-2026-152", new Guid("20000000-0000-0000-0000-000000000005"), "Low", null, null, null, "FieldObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 6, 22, 15, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001053"), new DateTime(2026, 6, 23, 16, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 23, 15, 51, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001052"), "ARZ-2026-153", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "OperatorReport", "InProgress", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 23, 16, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001054"), new DateTime(2026, 6, 24, 17, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 24, 16, 58, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001059"), "ARZ-2026-154", new Guid("20000000-0000-0000-0000-000000000003"), "High", null, null, null, "MaintenanceFinding", "Waiting", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 6, 24, 17, 32, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001055"), new DateTime(2026, 6, 25, 17, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 25, 17, 5, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001066"), "ARZ-2026-155", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 26, 1, 25, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 6, 26, 1, 25, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001056"), new DateTime(2026, 6, 26, 7, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 26, 9, 33, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 26, 7, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001073"), "ARZ-2026-156", new Guid("20000000-0000-0000-0000-000000000001"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 6, 26, 8, 33, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 26, 9, 33, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001057"), null, null, null, null, new DateTime(2026, 6, 27, 8, 19, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001080"), "ARZ-2026-157", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", null, null, null, "FieldObservation", "New", new Guid("30000000-0000-0000-0000-000000000005"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001058"), new DateTime(2026, 6, 28, 10, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 28, 9, 26, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001087"), "ARZ-2026-158", new Guid("20000000-0000-0000-0000-000000000004"), "High", null, null, null, "OperatorReport", "Assigned", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 6, 28, 10, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001059"), new DateTime(2026, 6, 29, 11, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 29, 10, 33, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001094"), "ARZ-2026-159", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "MaintenanceFinding", "InReview", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 6, 29, 11, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001060"), new DateTime(2026, 6, 30, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 6, 30, 11, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001101"), "ARZ-2026-160", new Guid("20000000-0000-0000-0000-000000000002"), "Low", null, null, null, "ScadaObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 6, 30, 12, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001061"), new DateTime(2026, 7, 1, 13, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 1, 12, 47, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001108"), "ARZ-2026-161", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "HoneywellEbiObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 1, 13, 28, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001062"), new DateTime(2026, 7, 2, 14, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 2, 13, 54, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001115"), "ARZ-2026-162", new Guid("20000000-0000-0000-0000-000000000005"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 2, 21, 21, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 2, 21, 21, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001064"), null, null, null, null, new DateTime(2026, 7, 4, 15, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001005"), "ARZ-2026-164", new Guid("20000000-0000-0000-0000-000000000005"), "Low", null, null, null, "MaintenanceFinding", "New", new Guid("30000000-0000-0000-0000-000000000005"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001065"), new DateTime(2026, 7, 5, 17, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 5, 16, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001012"), "ARZ-2026-165", new Guid("20000000-0000-0000-0000-000000000004"), "Medium", null, null, null, "ScadaObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 5, 17, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001066"), new DateTime(2026, 7, 6, 18, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 6, 17, 22, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001019"), "ARZ-2026-166", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "HoneywellEbiObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 7, 6, 18, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001067"), new DateTime(2026, 7, 7, 8, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 7, 7, 29, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001026"), "ARZ-2026-167", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", null, null, null, "FieldObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 7, 7, 8, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001068"), new DateTime(2026, 7, 8, 9, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 8, 8, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001033"), "ARZ-2026-168", new Guid("20000000-0000-0000-0000-000000000001"), "Low", null, null, null, "OperatorReport", "Waiting", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 8, 9, 24, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001069"), new DateTime(2026, 7, 9, 10, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 9, 9, 43, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001040"), "ARZ-2026-169", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 9, 16, 17, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Resolved", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 9, 16, 17, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001070"), new DateTime(2026, 7, 10, 11, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 10, 21, 25, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 10, 10, 50, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001047"), "ARZ-2026-170", new Guid("20000000-0000-0000-0000-000000000004"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 10, 18, 25, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 10, 21, 25, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001071"), null, null, null, null, new DateTime(2026, 7, 11, 11, 57, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001054"), "ARZ-2026-171", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "HoneywellEbiObservation", "New", new Guid("30000000-0000-0000-0000-000000000004"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001072"), new DateTime(2026, 7, 12, 12, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 12, 12, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001061"), "ARZ-2026-172", new Guid("20000000-0000-0000-0000-000000000002"), "Low", null, null, null, "FieldObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 7, 12, 12, 56, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001073"), new DateTime(2026, 7, 13, 14, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 13, 13, 11, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001068"), "ARZ-2026-173", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "OperatorReport", "InReview", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 13, 14, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001074"), new DateTime(2026, 7, 14, 15, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 14, 14, 18, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001075"), "ARZ-2026-174", new Guid("20000000-0000-0000-0000-000000000005"), "High", null, null, null, "MaintenanceFinding", "InProgress", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 14, 15, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001075"), new DateTime(2026, 7, 15, 16, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 15, 15, 25, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001082"), "ARZ-2026-175", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "ScadaObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 15, 16, 20, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001076"), new DateTime(2026, 7, 16, 17, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 16, 16, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001089"), "ARZ-2026-176", new Guid("20000000-0000-0000-0000-000000000003"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 16, 22, 13, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 7, 16, 22, 13, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001077"), new DateTime(2026, 7, 17, 18, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 18, 1, 21, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 17, 17, 39, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001096"), "ARZ-2026-177", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 18, 0, 21, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 7, 18, 1, 21, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001078"), null, null, null, null, new DateTime(2026, 7, 18, 7, 46, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001103"), "ARZ-2026-178", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "OperatorReport", "New", new Guid("30000000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001079"), new DateTime(2026, 7, 19, 9, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 19, 8, 53, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001110"), "ARZ-2026-179", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", null, null, null, "MaintenanceFinding", "Assigned", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 19, 9, 52, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001080"), new DateTime(2026, 7, 20, 9, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 20, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001117"), "ARZ-2026-180", new Guid("20000000-0000-0000-0000-000000000004"), "Low", null, null, null, "ScadaObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 20, 9, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001082"), new DateTime(2026, 7, 22, 11, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 22, 11, 14, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001007"), "ARZ-2026-182", new Guid("20000000-0000-0000-0000-000000000004"), "High", null, null, null, "FieldObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 22, 11, 36, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001083"), new DateTime(2026, 7, 23, 12, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 23, 12, 21, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001014"), "ARZ-2026-183", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 23, 16, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Resolved", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 7, 23, 16, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001084"), new DateTime(2026, 7, 24, 13, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 24, 20, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 24, 13, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001021"), "ARZ-2026-184", new Guid("20000000-0000-0000-0000-000000000002"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 24, 18, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Closed", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 7, 24, 20, 32, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001085"), null, null, null, null, new DateTime(2026, 7, 25, 14, 35, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001028"), "ARZ-2026-185", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "ScadaObservation", "New", new Guid("30000000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001086"), new DateTime(2026, 7, 26, 16, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 26, 15, 42, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001035"), "ARZ-2026-186", new Guid("20000000-0000-0000-0000-000000000005"), "High", null, null, null, "HoneywellEbiObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 26, 16, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001087"), new DateTime(2026, 7, 27, 17, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 27, 16, 49, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001042"), "ARZ-2026-187", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "FieldObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 27, 17, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001088"), new DateTime(2026, 7, 28, 18, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 28, 17, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001049"), "ARZ-2026-188", new Guid("20000000-0000-0000-0000-000000000003"), "Low", null, null, null, "OperatorReport", "InProgress", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 7, 28, 18, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001089"), new DateTime(2026, 7, 29, 7, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 29, 7, 3, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001056"), "ARZ-2026-189", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", null, null, null, "MaintenanceFinding", "Waiting", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 7, 29, 7, 32, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001090"), new DateTime(2026, 7, 30, 8, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 7, 30, 8, 10, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001063"), "ARZ-2026-190", new Guid("20000000-0000-0000-0000-000000000001"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 30, 11, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 30, 11, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001091"), new DateTime(2026, 7, 31, 9, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 31, 16, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 7, 31, 9, 17, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001070"), "ARZ-2026-191", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 7, 31, 13, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 31, 16, 28, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001092"), null, null, null, null, new DateTime(2026, 8, 1, 10, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001077"), "ARZ-2026-192", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "FieldObservation", "New", new Guid("30000000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001093"), new DateTime(2026, 8, 2, 12, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 2, 11, 31, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001084"), "ARZ-2026-193", new Guid("20000000-0000-0000-0000-000000000003"), "Medium", null, null, null, "OperatorReport", "Assigned", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 2, 12, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001094"), new DateTime(2026, 8, 3, 13, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 3, 12, 38, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001091"), "ARZ-2026-194", new Guid("20000000-0000-0000-0000-000000000002"), "High", null, null, null, "MaintenanceFinding", "InReview", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 8, 3, 13, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001095"), new DateTime(2026, 8, 4, 14, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 4, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001098"), "ARZ-2026-195", new Guid("20000000-0000-0000-0000-000000000001"), "Critical", null, null, null, "ScadaObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 4, 14, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001096"), new DateTime(2026, 8, 5, 15, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 5, 14, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001105"), "ARZ-2026-196", new Guid("20000000-0000-0000-0000-000000000005"), "Low", null, null, null, "HoneywellEbiObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 8, 5, 15, 28, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001097"), new DateTime(2026, 8, 6, 16, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 6, 15, 59, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001112"), "ARZ-2026-197", new Guid("20000000-0000-0000-0000-000000000004"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 8, 6, 18, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 6, 18, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001098"), new DateTime(2026, 8, 7, 16, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 7, 20, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 7, 16, 6, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001119"), "ARZ-2026-198", new Guid("20000000-0000-0000-0000-000000000003"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 8, 7, 19, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Closed", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 7, 20, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001099"), null, null, null, null, new DateTime(2026, 8, 8, 17, 13, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001002"), "ARZ-2026-199", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "MaintenanceFinding", "New", new Guid("30000000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001100"), new DateTime(2026, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 1, 7, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001009"), "ARZ-2026-200", new Guid("20000000-0000-0000-0000-000000000003"), "Low", null, null, null, "ScadaObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001101"), new DateTime(2026, 1, 2, 9, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 2, 8, 27, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001016"), "ARZ-2026-201", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", null, null, null, "HoneywellEbiObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 2, 9, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001102"), new DateTime(2026, 1, 3, 10, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 3, 9, 34, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001023"), "ARZ-2026-202", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "FieldObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 3, 10, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001103"), new DateTime(2026, 1, 4, 11, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 4, 10, 41, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001030"), "ARZ-2026-203", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", null, null, null, "OperatorReport", "Waiting", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 4, 11, 24, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001104"), new DateTime(2026, 1, 5, 12, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 5, 11, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001037"), "ARZ-2026-204", new Guid("20000000-0000-0000-0000-000000000004"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 5, 13, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Resolved", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 5, 13, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001105"), new DateTime(2026, 1, 6, 13, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 6, 17, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 6, 12, 55, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001044"), "ARZ-2026-205", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 6, 15, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 6, 17, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001106"), null, null, null, null, new DateTime(2026, 1, 7, 13, 2, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001051"), "ARZ-2026-206", new Guid("20000000-0000-0000-0000-000000000002"), "High", null, null, null, "HoneywellEbiObservation", "New", new Guid("30000000-0000-0000-0000-000000000001"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001107"), new DateTime(2026, 1, 8, 14, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 8, 14, 9, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001058"), "ARZ-2026-207", new Guid("20000000-0000-0000-0000-000000000001"), "Critical", null, null, null, "FieldObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 8, 14, 56, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001108"), new DateTime(2026, 1, 9, 16, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 9, 15, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001065"), "ARZ-2026-208", new Guid("20000000-0000-0000-0000-000000000005"), "Low", null, null, null, "OperatorReport", "InReview", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 9, 16, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001109"), new DateTime(2026, 1, 10, 17, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 10, 16, 23, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001072"), "ARZ-2026-209", new Guid("20000000-0000-0000-0000-000000000004"), "Medium", null, null, null, "MaintenanceFinding", "InProgress", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 10, 17, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001110"), new DateTime(2026, 1, 11, 18, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 11, 17, 30, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001079"), "ARZ-2026-210", new Guid("20000000-0000-0000-0000-000000000003"), "High", null, null, null, "ScadaObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 11, 18, 20, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001111"), new DateTime(2026, 1, 12, 8, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 12, 7, 37, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001086"), "ARZ-2026-211", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 12, 16, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 12, 16, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001112"), new DateTime(2026, 1, 13, 9, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 13, 13, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 13, 8, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001093"), "ARZ-2026-212", new Guid("20000000-0000-0000-0000-000000000001"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 13, 10, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 13, 13, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001113"), null, null, null, null, new DateTime(2026, 1, 14, 9, 51, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001100"), "ARZ-2026-213", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", null, null, null, "OperatorReport", "New", new Guid("30000000-0000-0000-0000-000000000005"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001114"), new DateTime(2026, 1, 15, 11, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 15, 10, 58, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001107"), "ARZ-2026-214", new Guid("20000000-0000-0000-0000-000000000004"), "High", null, null, null, "MaintenanceFinding", "Assigned", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 15, 11, 52, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001115"), new DateTime(2026, 1, 16, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 16, 11, 5, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001114"), "ARZ-2026-215", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "ScadaObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 16, 12, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001117"), new DateTime(2026, 1, 18, 14, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 18, 13, 19, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001004"), "ARZ-2026-217", new Guid("20000000-0000-0000-0000-000000000003"), "Medium", null, null, null, "FieldObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 18, 14, 16, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001118"), new DateTime(2026, 1, 19, 15, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 19, 14, 26, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001011"), "ARZ-2026-218", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 19, 22, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Resolved", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 19, 22, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001119"), new DateTime(2026, 1, 20, 16, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 21, 1, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 20, 15, 33, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001018"), "ARZ-2026-219", new Guid("20000000-0000-0000-0000-000000000001"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 21, 0, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Closed", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 21, 1, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001120"), null, null, null, null, new DateTime(2026, 1, 21, 16, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001025"), "ARZ-2026-220", new Guid("20000000-0000-0000-0000-000000000005"), "Low", null, null, null, "ScadaObservation", "New", new Guid("30000000-0000-0000-0000-000000000005"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001121"), new DateTime(2026, 1, 22, 18, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 22, 17, 47, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001032"), "ARZ-2026-221", new Guid("20000000-0000-0000-0000-000000000004"), "Medium", null, null, null, "HoneywellEbiObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 22, 18, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001122"), new DateTime(2026, 1, 23, 8, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 23, 7, 54, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001039"), "ARZ-2026-222", new Guid("20000000-0000-0000-0000-000000000003"), "High", null, null, null, "FieldObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 23, 8, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001123"), new DateTime(2026, 1, 24, 8, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 24, 8, 1, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001046"), "ARZ-2026-223", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", null, null, null, "OperatorReport", "InProgress", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 24, 8, 24, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001124"), new DateTime(2026, 1, 25, 9, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 25, 9, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001053"), "ARZ-2026-224", new Guid("20000000-0000-0000-0000-000000000001"), "Low", null, null, null, "MaintenanceFinding", "Waiting", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 25, 9, 32, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001125"), new DateTime(2026, 1, 26, 10, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 26, 10, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001060"), "ARZ-2026-225", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 26, 16, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 26, 16, 15, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001126"), new DateTime(2026, 1, 27, 11, 48, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 27, 20, 23, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 27, 11, 22, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001067"), "ARZ-2026-226", new Guid("20000000-0000-0000-0000-000000000004"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 1, 27, 18, 23, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 27, 20, 23, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001127"), null, null, null, null, new DateTime(2026, 1, 28, 12, 29, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001074"), "ARZ-2026-227", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "FieldObservation", "New", new Guid("30000000-0000-0000-0000-000000000004"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001128"), new DateTime(2026, 1, 29, 14, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 29, 13, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001081"), "ARZ-2026-228", new Guid("20000000-0000-0000-0000-000000000002"), "Low", null, null, null, "OperatorReport", "Assigned", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 29, 14, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001129"), new DateTime(2026, 1, 30, 15, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 30, 14, 43, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001088"), "ARZ-2026-229", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "MaintenanceFinding", "InReview", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 30, 15, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001130"), new DateTime(2026, 1, 31, 16, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 1, 31, 15, 50, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001095"), "ARZ-2026-230", new Guid("20000000-0000-0000-0000-000000000005"), "High", null, null, null, "ScadaObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 31, 16, 20, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001131"), new DateTime(2026, 2, 1, 17, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 1, 16, 57, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001102"), "ARZ-2026-231", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "HoneywellEbiObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 1, 17, 28, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001132"), new DateTime(2026, 2, 2, 17, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 2, 17, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001109"), "ARZ-2026-232", new Guid("20000000-0000-0000-0000-000000000003"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 2, 2, 22, 11, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 2, 22, 11, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001133"), new DateTime(2026, 2, 3, 7, 44, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 3, 16, 19, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 3, 7, 11, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001116"), "ARZ-2026-233", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 2, 3, 13, 19, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "OperatorReport", "Closed", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 3, 16, 19, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001135"), new DateTime(2026, 2, 5, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 5, 9, 25, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001006"), "ARZ-2026-235", new Guid("20000000-0000-0000-0000-000000000002"), "Critical", null, null, null, "ScadaObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 5, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001136"), new DateTime(2026, 2, 6, 11, 8, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 6, 10, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001013"), "ARZ-2026-236", new Guid("20000000-0000-0000-0000-000000000001"), "Low", null, null, null, "HoneywellEbiObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 6, 11, 8, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001137"), new DateTime(2026, 2, 7, 12, 16, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 7, 11, 39, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001020"), "ARZ-2026-237", new Guid("20000000-0000-0000-0000-000000000005"), "Medium", null, null, null, "FieldObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 7, 12, 16, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001138"), new DateTime(2026, 2, 8, 13, 24, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 8, 12, 46, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001027"), "ARZ-2026-238", new Guid("20000000-0000-0000-0000-000000000004"), "High", null, null, null, "OperatorReport", "Waiting", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 8, 13, 24, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001139"), new DateTime(2026, 2, 9, 14, 32, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 9, 13, 53, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001034"), "ARZ-2026-239", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 2, 9, 18, 7, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "MaintenanceFinding", "Resolved", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 9, 18, 7, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001140"), new DateTime(2026, 2, 10, 14, 40, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 10, 20, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 10, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001041"), "ARZ-2026-240", new Guid("20000000-0000-0000-0000-000000000002"), "Low", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 2, 10, 19, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "ScadaObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 20, 15, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001141"), null, null, null, null, new DateTime(2026, 2, 11, 15, 7, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001048"), "ARZ-2026-241", new Guid("20000000-0000-0000-0000-000000000001"), "Medium", null, null, null, "HoneywellEbiObservation", "New", new Guid("30000000-0000-0000-0000-000000000003"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001142"), new DateTime(2026, 2, 12, 16, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 12, 16, 14, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001055"), "ARZ-2026-242", new Guid("20000000-0000-0000-0000-000000000005"), "High", null, null, null, "FieldObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 12, 16, 56, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001143"), new DateTime(2026, 2, 13, 18, 4, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 13, 17, 21, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001062"), "ARZ-2026-243", new Guid("20000000-0000-0000-0000-000000000004"), "Critical", null, null, null, "OperatorReport", "InReview", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 13, 18, 4, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001144"), new DateTime(2026, 2, 14, 8, 12, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 14, 7, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001069"), "ARZ-2026-244", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "MaintenanceFinding", "InProgress", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 14, 8, 12, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001145"), new DateTime(2026, 2, 15, 9, 20, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 15, 8, 35, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001076"), "ARZ-2026-245", new Guid("20000000-0000-0000-0000-000000000002"), "Medium", null, null, null, "ScadaObservation", "Waiting", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 15, 9, 20, 0, 0, DateTimeKind.Utc), "Yedek parça ve uygun çalışma zamanı bekleniyor." },
                    { new Guid("60000000-0000-0000-0000-000000001146"), new DateTime(2026, 2, 16, 10, 28, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 16, 9, 42, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Saha kontrolünde anormal ses veya titreşim bildirildi.", new Guid("50000000-0000-0000-0000-000000001083"), "ARZ-2026-246", new Guid("20000000-0000-0000-0000-000000000001"), "High", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 2, 16, 13, 3, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "HoneywellEbiObservation", "Resolved", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 16, 13, 3, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001147"), new DateTime(2026, 2, 17, 11, 36, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 17, 17, 11, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 17, 10, 49, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Operasyon ekranında kesintili haberleşme gözlendi.", new Guid("50000000-0000-0000-0000-000000001090"), "ARZ-2026-247", new Guid("20000000-0000-0000-0000-000000000005"), "Critical", "Sentetik demo senaryosunda müdahale tamamlandı ve değerler normale döndü.", new DateTime(2026, 2, 17, 15, 11, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), "FieldObservation", "Closed", new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 17, 17, 11, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001148"), null, null, null, null, new DateTime(2026, 2, 18, 11, 56, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Periyodik kontrolde performans düşüşü tespit edildi.", new Guid("50000000-0000-0000-0000-000000001097"), "ARZ-2026-248", new Guid("20000000-0000-0000-0000-000000000004"), "Low", null, null, null, "OperatorReport", "New", new Guid("30000000-0000-0000-0000-000000000002"), null, null },
                    { new Guid("60000000-0000-0000-0000-000000001149"), new DateTime(2026, 2, 19, 12, 52, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 19, 12, 3, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Vardiya sırasında takip gerektiren uyarı kaydedildi.", new Guid("50000000-0000-0000-0000-000000001104"), "ARZ-2026-249", new Guid("20000000-0000-0000-0000-000000000003"), "Medium", null, null, null, "MaintenanceFinding", "Assigned", new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 19, 12, 52, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000001150"), new DateTime(2026, 2, 20, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 2, 20, 13, 10, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "Alarm değeri beklenen aralığın dışına çıktı.", new Guid("50000000-0000-0000-0000-000000001111"), "ARZ-2026-250", new Guid("20000000-0000-0000-0000-000000000002"), "High", null, null, null, "ScadaObservation", "InReview", new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 20, 14, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "MaintenancePlans",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "CreatedByUserId", "Description", "EquipmentId", "Frequency", "MaintenanceType", "PlanNo", "PlannedDate", "Priority", "ResponsibleUserId", "StartedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("70000000-0000-0000-0000-000000001001"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001042"), "Aylık", "Aylık", "BKM-2026-101", new DateOnly(2026, 3, 23), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 23, 13, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 3, 23, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001002"), new DateTime(2026, 3, 24, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001047"), "3 Aylık", "3 Aylık", "BKM-2026-102", new DateOnly(2026, 3, 24), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 24, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 3, 24, 11, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001003"), new DateTime(2026, 3, 25, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001052"), "6 Aylık", "6 Aylık", "BKM-2026-103", new DateOnly(2026, 3, 25), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 25, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 3, 25, 13, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001004"), new DateTime(2026, 3, 26, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001057"), "Yıllık", "Yıllık", "BKM-2026-104", new DateOnly(2026, 3, 26), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 26, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 3, 26, 15, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001005"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001062"), "Haftalık", "Haftalık", "BKM-2026-105", new DateOnly(2026, 3, 27), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001006"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001067"), "Aylık", "Aylık", "BKM-2026-106", new DateOnly(2026, 3, 28), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 28, 12, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 3, 28, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001007"), new DateTime(2026, 3, 29, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001072"), "3 Aylık", "3 Aylık", "BKM-2026-107", new DateOnly(2026, 3, 29), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 29, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 3, 29, 16, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001008"), new DateTime(2026, 3, 30, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001077"), "6 Aylık", "6 Aylık", "BKM-2026-108", new DateOnly(2026, 3, 30), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 3, 30, 12, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001009"), new DateTime(2026, 3, 31, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001082"), "Yıllık", "Yıllık", "BKM-2026-109", new DateOnly(2026, 3, 31), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 31, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 3, 31, 14, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001010"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001087"), "Haftalık", "Haftalık", "BKM-2026-110", new DateOnly(2026, 4, 1), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001011"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001092"), "Aylık", "Aylık", "BKM-2026-111", new DateOnly(2026, 4, 2), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 2, 11, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 4, 2, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001012"), new DateTime(2026, 4, 3, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001097"), "3 Aylık", "3 Aylık", "BKM-2026-112", new DateOnly(2026, 4, 3), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 3, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 3, 15, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001013"), new DateTime(2026, 4, 4, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001102"), "6 Aylık", "6 Aylık", "BKM-2026-113", new DateOnly(2026, 4, 4), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 4, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 4, 17, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001014"), new DateTime(2026, 4, 5, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001107"), "Yıllık", "Yıllık", "BKM-2026-114", new DateOnly(2026, 4, 5), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 5, 13, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001015"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001112"), "Haftalık", "Haftalık", "BKM-2026-115", new DateOnly(2026, 4, 6), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001016"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001117"), "Aylık", "Aylık", "BKM-2026-116", new DateOnly(2026, 4, 7), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 7, 10, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 4, 7, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001018"), new DateTime(2026, 4, 9, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001003"), "6 Aylık", "6 Aylık", "BKM-2026-118", new DateOnly(2026, 4, 9), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 9, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 9, 16, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001019"), new DateTime(2026, 4, 10, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001008"), "Yıllık", "Yıllık", "BKM-2026-119", new DateOnly(2026, 4, 10), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 10, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 10, 18, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001020"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001013"), "Haftalık", "Haftalık", "BKM-2026-120", new DateOnly(2026, 4, 11), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001021"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001018"), "Aylık", "Aylık", "BKM-2026-121", new DateOnly(2026, 4, 12), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 12, 9, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 4, 12, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001022"), new DateTime(2026, 4, 13, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001023"), "3 Aylık", "3 Aylık", "BKM-2026-122", new DateOnly(2026, 4, 13), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 13, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 13, 13, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001023"), new DateTime(2026, 4, 14, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001028"), "6 Aylık", "6 Aylık", "BKM-2026-123", new DateOnly(2026, 4, 14), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 14, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 14, 15, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001024"), new DateTime(2026, 4, 15, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001033"), "Yıllık", "Yıllık", "BKM-2026-124", new DateOnly(2026, 4, 15), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 15, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 15, 17, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001025"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001038"), "Haftalık", "Haftalık", "BKM-2026-125", new DateOnly(2026, 4, 16), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001026"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001043"), "Aylık", "Aylık", "BKM-2026-126", new DateOnly(2026, 4, 17), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 4, 17, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001027"), new DateTime(2026, 4, 18, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001048"), "3 Aylık", "3 Aylık", "BKM-2026-127", new DateOnly(2026, 4, 18), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 18, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 18, 12, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001028"), new DateTime(2026, 4, 19, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001053"), "6 Aylık", "6 Aylık", "BKM-2026-128", new DateOnly(2026, 4, 19), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 19, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 19, 14, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001029"), new DateTime(2026, 4, 20, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001058"), "Yıllık", "Yıllık", "BKM-2026-129", new DateOnly(2026, 4, 20), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 20, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 20, 16, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001030"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001063"), "Haftalık", "Haftalık", "BKM-2026-130", new DateOnly(2026, 4, 21), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001031"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001068"), "Aylık", "Aylık", "BKM-2026-131", new DateOnly(2026, 4, 22), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 22, 13, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 4, 22, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001032"), new DateTime(2026, 4, 23, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001073"), "3 Aylık", "3 Aylık", "BKM-2026-132", new DateOnly(2026, 4, 23), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 23, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 23, 11, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001033"), new DateTime(2026, 4, 24, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001078"), "6 Aylık", "6 Aylık", "BKM-2026-133", new DateOnly(2026, 4, 24), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 24, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 24, 13, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001034"), new DateTime(2026, 4, 25, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001083"), "Yıllık", "Yıllık", "BKM-2026-134", new DateOnly(2026, 4, 25), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 25, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 25, 15, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001035"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001088"), "Haftalık", "Haftalık", "BKM-2026-135", new DateOnly(2026, 4, 26), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001036"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001093"), "Aylık", "Aylık", "BKM-2026-136", new DateOnly(2026, 4, 27), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 27, 12, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 4, 27, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001037"), new DateTime(2026, 4, 28, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001098"), "3 Aylık", "3 Aylık", "BKM-2026-137", new DateOnly(2026, 4, 28), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 28, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 28, 16, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001038"), new DateTime(2026, 4, 29, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001103"), "6 Aylık", "6 Aylık", "BKM-2026-138", new DateOnly(2026, 4, 29), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 29, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 29, 12, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001039"), new DateTime(2026, 4, 30, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001108"), "Yıllık", "Yıllık", "BKM-2026-139", new DateOnly(2026, 4, 30), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 4, 30, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 4, 30, 14, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001040"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001113"), "Haftalık", "Haftalık", "BKM-2026-140", new DateOnly(2026, 5, 1), "Low", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001041"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001118"), "Aylık", "Aylık", "BKM-2026-141", new DateOnly(2026, 5, 2), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 2, 11, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 5, 2, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001043"), new DateTime(2026, 5, 4, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001004"), "6 Aylık", "6 Aylık", "BKM-2026-143", new DateOnly(2026, 5, 4), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 4, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 4, 17, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001044"), new DateTime(2026, 5, 5, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001009"), "Yıllık", "Yıllık", "BKM-2026-144", new DateOnly(2026, 5, 5), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 5, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 5, 13, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001045"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001014"), "Haftalık", "Haftalık", "BKM-2026-145", new DateOnly(2026, 5, 6), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001046"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001019"), "Aylık", "Aylık", "BKM-2026-146", new DateOnly(2026, 5, 7), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 7, 10, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 5, 7, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001047"), new DateTime(2026, 5, 8, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001024"), "3 Aylık", "3 Aylık", "BKM-2026-147", new DateOnly(2026, 5, 8), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 8, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 8, 14, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001048"), new DateTime(2026, 5, 9, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001029"), "6 Aylık", "6 Aylık", "BKM-2026-148", new DateOnly(2026, 5, 9), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 9, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 9, 16, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001049"), new DateTime(2026, 5, 10, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001034"), "Yıllık", "Yıllık", "BKM-2026-149", new DateOnly(2026, 5, 10), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 10, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 10, 18, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001050"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001039"), "Haftalık", "Haftalık", "BKM-2026-150", new DateOnly(2026, 5, 11), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001051"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001044"), "Aylık", "Aylık", "BKM-2026-151", new DateOnly(2026, 5, 12), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 12, 9, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 5, 12, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001052"), new DateTime(2026, 5, 13, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001049"), "3 Aylık", "3 Aylık", "BKM-2026-152", new DateOnly(2026, 5, 13), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 13, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 13, 13, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001053"), new DateTime(2026, 5, 14, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001054"), "6 Aylık", "6 Aylık", "BKM-2026-153", new DateOnly(2026, 5, 14), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 14, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 14, 15, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001054"), new DateTime(2026, 5, 15, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001059"), "Yıllık", "Yıllık", "BKM-2026-154", new DateOnly(2026, 5, 15), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 15, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 15, 17, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001055"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001064"), "Haftalık", "Haftalık", "BKM-2026-155", new DateOnly(2026, 5, 16), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001056"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001069"), "Aylık", "Aylık", "BKM-2026-156", new DateOnly(2026, 5, 17), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 17, 8, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 5, 17, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001057"), new DateTime(2026, 5, 18, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001074"), "3 Aylık", "3 Aylık", "BKM-2026-157", new DateOnly(2026, 5, 18), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 18, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 18, 12, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001058"), new DateTime(2026, 5, 19, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001079"), "6 Aylık", "6 Aylık", "BKM-2026-158", new DateOnly(2026, 5, 19), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 19, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 19, 14, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001059"), new DateTime(2026, 5, 20, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001084"), "Yıllık", "Yıllık", "BKM-2026-159", new DateOnly(2026, 5, 20), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 20, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 20, 16, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001060"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001089"), "Haftalık", "Haftalık", "BKM-2026-160", new DateOnly(2026, 5, 21), "Low", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001061"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001094"), "Aylık", "Aylık", "BKM-2026-161", new DateOnly(2026, 5, 22), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 22, 13, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 5, 22, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001062"), new DateTime(2026, 5, 23, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001099"), "3 Aylık", "3 Aylık", "BKM-2026-162", new DateOnly(2026, 5, 23), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 23, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 23, 11, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001063"), new DateTime(2026, 5, 24, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001104"), "6 Aylık", "6 Aylık", "BKM-2026-163", new DateOnly(2026, 5, 24), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 24, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 24, 13, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001064"), new DateTime(2026, 5, 25, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001109"), "Yıllık", "Yıllık", "BKM-2026-164", new DateOnly(2026, 5, 25), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 25, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 25, 15, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001065"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001114"), "Haftalık", "Haftalık", "BKM-2026-165", new DateOnly(2026, 5, 26), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001066"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001119"), "Aylık", "Aylık", "BKM-2026-166", new DateOnly(2026, 5, 27), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 27, 12, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 5, 27, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001068"), new DateTime(2026, 5, 29, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001005"), "6 Aylık", "6 Aylık", "BKM-2026-168", new DateOnly(2026, 5, 29), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 29, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 29, 12, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001069"), new DateTime(2026, 5, 30, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001010"), "Yıllık", "Yıllık", "BKM-2026-169", new DateOnly(2026, 5, 30), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 30, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 5, 30, 14, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001070"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001015"), "Haftalık", "Haftalık", "BKM-2026-170", new DateOnly(2026, 5, 31), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001071"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001020"), "Aylık", "Aylık", "BKM-2026-171", new DateOnly(2026, 6, 1), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 1, 11, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 6, 1, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001072"), new DateTime(2026, 6, 2, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001025"), "3 Aylık", "3 Aylık", "BKM-2026-172", new DateOnly(2026, 6, 2), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 2, 15, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001073"), new DateTime(2026, 6, 3, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001030"), "6 Aylık", "6 Aylık", "BKM-2026-173", new DateOnly(2026, 6, 3), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 3, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 3, 17, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001074"), new DateTime(2026, 6, 4, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001035"), "Yıllık", "Yıllık", "BKM-2026-174", new DateOnly(2026, 6, 4), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 4, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 4, 13, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001075"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001040"), "Haftalık", "Haftalık", "BKM-2026-175", new DateOnly(2026, 6, 5), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001076"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001045"), "Aylık", "Aylık", "BKM-2026-176", new DateOnly(2026, 6, 6), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 6, 10, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 6, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001077"), new DateTime(2026, 6, 7, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001050"), "3 Aylık", "3 Aylık", "BKM-2026-177", new DateOnly(2026, 6, 7), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 7, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 7, 14, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001078"), new DateTime(2026, 6, 8, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001055"), "6 Aylık", "6 Aylık", "BKM-2026-178", new DateOnly(2026, 6, 8), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 8, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 8, 16, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001079"), new DateTime(2026, 6, 9, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001060"), "Yıllık", "Yıllık", "BKM-2026-179", new DateOnly(2026, 6, 9), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 9, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 9, 18, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001080"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001065"), "Haftalık", "Haftalık", "BKM-2026-180", new DateOnly(2026, 6, 10), "Low", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001081"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001070"), "Aylık", "Aylık", "BKM-2026-181", new DateOnly(2026, 6, 11), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 11, 9, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 6, 11, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001082"), new DateTime(2026, 6, 12, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001075"), "3 Aylık", "3 Aylık", "BKM-2026-182", new DateOnly(2026, 6, 12), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 12, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 12, 13, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001083"), new DateTime(2026, 6, 13, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001080"), "6 Aylık", "6 Aylık", "BKM-2026-183", new DateOnly(2026, 6, 13), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 13, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 13, 15, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001084"), new DateTime(2026, 6, 14, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001085"), "Yıllık", "Yıllık", "BKM-2026-184", new DateOnly(2026, 6, 14), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 14, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 14, 17, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001085"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001090"), "Haftalık", "Haftalık", "BKM-2026-185", new DateOnly(2026, 6, 15), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001086"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001095"), "Aylık", "Aylık", "BKM-2026-186", new DateOnly(2026, 6, 16), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 16, 8, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 6, 16, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001087"), new DateTime(2026, 6, 17, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001100"), "3 Aylık", "3 Aylık", "BKM-2026-187", new DateOnly(2026, 6, 17), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 17, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 17, 12, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001088"), new DateTime(2026, 6, 18, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001105"), "6 Aylık", "6 Aylık", "BKM-2026-188", new DateOnly(2026, 6, 18), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 18, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 18, 14, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001089"), new DateTime(2026, 6, 19, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001110"), "Yıllık", "Yıllık", "BKM-2026-189", new DateOnly(2026, 6, 19), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 19, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 19, 16, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001090"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001115"), "Haftalık", "Haftalık", "BKM-2026-190", new DateOnly(2026, 6, 20), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001091"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001120"), "Aylık", "Aylık", "BKM-2026-191", new DateOnly(2026, 6, 21), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 21, 13, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 6, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001092"), new DateTime(2026, 6, 22, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001001"), "3 Aylık", "3 Aylık", "BKM-2026-192", new DateOnly(2026, 6, 22), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 22, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 22, 11, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001093"), new DateTime(2026, 6, 23, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001006"), "6 Aylık", "6 Aylık", "BKM-2026-193", new DateOnly(2026, 6, 23), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 23, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 23, 13, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001094"), new DateTime(2026, 6, 24, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001011"), "Yıllık", "Yıllık", "BKM-2026-194", new DateOnly(2026, 6, 24), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 24, 15, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001095"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001016"), "Haftalık", "Haftalık", "BKM-2026-195", new DateOnly(2026, 6, 25), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001096"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001021"), "Aylık", "Aylık", "BKM-2026-196", new DateOnly(2026, 6, 26), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 26, 12, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 6, 26, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001097"), new DateTime(2026, 6, 27, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001026"), "3 Aylık", "3 Aylık", "BKM-2026-197", new DateOnly(2026, 6, 27), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 27, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 27, 16, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001098"), new DateTime(2026, 6, 28, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001031"), "6 Aylık", "6 Aylık", "BKM-2026-198", new DateOnly(2026, 6, 28), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 28, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 28, 12, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001099"), new DateTime(2026, 6, 29, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001036"), "Yıllık", "Yıllık", "BKM-2026-199", new DateOnly(2026, 6, 29), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 29, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 6, 29, 14, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001100"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001041"), "Haftalık", "Haftalık", "BKM-2026-200", new DateOnly(2026, 6, 30), "Low", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001101"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001046"), "Aylık", "Aylık", "BKM-2026-201", new DateOnly(2026, 7, 1), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 1, 11, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 7, 1, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001102"), new DateTime(2026, 7, 2, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001051"), "3 Aylık", "3 Aylık", "BKM-2026-202", new DateOnly(2026, 7, 2), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 2, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 2, 15, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001103"), new DateTime(2026, 7, 3, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001056"), "6 Aylık", "6 Aylık", "BKM-2026-203", new DateOnly(2026, 7, 3), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 3, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 3, 17, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001104"), new DateTime(2026, 7, 4, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001061"), "Yıllık", "Yıllık", "BKM-2026-204", new DateOnly(2026, 7, 4), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 4, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 4, 13, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001105"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001066"), "Haftalık", "Haftalık", "BKM-2026-205", new DateOnly(2026, 7, 5), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001106"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001071"), "Aylık", "Aylık", "BKM-2026-206", new DateOnly(2026, 7, 6), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 6, 10, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 7, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001107"), new DateTime(2026, 7, 7, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001076"), "3 Aylık", "3 Aylık", "BKM-2026-207", new DateOnly(2026, 7, 7), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 7, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 7, 14, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001108"), new DateTime(2026, 7, 8, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001081"), "6 Aylık", "6 Aylık", "BKM-2026-208", new DateOnly(2026, 7, 8), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 8, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 8, 16, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001109"), new DateTime(2026, 7, 9, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001086"), "Yıllık", "Yıllık", "BKM-2026-209", new DateOnly(2026, 7, 9), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 9, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 9, 18, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001110"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001091"), "Haftalık", "Haftalık", "BKM-2026-210", new DateOnly(2026, 7, 10), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001111"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001096"), "Aylık", "Aylık", "BKM-2026-211", new DateOnly(2026, 7, 11), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 11, 9, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 7, 11, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001112"), new DateTime(2026, 7, 12, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001101"), "3 Aylık", "3 Aylık", "BKM-2026-212", new DateOnly(2026, 7, 12), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 12, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 12, 13, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001113"), new DateTime(2026, 7, 13, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001106"), "6 Aylık", "6 Aylık", "BKM-2026-213", new DateOnly(2026, 7, 13), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 13, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 13, 15, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001114"), new DateTime(2026, 7, 14, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001111"), "Yıllık", "Yıllık", "BKM-2026-214", new DateOnly(2026, 7, 14), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 14, 12, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 14, 17, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001115"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001116"), "Haftalık", "Haftalık", "BKM-2026-215", new DateOnly(2026, 7, 15), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001117"), new DateTime(2026, 7, 17, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001002"), "3 Aylık", "3 Aylık", "BKM-2026-217", new DateOnly(2026, 7, 17), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 17, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 17, 12, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001118"), new DateTime(2026, 7, 18, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001007"), "6 Aylık", "6 Aylık", "BKM-2026-218", new DateOnly(2026, 7, 18), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 18, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 18, 14, 24, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001119"), new DateTime(2026, 7, 19, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001012"), "Yıllık", "Yıllık", "BKM-2026-219", new DateOnly(2026, 7, 19), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 19, 11, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 19, 16, 27, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001120"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001017"), "Haftalık", "Haftalık", "BKM-2026-220", new DateOnly(2026, 7, 20), "Low", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001121"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001022"), "Aylık", "Aylık", "BKM-2026-221", new DateOnly(2026, 7, 21), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 21, 13, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 7, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001122"), new DateTime(2026, 7, 22, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001027"), "3 Aylık", "3 Aylık", "BKM-2026-222", new DateOnly(2026, 7, 22), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 22, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 22, 11, 36, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001123"), new DateTime(2026, 7, 23, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001032"), "6 Aylık", "6 Aylık", "BKM-2026-223", new DateOnly(2026, 7, 23), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 23, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 23, 13, 39, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001124"), new DateTime(2026, 7, 24, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001037"), "Yıllık", "Yıllık", "BKM-2026-224", new DateOnly(2026, 7, 24), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 24, 15, 42, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001125"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001042"), "Haftalık", "Haftalık", "BKM-2026-225", new DateOnly(2026, 7, 25), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000001126"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001047"), "Aylık", "Aylık", "BKM-2026-226", new DateOnly(2026, 7, 26), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 26, 12, 0, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 7, 26, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001127"), new DateTime(2026, 7, 27, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001052"), "3 Aylık", "3 Aylık", "BKM-2026-227", new DateOnly(2026, 7, 27), "Critical", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 27, 13, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 27, 16, 6, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001128"), new DateTime(2026, 7, 28, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001057"), "6 Aylık", "6 Aylık", "BKM-2026-228", new DateOnly(2026, 7, 28), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 28, 8, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 28, 12, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001129"), new DateTime(2026, 7, 29, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001062"), "Yıllık", "Yıllık", "BKM-2026-229", new DateOnly(2026, 7, 29), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 29, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 29, 14, 12, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000001130"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000002"), "Sentetik bakım planı: ekipman kontrol, temizlik, fonksiyon testi ve kayıt doğrulama yapılacak.", new Guid("50000000-0000-0000-0000-000000001067"), "Haftalık", "Haftalık", "BKM-2026-230", new DateOnly(2026, 7, 30), "High", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "ChecklistJson", "CompletedAt", "CreatedAt", "Description", "EquipmentId", "MaintenancePlanId", "MaintenanceType", "PerformedByUserId", "ResultStatus", "StartedAt", "UpdatedAt", "UsedMaterials" },
                values: new object[,]
                {
                    { new Guid("71000000-0000-0000-0000-000000001010"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 8, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 8, 14, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000000002"), new Guid("70000000-0000-0000-0000-000000001017"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 8, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001025"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 3, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 3, 15, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000000003"), new Guid("70000000-0000-0000-0000-000000001042"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 3, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001040"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 28, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 28, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000000004"), new Guid("70000000-0000-0000-0000-000000001067"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 28, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" }
                });

            migrationBuilder.InsertData(
                table: "ShiftItems",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "FaultId", "IsCompleted", "ItemType", "MaintenancePlanId", "Priority", "ShiftHandoverId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("74100000-0000-0000-0000-000000001001"), new DateTime(2027, 4, 23, 8, 46, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001033"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001071"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001002"), new DateTime(2027, 4, 23, 16, 47, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001037"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001072"), "EQ-01037 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001004"), new DateTime(2027, 4, 24, 8, 49, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001074"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 24, 9, 49, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001006"), new DateTime(2027, 4, 24, 23, 51, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001053"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001076"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001007"), new DateTime(2027, 4, 25, 8, 52, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001057"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001077"), "EQ-01057 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001009"), new DateTime(2027, 4, 25, 23, 54, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001079"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001011"), new DateTime(2027, 4, 26, 16, 56, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001073"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001081"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001012"), new DateTime(2027, 4, 26, 23, 57, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001077"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001082"), "EQ-01077 - ekipman izleme", new DateTime(2027, 4, 27, 0, 57, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001014"), new DateTime(2027, 4, 27, 16, 59, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001084"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001016"), new DateTime(2027, 4, 28, 9, 1, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001093"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001086"), "Devam eden operasyon işi", new DateTime(2027, 4, 28, 10, 1, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001017"), new DateTime(2027, 4, 28, 17, 2, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001097"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001087"), "EQ-01097 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001019"), new DateTime(2027, 4, 29, 9, 4, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001089"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001021"), new DateTime(2027, 4, 30, 0, 6, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001113"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001091"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001022"), new DateTime(2027, 4, 30, 9, 7, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001117"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001092"), "EQ-01117 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001023"), new DateTime(2027, 4, 30, 17, 8, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000001"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001116"), "Medium", new Guid("74000000-0000-0000-0000-000000001093"), "BKM-2026-216 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001024"), new DateTime(2027, 5, 1, 0, 9, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001094"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 5, 1, 1, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001026"), new DateTime(2027, 5, 1, 17, 11, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001009"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001096"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001027"), new DateTime(2027, 5, 2, 0, 12, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001013"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001097"), "EQ-01013 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001029"), new DateTime(2027, 5, 2, 17, 14, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001099"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001031"), new DateTime(2026, 8, 12, 8, 31, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001029"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000000001"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001032"), new DateTime(2026, 8, 12, 16, 32, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001033"), null, true, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000000002"), "EQ-01033 - ekipman izleme", new DateTime(2026, 8, 12, 17, 32, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001034"), new DateTime(2027, 3, 31, 0, 19, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001001"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001036"), new DateTime(2027, 3, 31, 17, 21, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001049"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001003"), "Devam eden operasyon işi", new DateTime(2027, 3, 31, 18, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001037"), new DateTime(2027, 4, 1, 0, 22, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001053"), null, false, "EquipmentToWatch", null, "Critical", new Guid("74000000-0000-0000-0000-000000001004"), "EQ-01053 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001039"), new DateTime(2027, 4, 1, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001006"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001041"), new DateTime(2027, 4, 2, 9, 26, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001069"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001008"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001042"), new DateTime(2027, 4, 2, 17, 27, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001073"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001009"), "EQ-01073 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001044"), new DateTime(2027, 4, 3, 9, 29, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001011"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 3, 9, 49, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001046"), new DateTime(2027, 4, 4, 0, 31, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001089"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001013"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001047"), new DateTime(2027, 4, 4, 9, 32, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001093"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001014"), "EQ-01093 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001049"), new DateTime(2027, 4, 5, 0, 34, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001016"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001051"), new DateTime(2027, 4, 5, 16, 46, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001109"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001018"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001052"), new DateTime(2027, 4, 5, 23, 47, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001113"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001019"), "EQ-01113 - ekipman izleme", new DateTime(2027, 4, 6, 0, 57, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001053"), new DateTime(2027, 4, 6, 8, 48, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000001"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000000001"), "Medium", new Guid("74000000-0000-0000-0000-000000001020"), "BKM-2026-001 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001054"), new DateTime(2027, 4, 6, 16, 49, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Critical", new Guid("74000000-0000-0000-0000-000000001021"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001056"), new DateTime(2027, 4, 7, 8, 51, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001005"), null, true, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001023"), "Devam eden operasyon işi", new DateTime(2027, 4, 7, 10, 1, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001057"), new DateTime(2027, 4, 7, 16, 52, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001009"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001024"), "EQ-01009 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001059"), new DateTime(2027, 4, 8, 8, 54, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001026"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001061"), new DateTime(2027, 4, 8, 23, 56, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001025"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001028"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001062"), new DateTime(2027, 4, 9, 8, 57, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001029"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001029"), "EQ-01029 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001064"), new DateTime(2027, 4, 9, 23, 59, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001031"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 10, 1, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001066"), new DateTime(2027, 4, 10, 17, 1, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001045"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001033"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001067"), new DateTime(2027, 4, 11, 0, 2, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001049"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001034"), "EQ-01049 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001069"), new DateTime(2027, 4, 11, 17, 4, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001036"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001071"), new DateTime(2027, 4, 12, 9, 6, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001065"), null, false, "OngoingWork", null, "Critical", new Guid("74000000-0000-0000-0000-000000001038"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001072"), new DateTime(2027, 4, 12, 17, 7, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001069"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001039"), "EQ-01069 - ekipman izleme", new DateTime(2027, 4, 12, 18, 17, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001074"), new DateTime(2027, 4, 13, 9, 9, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001041"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001076"), new DateTime(2027, 4, 14, 0, 11, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001085"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001043"), "Devam eden operasyon işi", new DateTime(2027, 4, 14, 1, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001077"), new DateTime(2027, 4, 14, 9, 12, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001089"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001044"), "EQ-01089 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001079"), new DateTime(2027, 4, 15, 0, 14, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001046"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001081"), new DateTime(2027, 4, 15, 17, 16, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001105"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001048"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001082"), new DateTime(2027, 4, 16, 0, 17, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001109"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001049"), "EQ-01109 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001084"), new DateTime(2027, 4, 16, 17, 19, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001051"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 16, 17, 49, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001086"), new DateTime(2027, 4, 17, 9, 21, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001001"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001053"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001087"), new DateTime(2027, 4, 17, 17, 22, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001005"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001054"), "EQ-01005 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001089"), new DateTime(2027, 4, 18, 9, 24, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001056"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001091"), new DateTime(2027, 4, 19, 0, 26, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001021"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001058"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001092"), new DateTime(2027, 4, 19, 9, 27, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001025"), null, true, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001059"), "EQ-01025 - ekipman izleme", new DateTime(2027, 4, 19, 9, 57, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001094"), new DateTime(2027, 4, 20, 0, 29, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001061"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001096"), new DateTime(2027, 4, 20, 17, 31, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001041"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001063"), "Devam eden operasyon işi", new DateTime(2027, 4, 20, 18, 1, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001097"), new DateTime(2027, 4, 21, 0, 32, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001045"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001064"), "EQ-01045 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001099"), new DateTime(2027, 4, 21, 17, 34, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001066"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001101"), new DateTime(2027, 4, 22, 8, 46, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001061"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001068"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001102"), new DateTime(2027, 4, 22, 16, 47, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001065"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001069"), "EQ-01065 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001104"), new DateTime(2027, 4, 23, 8, 49, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001071"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 23, 10, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001106"), new DateTime(2027, 4, 23, 23, 51, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001081"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001073"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001107"), new DateTime(2027, 4, 24, 8, 52, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001085"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001074"), "EQ-01085 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001109"), new DateTime(2027, 4, 24, 23, 54, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001076"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001111"), new DateTime(2027, 4, 25, 16, 56, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001101"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001078"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001112"), new DateTime(2027, 4, 25, 23, 57, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001105"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001079"), "EQ-01105 - ekipman izleme", new DateTime(2027, 4, 26, 1, 17, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001114"), new DateTime(2027, 4, 26, 16, 59, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001081"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001115"), new DateTime(2027, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000003"), new Guid("60000000-0000-0000-0000-000000000011"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001082"), "ARZ-2026-011 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001116"), new DateTime(2027, 4, 27, 9, 1, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000001"), null, true, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001083"), "Devam eden operasyon işi", new DateTime(2027, 4, 27, 10, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001117"), new DateTime(2027, 4, 27, 17, 2, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001001"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001084"), "EQ-01001 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001119"), new DateTime(2027, 4, 28, 9, 4, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001086"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001121"), new DateTime(2027, 4, 29, 0, 6, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001017"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001088"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001122"), new DateTime(2027, 4, 29, 9, 7, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001021"), null, false, "EquipmentToWatch", null, "Critical", new Guid("74000000-0000-0000-0000-000000001089"), "EQ-01021 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001124"), new DateTime(2027, 4, 30, 0, 9, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001091"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 30, 0, 49, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001126"), new DateTime(2027, 4, 30, 17, 11, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001037"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001093"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001127"), new DateTime(2027, 5, 1, 0, 12, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001041"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001094"), "EQ-01041 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001129"), new DateTime(2027, 5, 1, 17, 14, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001096"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001131"), new DateTime(2027, 5, 2, 9, 16, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001057"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001098"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001132"), new DateTime(2027, 5, 2, 17, 17, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001061"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001099"), "EQ-01061 - ekipman izleme", new DateTime(2027, 5, 2, 17, 57, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001136"), new DateTime(2026, 8, 13, 0, 21, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001077"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000000003"), "Devam eden operasyon işi", new DateTime(2026, 8, 13, 1, 1, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001137"), new DateTime(2027, 3, 31, 0, 22, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001081"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001001"), "EQ-01081 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001139"), new DateTime(2027, 3, 31, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Critical", new Guid("74000000-0000-0000-0000-000000001003"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001141"), new DateTime(2027, 4, 1, 9, 26, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001097"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001005"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001142"), new DateTime(2027, 4, 1, 17, 27, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001101"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001006"), "EQ-01101 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001144"), new DateTime(2027, 4, 2, 9, 29, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001008"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 2, 10, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001146"), new DateTime(2027, 4, 3, 0, 31, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001117"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001010"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001147"), new DateTime(2027, 4, 3, 9, 32, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000001"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001011"), "EQ-00032 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001149"), new DateTime(2027, 4, 4, 0, 34, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001013"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001151"), new DateTime(2027, 4, 4, 16, 46, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001013"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001015"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001152"), new DateTime(2027, 4, 4, 23, 47, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001017"), null, true, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001016"), "EQ-01017 - ekipman izleme", new DateTime(2027, 4, 5, 1, 17, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001154"), new DateTime(2027, 4, 5, 16, 49, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001018"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001156"), new DateTime(2027, 4, 6, 8, 51, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001033"), null, true, "OngoingWork", null, "Critical", new Guid("74000000-0000-0000-0000-000000001020"), "Devam eden operasyon işi", new DateTime(2027, 4, 6, 10, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001157"), new DateTime(2027, 4, 6, 16, 52, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001037"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001021"), "EQ-01037 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001158"), new DateTime(2027, 4, 6, 23, 53, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000001"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001116"), "Medium", new Guid("74000000-0000-0000-0000-000000001022"), "BKM-2026-216 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001159"), new DateTime(2027, 4, 7, 8, 54, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001023"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001161"), new DateTime(2027, 4, 7, 23, 56, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001053"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001025"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001162"), new DateTime(2027, 4, 8, 8, 57, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001057"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001026"), "EQ-01057 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001164"), new DateTime(2027, 4, 8, 23, 59, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001028"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 9, 0, 49, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001166"), new DateTime(2027, 4, 9, 17, 1, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001073"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001030"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001167"), new DateTime(2027, 4, 10, 0, 2, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001077"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001031"), "EQ-01077 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001169"), new DateTime(2027, 4, 10, 17, 4, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001033"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001171"), new DateTime(2027, 4, 11, 9, 6, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001093"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001035"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001172"), new DateTime(2027, 4, 11, 17, 7, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001097"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001036"), "EQ-01097 - ekipman izleme", new DateTime(2027, 4, 11, 17, 57, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001174"), new DateTime(2027, 4, 12, 9, 9, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001038"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001176"), new DateTime(2027, 4, 13, 0, 11, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001113"), null, true, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001040"), "Devam eden operasyon işi", new DateTime(2027, 4, 13, 1, 1, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001177"), new DateTime(2027, 4, 13, 9, 12, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001117"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001041"), "EQ-01117 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001179"), new DateTime(2027, 4, 14, 0, 14, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001043"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001181"), new DateTime(2027, 4, 14, 17, 16, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001009"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001045"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001182"), new DateTime(2027, 4, 15, 0, 17, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001013"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001046"), "EQ-01013 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001184"), new DateTime(2027, 4, 15, 17, 19, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001048"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 15, 18, 9, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001186"), new DateTime(2027, 4, 16, 9, 21, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001029"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001050"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001187"), new DateTime(2027, 4, 16, 17, 22, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001033"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001051"), "EQ-01033 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001188"), new DateTime(2027, 4, 17, 0, 23, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000000001"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000000001"), "Medium", new Guid("74000000-0000-0000-0000-000000001052"), "BKM-2026-001 - bekleyen bakım takibi", new DateTime(2027, 4, 17, 1, 13, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001189"), new DateTime(2027, 4, 17, 9, 24, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001053"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001191"), new DateTime(2027, 4, 18, 0, 26, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001049"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001055"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001192"), new DateTime(2027, 4, 18, 9, 27, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001053"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001056"), "EQ-01053 - ekipman izleme", new DateTime(2027, 4, 18, 10, 17, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001194"), new DateTime(2027, 4, 19, 0, 29, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001058"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001196"), new DateTime(2027, 4, 19, 17, 31, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001069"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001060"), "Devam eden operasyon işi", new DateTime(2027, 4, 19, 18, 21, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001197"), new DateTime(2027, 4, 20, 0, 32, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001073"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001061"), "EQ-01073 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001199"), new DateTime(2027, 4, 20, 17, 34, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001063"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001201"), new DateTime(2027, 4, 21, 8, 46, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001089"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001065"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001202"), new DateTime(2027, 4, 21, 16, 47, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001093"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001066"), "EQ-01093 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001204"), new DateTime(2027, 4, 22, 8, 49, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, true, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001068"), "Kritik saha notu ve çalışma izni kontrolü", new DateTime(2027, 4, 22, 9, 49, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001206"), new DateTime(2027, 4, 22, 23, 51, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001109"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000001070"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001207"), new DateTime(2027, 4, 23, 8, 52, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001113"), null, false, "EquipmentToWatch", null, "Critical", new Guid("74000000-0000-0000-0000-000000001071"), "EQ-01113 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001209"), new DateTime(2027, 4, 23, 23, 54, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Medium", new Guid("74000000-0000-0000-0000-000000001073"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001211"), new DateTime(2027, 4, 24, 16, 56, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001005"), null, false, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001075"), "Devam eden operasyon işi", null },
                    { new Guid("74100000-0000-0000-0000-000000001212"), new DateTime(2027, 4, 24, 23, 57, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001009"), null, true, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000001076"), "EQ-01009 - ekipman izleme", new DateTime(2027, 4, 25, 0, 57, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001214"), new DateTime(2027, 4, 25, 16, 59, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001078"), "Kritik saha notu ve çalışma izni kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000001216"), new DateTime(2027, 4, 26, 9, 1, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001025"), null, true, "OngoingWork", null, "Low", new Guid("74000000-0000-0000-0000-000000001080"), "Devam eden operasyon işi", new DateTime(2027, 4, 26, 10, 1, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001217"), new DateTime(2027, 4, 26, 17, 2, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001029"), null, false, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000001081"), "EQ-01029 - ekipman izleme", null },
                    { new Guid("74100000-0000-0000-0000-000000001219"), new DateTime(2027, 4, 27, 9, 4, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", null, null, false, "CriticalNote", null, "Low", new Guid("74000000-0000-0000-0000-000000001083"), "Kritik saha notu ve çalışma izni kontrolü", null }
                });

            migrationBuilder.InsertData(
                table: "TestPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "Frequency", "PlannedDate", "ResponsibleUserId", "Status", "TestType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("72000000-0000-0000-0000-000000001001"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001024"), "Haftalık", new DateOnly(2026, 5, 2), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 5, 2, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001002"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001027"), "3 Aylık", new DateOnly(2026, 5, 3), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001003"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001030"), "Tek Seferlik", new DateOnly(2026, 5, 4), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001004"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001033"), "Aylık", new DateOnly(2026, 5, 5), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001005"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001036"), "Haftalık", new DateOnly(2026, 5, 6), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 5, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001006"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001039"), "3 Aylık", new DateOnly(2026, 5, 7), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001007"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001042"), "Tek Seferlik", new DateOnly(2026, 5, 8), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001008"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001045"), "Aylık", new DateOnly(2026, 5, 9), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001009"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001048"), "Haftalık", new DateOnly(2026, 5, 10), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 5, 10, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001010"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001051"), "3 Aylık", new DateOnly(2026, 5, 11), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001011"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001054"), "Tek Seferlik", new DateOnly(2026, 5, 12), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001012"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001057"), "Aylık", new DateOnly(2026, 5, 13), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001013"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001060"), "Haftalık", new DateOnly(2026, 5, 14), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 5, 14, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001014"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001063"), "3 Aylık", new DateOnly(2026, 5, 15), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001015"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001066"), "Tek Seferlik", new DateOnly(2026, 5, 16), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001016"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001069"), "Aylık", new DateOnly(2026, 5, 17), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001017"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001072"), "Haftalık", new DateOnly(2026, 5, 18), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 5, 18, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001018"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001075"), "3 Aylık", new DateOnly(2026, 5, 19), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001019"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001078"), "Tek Seferlik", new DateOnly(2026, 5, 20), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001020"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001081"), "Aylık", new DateOnly(2026, 5, 21), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001021"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001084"), "Haftalık", new DateOnly(2026, 5, 22), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 5, 22, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001022"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001087"), "3 Aylık", new DateOnly(2026, 5, 23), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001023"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001090"), "Tek Seferlik", new DateOnly(2026, 5, 24), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001024"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001093"), "Aylık", new DateOnly(2026, 5, 25), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001025"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001096"), "Haftalık", new DateOnly(2026, 5, 26), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 5, 26, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001026"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001099"), "3 Aylık", new DateOnly(2026, 5, 27), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001027"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001102"), "Tek Seferlik", new DateOnly(2026, 5, 28), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001028"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001105"), "Aylık", new DateOnly(2026, 5, 29), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001029"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001108"), "Haftalık", new DateOnly(2026, 5, 30), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 5, 30, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001030"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001111"), "3 Aylık", new DateOnly(2026, 5, 31), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001031"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001114"), "Tek Seferlik", new DateOnly(2026, 6, 1), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001032"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001117"), "Aylık", new DateOnly(2026, 6, 2), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001033"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001120"), "Haftalık", new DateOnly(2026, 6, 3), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 6, 3, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001035"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001002"), "Tek Seferlik", new DateOnly(2026, 6, 5), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001036"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001005"), "Aylık", new DateOnly(2026, 6, 6), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001037"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001008"), "Haftalık", new DateOnly(2026, 6, 7), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 6, 7, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001038"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001011"), "3 Aylık", new DateOnly(2026, 6, 8), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001039"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001014"), "Tek Seferlik", new DateOnly(2026, 6, 9), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001040"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001017"), "Aylık", new DateOnly(2026, 6, 10), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001041"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001020"), "Haftalık", new DateOnly(2026, 6, 11), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 6, 11, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001042"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001023"), "3 Aylık", new DateOnly(2026, 6, 12), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001043"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001026"), "Tek Seferlik", new DateOnly(2026, 6, 13), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001044"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001029"), "Aylık", new DateOnly(2026, 6, 14), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001045"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001032"), "Haftalık", new DateOnly(2026, 6, 15), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 6, 15, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001046"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001035"), "3 Aylık", new DateOnly(2026, 6, 16), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001047"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001038"), "Tek Seferlik", new DateOnly(2026, 6, 17), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001048"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001041"), "Aylık", new DateOnly(2026, 6, 18), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001049"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001044"), "Haftalık", new DateOnly(2026, 6, 19), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 6, 19, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001050"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001047"), "3 Aylık", new DateOnly(2026, 6, 20), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001051"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001050"), "Tek Seferlik", new DateOnly(2026, 6, 21), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001052"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001053"), "Aylık", new DateOnly(2026, 6, 22), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001053"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001056"), "Haftalık", new DateOnly(2026, 6, 23), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 6, 23, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001054"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001059"), "3 Aylık", new DateOnly(2026, 6, 24), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001055"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001062"), "Tek Seferlik", new DateOnly(2026, 6, 25), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001056"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001065"), "Aylık", new DateOnly(2026, 6, 26), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001057"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001068"), "Haftalık", new DateOnly(2026, 6, 27), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 6, 27, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001058"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001071"), "3 Aylık", new DateOnly(2026, 6, 28), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001059"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001074"), "Tek Seferlik", new DateOnly(2026, 6, 29), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001060"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001077"), "Aylık", new DateOnly(2026, 6, 30), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001061"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001080"), "Haftalık", new DateOnly(2026, 7, 1), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 7, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001062"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001083"), "3 Aylık", new DateOnly(2026, 7, 2), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001063"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001086"), "Tek Seferlik", new DateOnly(2026, 7, 3), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001064"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001089"), "Aylık", new DateOnly(2026, 7, 4), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001065"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001092"), "Haftalık", new DateOnly(2026, 7, 5), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 7, 5, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001066"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001095"), "3 Aylık", new DateOnly(2026, 7, 6), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001067"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001098"), "Tek Seferlik", new DateOnly(2026, 7, 7), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001068"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001101"), "Aylık", new DateOnly(2026, 7, 8), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001069"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001104"), "Haftalık", new DateOnly(2026, 7, 9), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 7, 9, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001070"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001107"), "3 Aylık", new DateOnly(2026, 7, 10), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001071"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001110"), "Tek Seferlik", new DateOnly(2026, 7, 11), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001072"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001113"), "Aylık", new DateOnly(2026, 7, 12), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001073"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001116"), "Haftalık", new DateOnly(2026, 7, 13), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 7, 13, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001074"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001119"), "3 Aylık", new DateOnly(2026, 7, 14), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001076"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001001"), "Aylık", new DateOnly(2026, 7, 16), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001077"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001004"), "Haftalık", new DateOnly(2026, 7, 17), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 7, 17, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001078"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001007"), "3 Aylık", new DateOnly(2026, 7, 18), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001079"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001010"), "Tek Seferlik", new DateOnly(2026, 7, 19), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001080"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001013"), "Aylık", new DateOnly(2026, 7, 20), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001081"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001016"), "Haftalık", new DateOnly(2026, 7, 21), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 7, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001082"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001019"), "3 Aylık", new DateOnly(2026, 7, 22), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001083"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001022"), "Tek Seferlik", new DateOnly(2026, 7, 23), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001084"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001025"), "Aylık", new DateOnly(2026, 7, 24), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001085"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001028"), "Haftalık", new DateOnly(2026, 7, 25), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 7, 25, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001086"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001031"), "3 Aylık", new DateOnly(2026, 7, 26), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001087"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001034"), "Tek Seferlik", new DateOnly(2026, 7, 27), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001088"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001037"), "Aylık", new DateOnly(2026, 7, 28), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001089"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001040"), "Haftalık", new DateOnly(2026, 7, 29), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 7, 29, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001090"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001043"), "3 Aylık", new DateOnly(2026, 7, 30), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001091"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001046"), "Tek Seferlik", new DateOnly(2026, 7, 31), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001092"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001049"), "Aylık", new DateOnly(2026, 8, 1), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001093"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001052"), "Haftalık", new DateOnly(2026, 8, 2), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 8, 2, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001094"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001055"), "3 Aylık", new DateOnly(2026, 8, 3), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001095"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001058"), "Tek Seferlik", new DateOnly(2026, 8, 4), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001096"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001061"), "Aylık", new DateOnly(2026, 8, 5), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001097"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001064"), "Haftalık", new DateOnly(2026, 8, 6), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 8, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001098"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001067"), "3 Aylık", new DateOnly(2026, 8, 7), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001099"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001070"), "Tek Seferlik", new DateOnly(2026, 8, 8), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001100"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001073"), "Aylık", new DateOnly(2026, 1, 1), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001101"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001076"), "Haftalık", new DateOnly(2026, 1, 2), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 1, 2, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001102"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001079"), "3 Aylık", new DateOnly(2026, 1, 3), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001103"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001082"), "Tek Seferlik", new DateOnly(2026, 1, 4), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001104"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001085"), "Aylık", new DateOnly(2026, 1, 5), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001105"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001088"), "Haftalık", new DateOnly(2026, 1, 6), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 1, 6, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001106"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001091"), "3 Aylık", new DateOnly(2026, 1, 7), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001107"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001094"), "Tek Seferlik", new DateOnly(2026, 1, 8), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001108"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001097"), "Aylık", new DateOnly(2026, 1, 9), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001109"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001100"), "Haftalık", new DateOnly(2026, 1, 10), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001110"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001103"), "3 Aylık", new DateOnly(2026, 1, 11), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001111"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001106"), "Tek Seferlik", new DateOnly(2026, 1, 12), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "UPS Yük Transfer Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001112"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001109"), "Aylık", new DateOnly(2026, 1, 13), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "HVAC Çalışma Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001113"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001112"), "Haftalık", new DateOnly(2026, 1, 14), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 1, 14, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000001114"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001115"), "3 Aylık", new DateOnly(2026, 1, 15), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001115"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001118"), "Tek Seferlik", new DateOnly(2026, 1, 16), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Haftalık Jeneratör Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001118"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001003"), "3 Aylık", new DateOnly(2026, 1, 19), new Guid("40000000-0000-0000-0000-000000000003"), "Delayed", "PLC I/O Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001119"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001006"), "Tek Seferlik", new DateOnly(2026, 1, 20), new Guid("40000000-0000-0000-0000-000000000003"), "Cancelled", "Acil Durum Senaryo Testi", null },
                    { new Guid("72000000-0000-0000-0000-000000001120"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik test planı: fonksiyon ve senaryo doğrulaması yapılacak.", new Guid("50000000-0000-0000-0000-000000001009"), "Aylık", new DateOnly(2026, 1, 21), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "Haftalık Jeneratör Testi", null }
                });

            migrationBuilder.InsertData(
                table: "TestRecords",
                columns: new[] { "Id", "AbnormalCondition", "CreatedAt", "Description", "DurationMinutes", "EquipmentId", "Result", "TestDate", "TestPlanId", "TestType", "TestedByUserId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("73000000-0000-0000-0000-000000001006"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 18, 14, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 46, new Guid("50000000-0000-0000-0000-000000000004"), "Failed", new DateTime(2026, 1, 18, 14, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001117"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 18, 14, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001048"), null, new DateTime(2026, 7, 15, 8, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 88, new Guid("50000000-0000-0000-0000-000000000002"), "Success", new DateTime(2026, 7, 15, 8, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001075"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 15, 8, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001069"), null, new DateTime(2026, 1, 18, 13, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 39, new Guid("50000000-0000-0000-0000-000000000004"), "ConditionalSuccess", new DateTime(2026, 1, 18, 13, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001117"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 18, 13, 10, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "FaultActions",
                columns: new[] { "Id", "ActionType", "CreatedAt", "FaultId", "Metadata", "NewStatus", "Note", "OldStatus", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("61000000-0000-0000-0000-000000001001"), "Closed", new DateTime(2026, 5, 26, 9, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001025"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001002"), "Created", new DateTime(2026, 5, 28, 12, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001027"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001003"), "Assigned", new DateTime(2026, 5, 30, 13, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001029"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001004"), "StatusChanged", new DateTime(2026, 6, 1, 15, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001031"), "{}", "InReview", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001005"), "NoteAdded", new DateTime(2026, 6, 3, 17, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001033"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001006"), "Resolved", new DateTime(2026, 6, 5, 9, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001035"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001007"), "Closed", new DateTime(2026, 6, 7, 11, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001037"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001008"), "Created", new DateTime(2026, 6, 9, 12, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001039"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001009"), "Assigned", new DateTime(2026, 6, 11, 14, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001041"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001010"), "StatusChanged", new DateTime(2026, 6, 13, 17, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001043"), "{}", "New", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001011"), "NoteAdded", new DateTime(2026, 6, 15, 8, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001045"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001012"), "Resolved", new DateTime(2026, 6, 17, 9, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001047"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001013"), "Closed", new DateTime(2026, 6, 19, 11, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001049"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001014"), "Created", new DateTime(2026, 6, 21, 14, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001051"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001015"), "Assigned", new DateTime(2026, 6, 23, 16, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001053"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001016"), "StatusChanged", new DateTime(2026, 6, 25, 17, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001055"), "{}", "Resolved", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001017"), "NoteAdded", new DateTime(2026, 6, 27, 8, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001057"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001018"), "Resolved", new DateTime(2026, 6, 29, 11, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001059"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001019"), "Closed", new DateTime(2026, 7, 1, 13, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001061"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001021"), "Assigned", new DateTime(2026, 7, 5, 16, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001065"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001022"), "StatusChanged", new DateTime(2026, 7, 7, 8, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001067"), "{}", "InProgress", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001023"), "NoteAdded", new DateTime(2026, 7, 9, 10, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001069"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001024"), "Resolved", new DateTime(2026, 7, 11, 12, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001071"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001025"), "Closed", new DateTime(2026, 7, 13, 13, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001073"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001026"), "Created", new DateTime(2026, 7, 15, 16, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001075"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001027"), "Assigned", new DateTime(2026, 7, 17, 18, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001077"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001028"), "StatusChanged", new DateTime(2026, 7, 19, 9, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001079"), "{}", "Assigned", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001030"), "Resolved", new DateTime(2026, 7, 23, 13, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001083"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001031"), "Closed", new DateTime(2026, 7, 25, 15, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001085"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001032"), "Created", new DateTime(2026, 7, 27, 17, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001087"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001033"), "Assigned", new DateTime(2026, 7, 29, 7, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001089"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001034"), "StatusChanged", new DateTime(2026, 7, 31, 10, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001091"), "{}", "Closed", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001035"), "NoteAdded", new DateTime(2026, 8, 2, 12, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001093"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001036"), "Resolved", new DateTime(2026, 8, 4, 14, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001095"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001037"), "Closed", new DateTime(2026, 8, 6, 16, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001097"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001038"), "Created", new DateTime(2026, 8, 8, 18, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001099"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001039"), "Assigned", new DateTime(2026, 1, 2, 9, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001101"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001040"), "StatusChanged", new DateTime(2026, 1, 4, 11, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001103"), "{}", "Waiting", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001041"), "NoteAdded", new DateTime(2026, 1, 6, 13, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001105"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001042"), "Resolved", new DateTime(2026, 1, 8, 15, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001107"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001043"), "Closed", new DateTime(2026, 1, 10, 17, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001109"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001044"), "Created", new DateTime(2026, 1, 12, 8, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001111"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001045"), "Assigned", new DateTime(2026, 1, 14, 10, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001113"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001046"), "StatusChanged", new DateTime(2026, 1, 16, 12, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001115"), "{}", "InReview", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001047"), "NoteAdded", new DateTime(2026, 1, 18, 14, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001117"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001048"), "Resolved", new DateTime(2026, 1, 20, 16, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001119"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001049"), "Closed", new DateTime(2026, 1, 22, 18, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001121"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001050"), "Created", new DateTime(2026, 1, 24, 9, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001123"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001051"), "Assigned", new DateTime(2026, 1, 26, 11, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001125"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001052"), "StatusChanged", new DateTime(2026, 1, 28, 13, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001127"), "{}", "New", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001053"), "NoteAdded", new DateTime(2026, 1, 30, 15, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001129"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001054"), "Resolved", new DateTime(2026, 2, 1, 18, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001131"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001055"), "Closed", new DateTime(2026, 2, 3, 8, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001133"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001056"), "Created", new DateTime(2026, 2, 5, 10, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001135"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001057"), "Assigned", new DateTime(2026, 2, 7, 12, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001137"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001058"), "StatusChanged", new DateTime(2026, 2, 9, 15, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001139"), "{}", "Resolved", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001059"), "NoteAdded", new DateTime(2026, 2, 11, 16, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001141"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001060"), "Resolved", new DateTime(2026, 2, 13, 18, 41, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001143"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001061"), "Closed", new DateTime(2026, 2, 15, 9, 56, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001145"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001062"), "Created", new DateTime(2026, 2, 17, 12, 11, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001147"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001063"), "Assigned", new DateTime(2026, 2, 19, 13, 26, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001149"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001065"), "NoteAdded", new DateTime(2026, 5, 2, 9, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001001"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001066"), "Resolved", new DateTime(2026, 5, 4, 10, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001003"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001067"), "Closed", new DateTime(2026, 5, 6, 12, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001005"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001068"), "Created", new DateTime(2026, 5, 8, 14, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001007"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001069"), "Assigned", new DateTime(2026, 5, 10, 17, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001009"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001070"), "StatusChanged", new DateTime(2026, 5, 12, 19, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001011"), "{}", "InProgress", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001071"), "NoteAdded", new DateTime(2026, 5, 14, 9, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001013"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001072"), "Resolved", new DateTime(2026, 5, 16, 11, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001015"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001073"), "Closed", new DateTime(2026, 5, 18, 14, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001017"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001074"), "Created", new DateTime(2026, 5, 20, 16, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001019"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001075"), "Assigned", new DateTime(2026, 5, 22, 17, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001021"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001076"), "StatusChanged", new DateTime(2026, 5, 24, 8, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001023"), "{}", "Assigned", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001077"), "NoteAdded", new DateTime(2026, 5, 26, 11, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001025"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001078"), "Resolved", new DateTime(2026, 5, 28, 13, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001027"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001079"), "Closed", new DateTime(2026, 5, 30, 14, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001029"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001080"), "Created", new DateTime(2026, 6, 1, 15, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001031"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001081"), "Assigned", new DateTime(2026, 6, 3, 17, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001033"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001082"), "StatusChanged", new DateTime(2026, 6, 5, 8, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001035"), "{}", "Closed", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001083"), "NoteAdded", new DateTime(2026, 6, 7, 11, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001037"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001084"), "Resolved", new DateTime(2026, 6, 9, 12, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001039"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001085"), "Closed", new DateTime(2026, 6, 11, 14, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001041"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001086"), "Created", new DateTime(2026, 6, 13, 16, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001043"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001087"), "Assigned", new DateTime(2026, 6, 15, 8, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001045"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001088"), "StatusChanged", new DateTime(2026, 6, 17, 9, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001047"), "{}", "Waiting", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001089"), "NoteAdded", new DateTime(2026, 6, 19, 11, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001049"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001090"), "Resolved", new DateTime(2026, 6, 21, 13, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001051"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001091"), "Closed", new DateTime(2026, 6, 23, 16, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001053"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001092"), "Created", new DateTime(2026, 6, 25, 17, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001055"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001093"), "Assigned", new DateTime(2026, 6, 27, 8, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001057"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001094"), "StatusChanged", new DateTime(2026, 6, 29, 10, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001059"), "{}", "InReview", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001095"), "NoteAdded", new DateTime(2026, 7, 1, 13, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001061"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001097"), "Closed", new DateTime(2026, 7, 5, 16, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001065"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001098"), "Created", new DateTime(2026, 7, 7, 7, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001067"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001099"), "Assigned", new DateTime(2026, 7, 9, 10, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001069"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001100"), "StatusChanged", new DateTime(2026, 7, 11, 12, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001071"), "{}", "New", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001101"), "NoteAdded", new DateTime(2026, 7, 13, 13, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001073"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001102"), "Resolved", new DateTime(2026, 7, 15, 15, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001075"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001103"), "Closed", new DateTime(2026, 7, 17, 18, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001077"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001104"), "Created", new DateTime(2026, 7, 19, 9, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001079"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001106"), "StatusChanged", new DateTime(2026, 7, 23, 12, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001083"), "{}", "Resolved", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001107"), "NoteAdded", new DateTime(2026, 7, 25, 15, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001085"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001108"), "Resolved", new DateTime(2026, 7, 27, 17, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001087"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001109"), "Closed", new DateTime(2026, 7, 29, 7, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001089"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001110"), "Created", new DateTime(2026, 7, 31, 9, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001091"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001111"), "Assigned", new DateTime(2026, 8, 2, 12, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001093"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001112"), "StatusChanged", new DateTime(2026, 8, 4, 14, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001095"), "{}", "InProgress", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001113"), "NoteAdded", new DateTime(2026, 8, 6, 16, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001097"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001114"), "Resolved", new DateTime(2026, 8, 8, 17, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001099"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001115"), "Closed", new DateTime(2026, 1, 2, 9, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001101"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001116"), "Created", new DateTime(2026, 1, 4, 11, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001103"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001117"), "Assigned", new DateTime(2026, 1, 6, 13, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001105"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001118"), "StatusChanged", new DateTime(2026, 1, 8, 14, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001107"), "{}", "Assigned", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001119"), "NoteAdded", new DateTime(2026, 1, 10, 17, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001109"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001120"), "Resolved", new DateTime(2026, 1, 12, 8, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001111"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001121"), "Closed", new DateTime(2026, 1, 14, 10, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001113"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001122"), "Created", new DateTime(2026, 1, 16, 11, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001115"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001123"), "Assigned", new DateTime(2026, 1, 18, 14, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001117"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001124"), "StatusChanged", new DateTime(2026, 1, 20, 16, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001119"), "{}", "Closed", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001125"), "NoteAdded", new DateTime(2026, 1, 22, 18, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001121"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001126"), "Resolved", new DateTime(2026, 1, 24, 8, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001123"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001127"), "Closed", new DateTime(2026, 1, 26, 11, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001125"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001128"), "Created", new DateTime(2026, 1, 28, 13, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001127"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001129"), "Assigned", new DateTime(2026, 1, 30, 15, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001129"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001130"), "StatusChanged", new DateTime(2026, 2, 1, 17, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001131"), "{}", "Waiting", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001131"), "NoteAdded", new DateTime(2026, 2, 3, 8, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001133"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001132"), "Resolved", new DateTime(2026, 2, 5, 10, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001135"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001133"), "Closed", new DateTime(2026, 2, 7, 12, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001137"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001134"), "Created", new DateTime(2026, 2, 9, 14, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001139"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001135"), "Assigned", new DateTime(2026, 2, 11, 16, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001141"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001136"), "StatusChanged", new DateTime(2026, 2, 13, 18, 27, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001143"), "{}", "InReview", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001137"), "NoteAdded", new DateTime(2026, 2, 15, 9, 42, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001145"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001138"), "Resolved", new DateTime(2026, 2, 17, 11, 57, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001147"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001139"), "Closed", new DateTime(2026, 2, 19, 13, 12, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001149"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001141"), "Assigned", new DateTime(2026, 5, 2, 8, 58, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001001"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001142"), "StatusChanged", new DateTime(2026, 5, 4, 10, 13, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001003"), "{}", "InReview", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001143"), "NoteAdded", new DateTime(2026, 5, 6, 12, 28, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001005"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001144"), "Resolved", new DateTime(2026, 5, 8, 14, 43, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001007"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001145"), "Closed", new DateTime(2026, 5, 10, 16, 58, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001009"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001146"), "Created", new DateTime(2026, 5, 12, 19, 13, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001011"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001147"), "Assigned", new DateTime(2026, 5, 14, 9, 28, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001013"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001148"), "StatusChanged", new DateTime(2026, 5, 16, 11, 43, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001015"), "{}", "New", "Sentetik arıza işlem kaydı.", "Assigned", null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001149"), "NoteAdded", new DateTime(2026, 5, 18, 13, 58, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001017"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") },
                    { new Guid("61000000-0000-0000-0000-000000001150"), "Resolved", new DateTime(2026, 5, 20, 16, 13, 0, 0, DateTimeKind.Utc), new Guid("60000000-0000-0000-0000-000000001019"), "{}", null, "Sentetik arıza işlem kaydı.", null, null, new Guid("40000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "ChecklistJson", "CompletedAt", "CreatedAt", "Description", "EquipmentId", "MaintenancePlanId", "MaintenanceType", "PerformedByUserId", "ResultStatus", "StartedAt", "UpdatedAt", "UsedMaterials" },
                values: new object[,]
                {
                    { new Guid("71000000-0000-0000-0000-000000001001"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 24, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 24, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001047"), new Guid("70000000-0000-0000-0000-000000001002"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 3, 24, 8, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001002"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 25, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 25, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001052"), new Guid("70000000-0000-0000-0000-000000001003"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 3, 25, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001003"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 26, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 26, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001057"), new Guid("70000000-0000-0000-0000-000000001004"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 3, 26, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001004"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 29, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001072"), new Guid("70000000-0000-0000-0000-000000001007"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 3, 29, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001005"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 30, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 30, 12, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001077"), new Guid("70000000-0000-0000-0000-000000001008"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 3, 30, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001006"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 31, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 31, 14, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001082"), new Guid("70000000-0000-0000-0000-000000001009"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 3, 31, 9, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001007"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 3, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 3, 15, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001097"), new Guid("70000000-0000-0000-0000-000000001012"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 3, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001008"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 4, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 4, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001102"), new Guid("70000000-0000-0000-0000-000000001013"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 4, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001009"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 5, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 5, 13, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001107"), new Guid("70000000-0000-0000-0000-000000001014"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 5, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001011"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 9, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 9, 16, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001003"), new Guid("70000000-0000-0000-0000-000000001018"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 9, 12, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001012"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 10, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 10, 18, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001008"), new Guid("70000000-0000-0000-0000-000000001019"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 10, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001013"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 13, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 13, 13, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001023"), new Guid("70000000-0000-0000-0000-000000001022"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 13, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001014"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 14, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 14, 15, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001028"), new Guid("70000000-0000-0000-0000-000000001023"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 14, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001015"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 15, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 15, 17, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001033"), new Guid("70000000-0000-0000-0000-000000001024"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 4, 15, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001016"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 18, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 18, 12, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001048"), new Guid("70000000-0000-0000-0000-000000001027"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 18, 9, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001017"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 19, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 19, 14, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001053"), new Guid("70000000-0000-0000-0000-000000001028"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 19, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001018"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 20, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 20, 16, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001058"), new Guid("70000000-0000-0000-0000-000000001029"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 20, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001019"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 23, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 23, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001073"), new Guid("70000000-0000-0000-0000-000000001032"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 23, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001020"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 24, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 24, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001078"), new Guid("70000000-0000-0000-0000-000000001033"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 24, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001021"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 25, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 25, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001083"), new Guid("70000000-0000-0000-0000-000000001034"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 25, 10, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001022"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 28, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 28, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001098"), new Guid("70000000-0000-0000-0000-000000001037"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 28, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001023"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 29, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 29, 12, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001103"), new Guid("70000000-0000-0000-0000-000000001038"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 29, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001024"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 30, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 30, 14, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001108"), new Guid("70000000-0000-0000-0000-000000001039"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 30, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001026"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 4, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 4, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001004"), new Guid("70000000-0000-0000-0000-000000001043"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 4, 13, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001027"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 5, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 5, 13, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001009"), new Guid("70000000-0000-0000-0000-000000001044"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 5, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001028"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 8, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 8, 14, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001024"), new Guid("70000000-0000-0000-0000-000000001047"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 8, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001029"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 9, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 9, 16, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001029"), new Guid("70000000-0000-0000-0000-000000001048"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 5, 9, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001030"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 10, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 10, 18, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001034"), new Guid("70000000-0000-0000-0000-000000001049"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 10, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001031"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 13, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 13, 13, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001049"), new Guid("70000000-0000-0000-0000-000000001052"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 13, 10, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001032"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 14, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 14, 15, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001054"), new Guid("70000000-0000-0000-0000-000000001053"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 14, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001033"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 15, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 15, 17, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001059"), new Guid("70000000-0000-0000-0000-000000001054"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 15, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001034"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 18, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 18, 12, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001074"), new Guid("70000000-0000-0000-0000-000000001057"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 18, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001035"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 19, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 19, 14, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001079"), new Guid("70000000-0000-0000-0000-000000001058"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 19, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001036"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 20, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 20, 16, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001084"), new Guid("70000000-0000-0000-0000-000000001059"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 20, 11, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001037"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 23, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 23, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001099"), new Guid("70000000-0000-0000-0000-000000001062"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 23, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001038"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 24, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 24, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001104"), new Guid("70000000-0000-0000-0000-000000001063"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 24, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001039"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 25, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 25, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001109"), new Guid("70000000-0000-0000-0000-000000001064"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 25, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001041"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 29, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 29, 12, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001005"), new Guid("70000000-0000-0000-0000-000000001068"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 29, 8, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001042"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 30, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 30, 14, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001010"), new Guid("70000000-0000-0000-0000-000000001069"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 30, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001043"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 2, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 15, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001025"), new Guid("70000000-0000-0000-0000-000000001072"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001044"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 3, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001030"), new Guid("70000000-0000-0000-0000-000000001073"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 3, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001045"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 4, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 4, 13, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001035"), new Guid("70000000-0000-0000-0000-000000001074"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 4, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001046"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 7, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 7, 14, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001050"), new Guid("70000000-0000-0000-0000-000000001077"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 7, 11, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001047"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 8, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 16, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001055"), new Guid("70000000-0000-0000-0000-000000001078"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 8, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001048"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 9, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 9, 18, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001060"), new Guid("70000000-0000-0000-0000-000000001079"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 9, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001049"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 12, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 13, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001075"), new Guid("70000000-0000-0000-0000-000000001082"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 12, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001050"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 13, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 13, 15, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001080"), new Guid("70000000-0000-0000-0000-000000001083"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 13, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001051"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 14, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 14, 17, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001085"), new Guid("70000000-0000-0000-0000-000000001084"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 14, 12, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001052"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 17, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 17, 12, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001100"), new Guid("70000000-0000-0000-0000-000000001087"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 17, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001053"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 18, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 18, 14, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001105"), new Guid("70000000-0000-0000-0000-000000001088"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 18, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001054"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 19, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 19, 16, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001110"), new Guid("70000000-0000-0000-0000-000000001089"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 19, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001055"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 22, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 22, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001001"), new Guid("70000000-0000-0000-0000-000000001092"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 22, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001056"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 23, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 23, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001006"), new Guid("70000000-0000-0000-0000-000000001093"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 23, 9, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001057"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 24, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 24, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001011"), new Guid("70000000-0000-0000-0000-000000001094"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 6, 24, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001058"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 27, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 27, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001026"), new Guid("70000000-0000-0000-0000-000000001097"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 27, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001059"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 28, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 28, 12, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001031"), new Guid("70000000-0000-0000-0000-000000001098"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 28, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001060"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 6, 29, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 29, 14, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001036"), new Guid("70000000-0000-0000-0000-000000001099"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 6, 29, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001061"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 2, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 2, 15, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001051"), new Guid("70000000-0000-0000-0000-000000001102"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001062"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 3, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 3, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001056"), new Guid("70000000-0000-0000-0000-000000001103"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 3, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001063"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 4, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 4, 13, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001061"), new Guid("70000000-0000-0000-0000-000000001104"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 4, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001064"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 7, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 7, 14, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001076"), new Guid("70000000-0000-0000-0000-000000001107"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 7, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001065"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 8, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 8, 16, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001081"), new Guid("70000000-0000-0000-0000-000000001108"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 8, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001066"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 9, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 18, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001086"), new Guid("70000000-0000-0000-0000-000000001109"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 9, 13, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001067"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 12, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 12, 13, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001101"), new Guid("70000000-0000-0000-0000-000000001112"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 12, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001068"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 13, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 13, 15, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001106"), new Guid("70000000-0000-0000-0000-000000001113"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 13, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001069"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 14, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 14, 17, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001111"), new Guid("70000000-0000-0000-0000-000000001114"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 14, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001070"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 17, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 17, 12, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001002"), new Guid("70000000-0000-0000-0000-000000001117"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 17, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001071"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 18, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 18, 14, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001007"), new Guid("70000000-0000-0000-0000-000000001118"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 7, 18, 10, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001072"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 19, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 19, 16, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001012"), new Guid("70000000-0000-0000-0000-000000001119"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 19, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001073"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 22, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 22, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001027"), new Guid("70000000-0000-0000-0000-000000001122"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 22, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001074"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 23, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 23, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001032"), new Guid("70000000-0000-0000-0000-000000001123"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 23, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001075"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 24, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 24, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001037"), new Guid("70000000-0000-0000-0000-000000001124"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 24, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001076"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 27, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 27, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001052"), new Guid("70000000-0000-0000-0000-000000001127"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 27, 13, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001077"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 28, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 28, 12, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001057"), new Guid("70000000-0000-0000-0000-000000001128"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 28, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001078"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 7, 29, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 29, 14, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001062"), new Guid("70000000-0000-0000-0000-000000001129"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 29, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" }
                });

            migrationBuilder.InsertData(
                table: "ShiftItems",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "FaultId", "IsCompleted", "ItemType", "MaintenancePlanId", "Priority", "ShiftHandoverId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("74100000-0000-0000-0000-000000001003"), new DateTime(2027, 4, 23, 23, 48, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001117"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001016"), "Critical", new Guid("74000000-0000-0000-0000-000000001073"), "BKM-2026-116 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001005"), new DateTime(2027, 4, 24, 16, 50, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001067"), new Guid("60000000-0000-0000-0000-000000001126"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001075"), "ARZ-2026-226 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001008"), new DateTime(2027, 4, 25, 16, 53, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001118"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001041"), "Medium", new Guid("74000000-0000-0000-0000-000000001078"), "BKM-2026-141 - bekleyen bakım takibi", new DateTime(2027, 4, 25, 17, 53, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001010"), new DateTime(2027, 4, 26, 8, 55, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001048"), new Guid("60000000-0000-0000-0000-000000001141"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001080"), "ARZ-2026-241 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001013"), new DateTime(2027, 4, 27, 8, 58, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001119"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001066"), "Low", new Guid("74000000-0000-0000-0000-000000001083"), "BKM-2026-166 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001015"), new DateTime(2027, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001081"), new Guid("60000000-0000-0000-0000-000000001004"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001085"), "ARZ-2026-104 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001018"), new DateTime(2027, 4, 29, 0, 3, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001120"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001091"), "Low", new Guid("74000000-0000-0000-0000-000000001088"), "BKM-2026-191 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001020"), new DateTime(2027, 4, 29, 17, 5, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001062"), new Guid("60000000-0000-0000-0000-000000001019"), true, "OpenFault", null, "Critical", new Guid("74000000-0000-0000-0000-000000001090"), "ARZ-2026-119 - açık arıza takibi", new DateTime(2027, 4, 29, 18, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001025"), new DateTime(2027, 5, 1, 9, 10, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001043"), new Guid("60000000-0000-0000-0000-000000001034"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001095"), "ARZ-2026-134 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001028"), new DateTime(2027, 5, 2, 9, 13, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001067"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001006"), "Low", new Guid("74000000-0000-0000-0000-000000001098"), "BKM-2026-106 - bekleyen bakım takibi", new DateTime(2027, 5, 2, 10, 13, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001030"), new DateTime(2027, 5, 3, 0, 15, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001024"), new Guid("60000000-0000-0000-0000-000000001049"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001100"), "ARZ-2026-149 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001033"), new DateTime(2026, 8, 13, 0, 18, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001068"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001031"), "Low", new Guid("74000000-0000-0000-0000-000000000003"), "BKM-2026-131 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001035"), new DateTime(2027, 3, 31, 9, 20, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001005"), new Guid("60000000-0000-0000-0000-000000001064"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001002"), "ARZ-2026-164 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001038"), new DateTime(2027, 4, 1, 9, 23, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001069"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001056"), "Medium", new Guid("74000000-0000-0000-0000-000000001005"), "BKM-2026-156 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001040"), new DateTime(2027, 4, 2, 0, 25, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001110"), new Guid("60000000-0000-0000-0000-000000001079"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001007"), "ARZ-2026-179 - açık arıza takibi", new DateTime(2027, 4, 2, 0, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001043"), new DateTime(2027, 4, 3, 0, 28, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001070"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001081"), "Low", new Guid("74000000-0000-0000-0000-000000001010"), "BKM-2026-181 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001045"), new DateTime(2027, 4, 3, 17, 30, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001091"), new Guid("60000000-0000-0000-0000-000000001094"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001012"), "ARZ-2026-194 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001048"), new DateTime(2027, 4, 4, 17, 33, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001071"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001106"), "Low", new Guid("74000000-0000-0000-0000-000000001015"), "BKM-2026-206 - bekleyen bakım takibi", new DateTime(2027, 4, 4, 17, 53, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001050"), new DateTime(2027, 4, 5, 8, 45, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001072"), new Guid("60000000-0000-0000-0000-000000001109"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001017"), "ARZ-2026-209 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001055"), new DateTime(2027, 4, 6, 23, 50, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001053"), new Guid("60000000-0000-0000-0000-000000001124"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001022"), "ARZ-2026-224 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001058"), new DateTime(2027, 4, 7, 23, 53, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001018"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001021"), "Low", new Guid("74000000-0000-0000-0000-000000001025"), "BKM-2026-121 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001060"), new DateTime(2027, 4, 8, 16, 55, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001034"), new Guid("60000000-0000-0000-0000-000000001139"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001027"), "ARZ-2026-239 - açık arıza takibi", new DateTime(2027, 4, 8, 18, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001063"), new DateTime(2027, 4, 9, 16, 58, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001019"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001046"), "Low", new Guid("74000000-0000-0000-0000-000000001030"), "BKM-2026-146 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001065"), new DateTime(2027, 4, 10, 9, 0, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001067"), new Guid("60000000-0000-0000-0000-000000001002"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001032"), "ARZ-2026-102 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001068"), new DateTime(2027, 4, 11, 9, 3, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001020"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001071"), "Medium", new Guid("74000000-0000-0000-0000-000000001035"), "BKM-2026-171 - bekleyen bakım takibi", new DateTime(2027, 4, 11, 10, 13, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001070"), new DateTime(2027, 4, 12, 0, 5, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001048"), new Guid("60000000-0000-0000-0000-000000001017"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001037"), "ARZ-2026-117 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001073"), new DateTime(2027, 4, 13, 0, 8, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001021"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001096"), "Low", new Guid("74000000-0000-0000-0000-000000001040"), "BKM-2026-196 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001075"), new DateTime(2027, 4, 13, 17, 10, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001029"), new Guid("60000000-0000-0000-0000-000000001032"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001042"), "ARZ-2026-132 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001078"), new DateTime(2027, 4, 14, 17, 13, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001022"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001121"), "Low", new Guid("74000000-0000-0000-0000-000000001045"), "BKM-2026-221 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001080"), new DateTime(2027, 4, 15, 9, 15, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001010"), new Guid("60000000-0000-0000-0000-000000001047"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001047"), "ARZ-2026-147 - açık arıza takibi", new DateTime(2027, 4, 15, 9, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001083"), new DateTime(2027, 4, 16, 9, 18, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001092"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001011"), "Medium", new Guid("74000000-0000-0000-0000-000000001050"), "BKM-2026-111 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001085"), new DateTime(2027, 4, 17, 0, 20, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001115"), new Guid("60000000-0000-0000-0000-000000001062"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001052"), "ARZ-2026-162 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001088"), new DateTime(2027, 4, 18, 0, 23, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001093"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001036"), "Critical", new Guid("74000000-0000-0000-0000-000000001055"), "BKM-2026-136 - bekleyen bakım takibi", new DateTime(2027, 4, 18, 0, 53, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001090"), new DateTime(2027, 4, 18, 17, 25, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001096"), new Guid("60000000-0000-0000-0000-000000001077"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001057"), "ARZ-2026-177 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001093"), new DateTime(2027, 4, 19, 17, 28, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001094"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001061"), "Low", new Guid("74000000-0000-0000-0000-000000001060"), "BKM-2026-161 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001095"), new DateTime(2027, 4, 20, 9, 30, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001077"), new Guid("60000000-0000-0000-0000-000000001092"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001062"), "ARZ-2026-192 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001098"), new DateTime(2027, 4, 21, 9, 33, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001095"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001086"), "Medium", new Guid("74000000-0000-0000-0000-000000001065"), "BKM-2026-186 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001100"), new DateTime(2027, 4, 21, 23, 45, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001058"), new Guid("60000000-0000-0000-0000-000000001107"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001067"), "ARZ-2026-207 - açık arıza takibi", new DateTime(2027, 4, 22, 1, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001103"), new DateTime(2027, 4, 22, 23, 48, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001096"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001111"), "Low", new Guid("74000000-0000-0000-0000-000000001070"), "BKM-2026-211 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001105"), new DateTime(2027, 4, 23, 16, 50, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001039"), new Guid("60000000-0000-0000-0000-000000001122"), false, "OpenFault", null, "Critical", new Guid("74000000-0000-0000-0000-000000001072"), "ARZ-2026-222 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001108"), new DateTime(2027, 4, 24, 16, 53, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001042"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001001"), "Low", new Guid("74000000-0000-0000-0000-000000001075"), "BKM-2026-101 - bekleyen bakım takibi", new DateTime(2027, 4, 24, 18, 13, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001110"), new DateTime(2027, 4, 25, 8, 55, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001020"), new Guid("60000000-0000-0000-0000-000000001137"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001077"), "ARZ-2026-237 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001113"), new DateTime(2027, 4, 26, 8, 58, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001043"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001026"), "Medium", new Guid("74000000-0000-0000-0000-000000001080"), "BKM-2026-126 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001118"), new DateTime(2027, 4, 28, 0, 3, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001044"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001051"), "Low", new Guid("74000000-0000-0000-0000-000000001085"), "BKM-2026-151 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001120"), new DateTime(2027, 4, 28, 17, 5, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001034"), new Guid("60000000-0000-0000-0000-000000001015"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001087"), "ARZ-2026-115 - açık arıza takibi", new DateTime(2027, 4, 28, 17, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001123"), new DateTime(2027, 4, 29, 17, 8, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001045"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001076"), "Low", new Guid("74000000-0000-0000-0000-000000001090"), "BKM-2026-176 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001125"), new DateTime(2027, 4, 30, 9, 10, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001015"), new Guid("60000000-0000-0000-0000-000000001030"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001092"), "ARZ-2026-130 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001128"), new DateTime(2027, 5, 1, 9, 13, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001046"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001101"), "Medium", new Guid("74000000-0000-0000-0000-000000001095"), "BKM-2026-201 - bekleyen bakım takibi", new DateTime(2027, 5, 1, 9, 53, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001130"), new DateTime(2027, 5, 2, 0, 15, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001120"), new Guid("60000000-0000-0000-0000-000000001045"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001097"), "ARZ-2026-145 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001133"), new DateTime(2027, 5, 3, 0, 18, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001047"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001126"), "Low", new Guid("74000000-0000-0000-0000-000000001100"), "BKM-2026-226 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001135"), new DateTime(2026, 8, 12, 16, 35, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001101"), new Guid("60000000-0000-0000-0000-000000001060"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000000002"), "ARZ-2026-160 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001138"), new DateTime(2027, 3, 31, 9, 23, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001117"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001016"), "Low", new Guid("74000000-0000-0000-0000-000000001002"), "BKM-2026-116 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001140"), new DateTime(2027, 4, 1, 0, 25, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001082"), new Guid("60000000-0000-0000-0000-000000001075"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001004"), "ARZ-2026-175 - açık arıza takibi", new DateTime(2027, 4, 1, 1, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001143"), new DateTime(2027, 4, 2, 0, 28, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001118"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001041"), "Medium", new Guid("74000000-0000-0000-0000-000000001007"), "BKM-2026-141 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001145"), new DateTime(2027, 4, 2, 17, 30, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001063"), new Guid("60000000-0000-0000-0000-000000001090"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001009"), "ARZ-2026-190 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001148"), new DateTime(2027, 4, 3, 17, 33, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001119"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001066"), "Low", new Guid("74000000-0000-0000-0000-000000001012"), "BKM-2026-166 - bekleyen bakım takibi", new DateTime(2027, 4, 3, 18, 13, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001150"), new DateTime(2027, 4, 4, 8, 45, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001044"), new Guid("60000000-0000-0000-0000-000000001105"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001014"), "ARZ-2026-205 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001153"), new DateTime(2027, 4, 5, 8, 48, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001120"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001091"), "Low", new Guid("74000000-0000-0000-0000-000000001017"), "BKM-2026-191 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001155"), new DateTime(2027, 4, 5, 23, 50, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001025"), new Guid("60000000-0000-0000-0000-000000001120"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001019"), "ARZ-2026-220 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001160"), new DateTime(2027, 4, 7, 16, 55, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001006"), new Guid("60000000-0000-0000-0000-000000001135"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001024"), "ARZ-2026-235 - açık arıza takibi", new DateTime(2027, 4, 7, 17, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001163"), new DateTime(2027, 4, 8, 16, 58, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001067"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001006"), "Low", new Guid("74000000-0000-0000-0000-000000001027"), "BKM-2026-106 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001165"), new DateTime(2027, 4, 9, 9, 0, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001111"), new Guid("60000000-0000-0000-0000-000000001150"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001029"), "ARZ-2026-250 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001168"), new DateTime(2027, 4, 10, 9, 3, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001068"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001031"), "Low", new Guid("74000000-0000-0000-0000-000000001032"), "BKM-2026-131 - bekleyen bakım takibi", new DateTime(2027, 4, 10, 9, 53, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001170"), new DateTime(2027, 4, 11, 0, 5, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001020"), new Guid("60000000-0000-0000-0000-000000001013"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001034"), "ARZ-2026-113 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001173"), new DateTime(2027, 4, 12, 0, 8, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001069"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001056"), "Critical", new Guid("74000000-0000-0000-0000-000000001037"), "BKM-2026-156 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001175"), new DateTime(2027, 4, 12, 17, 10, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001001"), new Guid("60000000-0000-0000-0000-000000001028"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001039"), "ARZ-2026-128 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001178"), new DateTime(2027, 4, 13, 17, 13, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001070"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001081"), "Low", new Guid("74000000-0000-0000-0000-000000001042"), "BKM-2026-181 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001180"), new DateTime(2027, 4, 14, 9, 15, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001106"), new Guid("60000000-0000-0000-0000-000000001043"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001044"), "ARZ-2026-143 - açık arıza takibi", new DateTime(2027, 4, 14, 10, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001183"), new DateTime(2027, 4, 15, 9, 18, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001071"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001106"), "Low", new Guid("74000000-0000-0000-0000-000000001047"), "BKM-2026-206 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001185"), new DateTime(2027, 4, 16, 0, 20, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001087"), new Guid("60000000-0000-0000-0000-000000001058"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001049"), "ARZ-2026-158 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001190"), new DateTime(2027, 4, 17, 17, 25, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001068"), new Guid("60000000-0000-0000-0000-000000001073"), false, "OpenFault", null, "Critical", new Guid("74000000-0000-0000-0000-000000001054"), "ARZ-2026-173 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001193"), new DateTime(2027, 4, 18, 17, 28, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001018"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001021"), "Low", new Guid("74000000-0000-0000-0000-000000001057"), "BKM-2026-121 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001195"), new DateTime(2027, 4, 19, 9, 30, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001049"), new Guid("60000000-0000-0000-0000-000000001088"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001059"), "ARZ-2026-188 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001198"), new DateTime(2027, 4, 20, 9, 33, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001019"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001046"), "Low", new Guid("74000000-0000-0000-0000-000000001062"), "BKM-2026-146 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001200"), new DateTime(2027, 4, 20, 23, 45, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001030"), new Guid("60000000-0000-0000-0000-000000001103"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001064"), "ARZ-2026-203 - açık arıza takibi", new DateTime(2027, 4, 21, 0, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001203"), new DateTime(2027, 4, 21, 23, 48, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001020"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001071"), "Medium", new Guid("74000000-0000-0000-0000-000000001067"), "BKM-2026-171 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001205"), new DateTime(2027, 4, 22, 16, 50, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001011"), new Guid("60000000-0000-0000-0000-000000001118"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001069"), "ARZ-2026-218 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001208"), new DateTime(2027, 4, 23, 16, 53, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001021"), null, true, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001096"), "Low", new Guid("74000000-0000-0000-0000-000000001072"), "BKM-2026-196 - bekleyen bakım takibi", new DateTime(2027, 4, 23, 17, 53, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000001210"), new DateTime(2027, 4, 24, 8, 55, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001116"), new Guid("60000000-0000-0000-0000-000000001133"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001074"), "ARZ-2026-233 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001213"), new DateTime(2027, 4, 25, 8, 58, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001022"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001121"), "Low", new Guid("74000000-0000-0000-0000-000000001077"), "BKM-2026-221 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001215"), new DateTime(2027, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001097"), new Guid("60000000-0000-0000-0000-000000001148"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001079"), "ARZ-2026-248 - açık arıza takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001218"), new DateTime(2027, 4, 27, 0, 3, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001092"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000001011"), "Medium", new Guid("74000000-0000-0000-0000-000000001082"), "BKM-2026-111 - bekleyen bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000001220"), new DateTime(2027, 4, 27, 17, 5, 0, 0, DateTimeKind.Utc), "Sentetik vardiya maddesi: sonraki ekip tarafından takip edilecek operasyon notu.", new Guid("50000000-0000-0000-0000-000000001006"), new Guid("60000000-0000-0000-0000-000000001011"), true, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000001084"), "ARZ-2026-111 - açık arıza takibi", new DateTime(2027, 4, 27, 18, 5, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "TestRecords",
                columns: new[] { "Id", "AbnormalCondition", "CreatedAt", "Description", "DurationMinutes", "EquipmentId", "Result", "TestDate", "TestPlanId", "TestType", "TestedByUserId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("73000000-0000-0000-0000-000000001001"), null, new DateTime(2026, 1, 8, 9, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 41, new Guid("50000000-0000-0000-0000-000000001094"), "ConditionalSuccess", new DateTime(2026, 1, 8, 9, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001107"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 8, 9, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001002"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 10, 10, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 42, new Guid("50000000-0000-0000-0000-000000001100"), "Failed", new DateTime(2026, 1, 10, 10, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001109"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 10, 10, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001003"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 12, 11, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 43, new Guid("50000000-0000-0000-0000-000000001106"), "RetestRequired", new DateTime(2026, 1, 12, 11, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001111"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 12, 11, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001004"), null, new DateTime(2026, 1, 14, 12, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 44, new Guid("50000000-0000-0000-0000-000000001112"), "Success", new DateTime(2026, 1, 14, 12, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001113"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 14, 12, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001005"), null, new DateTime(2026, 1, 16, 13, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 45, new Guid("50000000-0000-0000-0000-000000001118"), "ConditionalSuccess", new DateTime(2026, 1, 16, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001115"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 16, 13, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001007"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 20, 15, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 47, new Guid("50000000-0000-0000-0000-000000001006"), "RetestRequired", new DateTime(2026, 1, 20, 15, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001119"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 20, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001011"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 2, 11, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 51, new Guid("50000000-0000-0000-0000-000000001024"), "RetestRequired", new DateTime(2026, 5, 2, 11, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001001"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 2, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001012"), null, new DateTime(2026, 5, 4, 12, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 52, new Guid("50000000-0000-0000-0000-000000001030"), "Success", new DateTime(2026, 5, 4, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001003"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 4, 12, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001013"), null, new DateTime(2026, 5, 6, 13, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 53, new Guid("50000000-0000-0000-0000-000000001036"), "ConditionalSuccess", new DateTime(2026, 5, 6, 13, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001005"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 6, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001014"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 54, new Guid("50000000-0000-0000-0000-000000001042"), "Failed", new DateTime(2026, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001007"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 8, 14, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001015"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 10, 15, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 55, new Guid("50000000-0000-0000-0000-000000001048"), "RetestRequired", new DateTime(2026, 5, 10, 15, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001009"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 10, 15, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001016"), null, new DateTime(2026, 5, 12, 8, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 56, new Guid("50000000-0000-0000-0000-000000001054"), "Success", new DateTime(2026, 5, 12, 8, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001011"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 12, 8, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001017"), null, new DateTime(2026, 5, 14, 9, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 57, new Guid("50000000-0000-0000-0000-000000001060"), "ConditionalSuccess", new DateTime(2026, 5, 14, 9, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001013"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 14, 9, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001018"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 16, 10, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 58, new Guid("50000000-0000-0000-0000-000000001066"), "Failed", new DateTime(2026, 5, 16, 10, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001015"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 16, 10, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001019"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 18, 11, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 59, new Guid("50000000-0000-0000-0000-000000001072"), "RetestRequired", new DateTime(2026, 5, 18, 11, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001017"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 18, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001020"), null, new DateTime(2026, 5, 20, 12, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 60, new Guid("50000000-0000-0000-0000-000000001078"), "Success", new DateTime(2026, 5, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001019"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 20, 12, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001021"), null, new DateTime(2026, 5, 22, 13, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 61, new Guid("50000000-0000-0000-0000-000000001084"), "ConditionalSuccess", new DateTime(2026, 5, 22, 13, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001021"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 22, 13, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001022"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 24, 14, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 62, new Guid("50000000-0000-0000-0000-000000001090"), "Failed", new DateTime(2026, 5, 24, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001023"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 24, 14, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001023"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 26, 15, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 63, new Guid("50000000-0000-0000-0000-000000001096"), "RetestRequired", new DateTime(2026, 5, 26, 15, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001025"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 26, 15, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001024"), null, new DateTime(2026, 5, 28, 8, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 64, new Guid("50000000-0000-0000-0000-000000001102"), "Success", new DateTime(2026, 5, 28, 8, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001027"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 28, 8, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001025"), null, new DateTime(2026, 5, 30, 9, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 65, new Guid("50000000-0000-0000-0000-000000001108"), "ConditionalSuccess", new DateTime(2026, 5, 30, 9, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001029"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 30, 9, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001026"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 1, 10, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 66, new Guid("50000000-0000-0000-0000-000000001114"), "Failed", new DateTime(2026, 6, 1, 10, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001031"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 1, 10, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001027"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 3, 11, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 67, new Guid("50000000-0000-0000-0000-000000001120"), "RetestRequired", new DateTime(2026, 6, 3, 11, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001033"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 3, 11, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001028"), null, new DateTime(2026, 6, 5, 12, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 68, new Guid("50000000-0000-0000-0000-000000001002"), "Success", new DateTime(2026, 6, 5, 12, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001035"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 5, 12, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001029"), null, new DateTime(2026, 6, 7, 13, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 69, new Guid("50000000-0000-0000-0000-000000001008"), "ConditionalSuccess", new DateTime(2026, 6, 7, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001037"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 7, 13, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001030"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 9, 14, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 70, new Guid("50000000-0000-0000-0000-000000001014"), "Failed", new DateTime(2026, 6, 9, 14, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001039"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 9, 14, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001031"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 11, 15, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 71, new Guid("50000000-0000-0000-0000-000000001020"), "RetestRequired", new DateTime(2026, 6, 11, 15, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001041"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 11, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001032"), null, new DateTime(2026, 6, 13, 8, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 72, new Guid("50000000-0000-0000-0000-000000001026"), "Success", new DateTime(2026, 6, 13, 8, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001043"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 13, 8, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001033"), null, new DateTime(2026, 6, 15, 9, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 73, new Guid("50000000-0000-0000-0000-000000001032"), "ConditionalSuccess", new DateTime(2026, 6, 15, 9, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001045"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 15, 9, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001034"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 17, 10, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 74, new Guid("50000000-0000-0000-0000-000000001038"), "Failed", new DateTime(2026, 6, 17, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001047"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 17, 10, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001035"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 19, 11, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 75, new Guid("50000000-0000-0000-0000-000000001044"), "RetestRequired", new DateTime(2026, 6, 19, 11, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001049"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 19, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001036"), null, new DateTime(2026, 6, 21, 12, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 76, new Guid("50000000-0000-0000-0000-000000001050"), "Success", new DateTime(2026, 6, 21, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001051"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 21, 12, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001037"), null, new DateTime(2026, 6, 23, 13, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 77, new Guid("50000000-0000-0000-0000-000000001056"), "ConditionalSuccess", new DateTime(2026, 6, 23, 13, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001053"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 23, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001038"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 25, 14, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 78, new Guid("50000000-0000-0000-0000-000000001062"), "Failed", new DateTime(2026, 6, 25, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001055"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 25, 14, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001039"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 27, 15, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 79, new Guid("50000000-0000-0000-0000-000000001068"), "RetestRequired", new DateTime(2026, 6, 27, 15, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001057"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 27, 15, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001040"), null, new DateTime(2026, 6, 29, 8, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 80, new Guid("50000000-0000-0000-0000-000000001074"), "Success", new DateTime(2026, 6, 29, 8, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001059"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 29, 8, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001041"), null, new DateTime(2026, 7, 1, 9, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 81, new Guid("50000000-0000-0000-0000-000000001080"), "ConditionalSuccess", new DateTime(2026, 7, 1, 9, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001061"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 1, 9, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001042"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 3, 10, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 82, new Guid("50000000-0000-0000-0000-000000001086"), "Failed", new DateTime(2026, 7, 3, 10, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001063"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 3, 10, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001043"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 5, 11, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 83, new Guid("50000000-0000-0000-0000-000000001092"), "RetestRequired", new DateTime(2026, 7, 5, 11, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001065"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001044"), null, new DateTime(2026, 7, 7, 12, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 84, new Guid("50000000-0000-0000-0000-000000001098"), "Success", new DateTime(2026, 7, 7, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001067"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 7, 12, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001045"), null, new DateTime(2026, 7, 9, 13, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 85, new Guid("50000000-0000-0000-0000-000000001104"), "ConditionalSuccess", new DateTime(2026, 7, 9, 13, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001069"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 9, 13, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001046"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 11, 14, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 86, new Guid("50000000-0000-0000-0000-000000001110"), "Failed", new DateTime(2026, 7, 11, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001071"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 11, 14, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001047"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 13, 15, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 87, new Guid("50000000-0000-0000-0000-000000001116"), "RetestRequired", new DateTime(2026, 7, 13, 15, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001073"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 13, 15, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001049"), null, new DateTime(2026, 7, 17, 9, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 89, new Guid("50000000-0000-0000-0000-000000001004"), "ConditionalSuccess", new DateTime(2026, 7, 17, 9, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001077"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 17, 9, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001050"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 19, 10, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 20, new Guid("50000000-0000-0000-0000-000000001010"), "Failed", new DateTime(2026, 7, 19, 10, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001079"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 19, 10, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001051"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 21, 11, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 21, new Guid("50000000-0000-0000-0000-000000001016"), "RetestRequired", new DateTime(2026, 7, 21, 11, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001081"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 21, 11, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001052"), null, new DateTime(2026, 7, 23, 12, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 22, new Guid("50000000-0000-0000-0000-000000001022"), "Success", new DateTime(2026, 7, 23, 12, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001083"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 23, 12, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001053"), null, new DateTime(2026, 7, 25, 13, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 23, new Guid("50000000-0000-0000-0000-000000001028"), "ConditionalSuccess", new DateTime(2026, 7, 25, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001085"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 25, 13, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001054"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 27, 14, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 24, new Guid("50000000-0000-0000-0000-000000001034"), "Failed", new DateTime(2026, 7, 27, 14, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001087"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 27, 14, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001055"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 29, 15, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 25, new Guid("50000000-0000-0000-0000-000000001040"), "RetestRequired", new DateTime(2026, 7, 29, 15, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001089"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 29, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001056"), null, new DateTime(2026, 7, 31, 8, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 26, new Guid("50000000-0000-0000-0000-000000001046"), "Success", new DateTime(2026, 7, 31, 8, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001091"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 31, 8, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001057"), null, new DateTime(2026, 8, 2, 9, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 27, new Guid("50000000-0000-0000-0000-000000001052"), "ConditionalSuccess", new DateTime(2026, 8, 2, 9, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001093"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 2, 9, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001058"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 8, 4, 10, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 28, new Guid("50000000-0000-0000-0000-000000001058"), "Failed", new DateTime(2026, 8, 4, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001095"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 4, 10, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001059"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 8, 6, 11, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 29, new Guid("50000000-0000-0000-0000-000000001064"), "RetestRequired", new DateTime(2026, 8, 6, 11, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001097"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 6, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001060"), null, new DateTime(2026, 8, 8, 12, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 30, new Guid("50000000-0000-0000-0000-000000001070"), "Success", new DateTime(2026, 8, 8, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001099"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 8, 12, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001061"), null, new DateTime(2026, 1, 2, 13, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 31, new Guid("50000000-0000-0000-0000-000000001076"), "ConditionalSuccess", new DateTime(2026, 1, 2, 13, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001101"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 2, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001062"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 4, 14, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 32, new Guid("50000000-0000-0000-0000-000000001082"), "Failed", new DateTime(2026, 1, 4, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001103"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 4, 14, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001063"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 6, 15, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 33, new Guid("50000000-0000-0000-0000-000000001088"), "RetestRequired", new DateTime(2026, 1, 6, 15, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001105"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 6, 15, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001064"), null, new DateTime(2026, 1, 8, 8, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 34, new Guid("50000000-0000-0000-0000-000000001094"), "Success", new DateTime(2026, 1, 8, 8, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001107"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 8, 8, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001065"), null, new DateTime(2026, 1, 10, 9, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 35, new Guid("50000000-0000-0000-0000-000000001100"), "ConditionalSuccess", new DateTime(2026, 1, 10, 9, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001109"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 10, 9, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001066"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 12, 10, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 36, new Guid("50000000-0000-0000-0000-000000001106"), "Failed", new DateTime(2026, 1, 12, 10, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001111"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 12, 10, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001067"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 14, 11, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 37, new Guid("50000000-0000-0000-0000-000000001112"), "RetestRequired", new DateTime(2026, 1, 14, 11, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001113"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 14, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001068"), null, new DateTime(2026, 1, 16, 12, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 38, new Guid("50000000-0000-0000-0000-000000001118"), "Success", new DateTime(2026, 1, 16, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001115"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 16, 12, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001070"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 1, 20, 14, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 40, new Guid("50000000-0000-0000-0000-000000001006"), "Failed", new DateTime(2026, 1, 20, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001119"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 20, 14, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001074"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 2, 10, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 44, new Guid("50000000-0000-0000-0000-000000001024"), "Failed", new DateTime(2026, 5, 2, 10, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001001"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 2, 10, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001075"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 4, 11, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 45, new Guid("50000000-0000-0000-0000-000000001030"), "RetestRequired", new DateTime(2026, 5, 4, 11, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001003"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 4, 11, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001076"), null, new DateTime(2026, 5, 6, 12, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 46, new Guid("50000000-0000-0000-0000-000000001036"), "Success", new DateTime(2026, 5, 6, 12, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001005"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 6, 12, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001077"), null, new DateTime(2026, 5, 8, 13, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 47, new Guid("50000000-0000-0000-0000-000000001042"), "ConditionalSuccess", new DateTime(2026, 5, 8, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001007"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 8, 13, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001078"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 10, 14, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 48, new Guid("50000000-0000-0000-0000-000000001048"), "Failed", new DateTime(2026, 5, 10, 14, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001009"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 10, 14, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001079"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 12, 15, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 49, new Guid("50000000-0000-0000-0000-000000001054"), "RetestRequired", new DateTime(2026, 5, 12, 15, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001011"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 12, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001080"), null, new DateTime(2026, 5, 14, 8, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 50, new Guid("50000000-0000-0000-0000-000000001060"), "Success", new DateTime(2026, 5, 14, 8, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001013"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 14, 8, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001081"), null, new DateTime(2026, 5, 16, 9, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 51, new Guid("50000000-0000-0000-0000-000000001066"), "ConditionalSuccess", new DateTime(2026, 5, 16, 9, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001015"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 16, 9, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001082"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 18, 10, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 52, new Guid("50000000-0000-0000-0000-000000001072"), "Failed", new DateTime(2026, 5, 18, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001017"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 18, 10, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001083"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 20, 11, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 53, new Guid("50000000-0000-0000-0000-000000001078"), "RetestRequired", new DateTime(2026, 5, 20, 11, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001019"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 20, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001084"), null, new DateTime(2026, 5, 22, 12, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 54, new Guid("50000000-0000-0000-0000-000000001084"), "Success", new DateTime(2026, 5, 22, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001021"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 22, 12, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001085"), null, new DateTime(2026, 5, 24, 13, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 55, new Guid("50000000-0000-0000-0000-000000001090"), "ConditionalSuccess", new DateTime(2026, 5, 24, 13, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001023"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 24, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001086"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 26, 14, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 56, new Guid("50000000-0000-0000-0000-000000001096"), "Failed", new DateTime(2026, 5, 26, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001025"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 26, 14, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001087"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 5, 28, 15, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 57, new Guid("50000000-0000-0000-0000-000000001102"), "RetestRequired", new DateTime(2026, 5, 28, 15, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001027"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 28, 15, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001088"), null, new DateTime(2026, 5, 30, 8, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 58, new Guid("50000000-0000-0000-0000-000000001108"), "Success", new DateTime(2026, 5, 30, 8, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001029"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 5, 30, 8, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001089"), null, new DateTime(2026, 6, 1, 9, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 59, new Guid("50000000-0000-0000-0000-000000001114"), "ConditionalSuccess", new DateTime(2026, 6, 1, 9, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001031"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 1, 9, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001090"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 3, 10, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 60, new Guid("50000000-0000-0000-0000-000000001120"), "Failed", new DateTime(2026, 6, 3, 10, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001033"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 3, 10, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001091"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 5, 11, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 61, new Guid("50000000-0000-0000-0000-000000001002"), "RetestRequired", new DateTime(2026, 6, 5, 11, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001035"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 5, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001092"), null, new DateTime(2026, 6, 7, 12, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 62, new Guid("50000000-0000-0000-0000-000000001008"), "Success", new DateTime(2026, 6, 7, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001037"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 7, 12, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001093"), null, new DateTime(2026, 6, 9, 13, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 63, new Guid("50000000-0000-0000-0000-000000001014"), "ConditionalSuccess", new DateTime(2026, 6, 9, 13, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001039"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 9, 13, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001094"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 11, 14, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 64, new Guid("50000000-0000-0000-0000-000000001020"), "Failed", new DateTime(2026, 6, 11, 14, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001041"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 11, 14, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001095"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 13, 15, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 65, new Guid("50000000-0000-0000-0000-000000001026"), "RetestRequired", new DateTime(2026, 6, 13, 15, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001043"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 13, 15, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001096"), null, new DateTime(2026, 6, 15, 8, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 66, new Guid("50000000-0000-0000-0000-000000001032"), "Success", new DateTime(2026, 6, 15, 8, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001045"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 15, 8, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001097"), null, new DateTime(2026, 6, 17, 9, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 67, new Guid("50000000-0000-0000-0000-000000001038"), "ConditionalSuccess", new DateTime(2026, 6, 17, 9, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001047"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 17, 9, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001098"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 19, 10, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 68, new Guid("50000000-0000-0000-0000-000000001044"), "Failed", new DateTime(2026, 6, 19, 10, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001049"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 19, 10, 35, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001099"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 21, 11, 35, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 69, new Guid("50000000-0000-0000-0000-000000001050"), "RetestRequired", new DateTime(2026, 6, 21, 11, 35, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001051"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 21, 11, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001100"), null, new DateTime(2026, 6, 23, 12, 40, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 70, new Guid("50000000-0000-0000-0000-000000001056"), "Success", new DateTime(2026, 6, 23, 12, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001053"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 23, 12, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001101"), null, new DateTime(2026, 6, 25, 13, 45, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 71, new Guid("50000000-0000-0000-0000-000000001062"), "ConditionalSuccess", new DateTime(2026, 6, 25, 13, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001055"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 25, 13, 50, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001102"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 27, 14, 50, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 72, new Guid("50000000-0000-0000-0000-000000001068"), "Failed", new DateTime(2026, 6, 27, 14, 50, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001057"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 27, 14, 55, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001103"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 6, 29, 15, 55, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 73, new Guid("50000000-0000-0000-0000-000000001074"), "RetestRequired", new DateTime(2026, 6, 29, 15, 55, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001059"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 6, 29, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001104"), null, new DateTime(2026, 7, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 74, new Guid("50000000-0000-0000-0000-000000001080"), "Success", new DateTime(2026, 7, 1, 8, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001061"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 1, 8, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001105"), null, new DateTime(2026, 7, 3, 9, 5, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 75, new Guid("50000000-0000-0000-0000-000000001086"), "ConditionalSuccess", new DateTime(2026, 7, 3, 9, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001063"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 3, 9, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001106"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 5, 10, 10, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 76, new Guid("50000000-0000-0000-0000-000000001092"), "Failed", new DateTime(2026, 7, 5, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001065"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 5, 10, 15, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001107"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 7, 11, 15, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 77, new Guid("50000000-0000-0000-0000-000000001098"), "RetestRequired", new DateTime(2026, 7, 7, 11, 15, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001067"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 7, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001108"), null, new DateTime(2026, 7, 9, 12, 20, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 78, new Guid("50000000-0000-0000-0000-000000001104"), "Success", new DateTime(2026, 7, 9, 12, 20, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001069"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 9, 12, 25, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001109"), null, new DateTime(2026, 7, 11, 13, 25, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 79, new Guid("50000000-0000-0000-0000-000000001110"), "ConditionalSuccess", new DateTime(2026, 7, 11, 13, 25, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001071"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 11, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("73000000-0000-0000-0000-000000001110"), "Sentetik testte limit dışı değer veya tekrar test ihtiyacı görüldü.", new DateTime(2026, 7, 13, 14, 30, 0, 0, DateTimeKind.Utc), "Sentetik test kaydı: ölçüm değerleri ve test sonucu raporlandı.", 80, new Guid("50000000-0000-0000-0000-000000001116"), "Failed", new DateTime(2026, 7, 13, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000001073"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 13, 14, 35, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001111"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001112"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001113"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001114"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001115"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001116"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001117"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001118"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001119"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001120"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001121"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001122"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001123"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001124"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001125"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001126"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001127"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001128"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001129"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001130"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001131"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001132"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001133"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001134"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001135"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001136"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001137"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001138"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001139"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001140"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001141"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001142"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001143"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001144"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001145"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001146"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001147"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001148"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001149"));

            migrationBuilder.DeleteData(
                table: "FaultActions",
                keyColumn: "Id",
                keyValue: new Guid("61000000-0000-0000-0000-000000001150"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001112"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001114"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001116"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001128"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001130"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001132"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001134"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001136"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001138"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001140"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001142"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001144"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001146"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001115"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001120"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001125"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001130"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("81000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001111"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001112"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001113"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001114"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001115"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001116"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001117"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001118"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001119"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001120"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001121"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001122"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001123"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001124"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001125"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001126"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001127"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001128"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001129"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001130"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001131"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001132"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001133"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001134"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001135"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001136"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001137"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001138"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001139"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001140"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001141"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001142"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001143"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001144"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001145"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001146"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001147"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001148"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001149"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001150"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001151"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001152"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001153"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001154"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001155"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001156"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001157"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001158"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001159"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001160"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001161"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001162"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001163"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001164"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001165"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001166"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001167"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001168"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001169"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001170"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001171"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001172"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001173"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001174"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001175"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001176"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001177"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001178"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001179"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001180"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001181"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001182"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001183"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001184"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001185"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001186"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001187"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001188"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001189"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001190"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001191"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001192"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001193"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001194"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001195"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001196"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001197"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001198"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001199"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001200"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001201"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001202"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001203"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001204"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001205"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001206"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001207"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001208"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001209"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001210"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001211"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001212"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001213"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001214"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001215"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001216"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001217"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001218"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001219"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000001220"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001112"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001114"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001116"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001118"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001120"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001113"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001111"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001113"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001115"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001117"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001118"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001119"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001120"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001121"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001122"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001123"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001124"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001125"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001126"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001127"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001129"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001131"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001133"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001135"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001137"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001139"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001141"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001143"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001145"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001147"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001148"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001149"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000001150"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001111"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001112"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001113"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001114"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001116"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001117"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001118"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001119"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001121"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001122"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001123"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001124"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001126"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001127"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001128"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000001129"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001013"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001017"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001041"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001065"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001111"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001113"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001115"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001117"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000001119"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001001"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001002"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001003"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001004"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001005"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001006"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001007"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001008"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001009"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001010"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001011"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001012"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001014"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001015"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001016"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001018"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001019"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001020"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001021"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001022"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001023"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001024"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001025"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001026"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001027"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001028"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001029"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001030"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001031"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001032"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001033"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001034"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001035"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001036"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001037"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001038"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001039"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001040"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001042"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001043"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001044"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001045"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001046"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001047"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001048"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001049"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001050"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001051"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001052"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001053"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001054"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001055"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001056"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001057"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001058"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001059"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001060"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001061"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001062"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001063"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001064"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001066"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001067"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001068"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001069"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001070"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001071"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001072"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001073"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001074"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001075"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001076"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001077"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001078"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001100"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001101"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001102"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001103"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001104"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001105"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001106"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001107"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001108"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001109"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001110"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001111"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001112"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001114"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001115"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001116"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001117"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001118"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001119"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000001120"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "pbkdf2-sha256$100000$dGVjaG9wcy1tYW5hZ2VyMQ==$2JU5bt9x2uS/3kp8oY1vE/qobOLfoTy1SkB90ybtopU=");
        }
    }
}
