using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceManagementFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChecklistJson",
                table: "MaintenanceRecords",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "MaintenancePlans",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "MaintenancePlans",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MaintenancePlans",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "CreatedByUserId", "Description", "EquipmentId", "Frequency", "MaintenanceType", "PlanNo", "PlannedDate", "Priority", "ResponsibleUserId", "StartedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("70000000-0000-0000-0000-000000000001"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Jeneratör yakıt, yağ, filtre ve otomatik transfer panosu kontrolleri yapılacak.", new Guid("50000000-0000-0000-0000-000000000001"), "6 Aylık", "6 Aylık", "BKM-2026-001", new DateOnly(2026, 8, 20), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000000002"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "HVAC ünitesi filtre, kayış, drenaj hattı ve sıcaklık sensörü kontrolleri yapılacak.", new Guid("50000000-0000-0000-0000-000000000003"), "Aylık", "Aylık", "BKM-2026-002", new DateOnly(2026, 8, 11), "High", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 11, 8, 30, 0, 0, DateTimeKind.Utc), "Started", new DateTime(2026, 8, 11, 8, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000000003"), null, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "UPS batarya bloğu, bypass hattı ve yük aktarım testi planlandı.", new Guid("50000000-0000-0000-0000-000000000002"), "Yıllık", "Yıllık", "BKM-2026-003", new DateOnly(2026, 8, 5), "Critical", new Guid("40000000-0000-0000-0000-000000000002"), null, "Planned", null },
                    { new Guid("70000000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 1, 11, 20, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "PLC panel klemens, güç kaynağı ve haberleşme modülü bakımı tamamlandı.", new Guid("50000000-0000-0000-0000-000000000004"), "3 Aylık", "3 Aylık", "BKM-2026-004", new DateOnly(2026, 8, 1), "Medium", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 8, 1, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000000-0000-0000-0000-000000000005"), new DateTime(2026, 7, 28, 8, 25, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "Haftalık jeneratör saha kontrolü tamamlandı.", new Guid("50000000-0000-0000-0000-000000000001"), "Haftalık", "Haftalık", "BKM-2026-005", new DateOnly(2026, 7, 28), "Low", new Guid("40000000-0000-0000-0000-000000000003"), new DateTime(2026, 7, 28, 7, 45, 0, 0, DateTimeKind.Utc), "Completed", new DateTime(2026, 7, 28, 8, 25, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "ChecklistJson", "CompletedAt", "CreatedAt", "Description", "EquipmentId", "MaintenancePlanId", "MaintenanceType", "PerformedByUserId", "ResultStatus", "StartedAt", "UpdatedAt", "UsedMaterials" },
                values: new object[,]
                {
                    { new Guid("71000000-0000-0000-0000-000000000001"), "[{\"Text\":\"Fiziksel hasar kontrolü yapıldı.\",\"IsChecked\":true},{\"Text\":\"Bağlantı klemensleri sıkıldı.\",\"IsChecked\":true},{\"Text\":\"Haberleşme testi yapıldı.\",\"IsChecked\":true}]", new DateTime(2026, 8, 1, 11, 20, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 1, 11, 20, 0, 0, DateTimeKind.Utc), "PLC panel içi temizlik, klemens sıkılık kontrolü ve yedek güç kaynağı testi tamamlandı.", new Guid("50000000-0000-0000-0000-000000000004"), new Guid("70000000-0000-0000-0000-000000000004"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Utc), null, "Klemens etiketi, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000000002"), "[{\"Text\":\"Yağ ve yakıt seviyesi kontrol edildi.\",\"IsChecked\":true},{\"Text\":\"Sızıntı kontrolü yapıldı.\",\"IsChecked\":true},{\"Text\":\"Test çalıştırması tamamlandı.\",\"IsChecked\":true}]", new DateTime(2026, 7, 28, 8, 25, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 28, 8, 25, 0, 0, DateTimeKind.Utc), "Jeneratör çalışma testi, sıvı seviye kontrolleri ve görsel saha kontrolü tamamlandı.", new Guid("50000000-0000-0000-0000-000000000001"), new Guid("70000000-0000-0000-0000-000000000005"), "Haftalık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 7, 28, 7, 45, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_CompletedAt",
                table: "MaintenancePlans",
                column: "CompletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_StartedAt",
                table: "MaintenancePlans",
                column: "StartedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaintenancePlans_CompletedAt",
                table: "MaintenancePlans");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancePlans_StartedAt",
                table: "MaintenancePlans");

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "MaintenancePlans",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000005"));

            migrationBuilder.DropColumn(
                name: "ChecklistJson",
                table: "MaintenanceRecords");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "MaintenancePlans");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "MaintenancePlans");
        }
    }
}
