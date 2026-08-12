using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodicTestManagementSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "Frequency", "PlannedDate", "ResponsibleUserId", "Status", "TestType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("72000000-0000-0000-0000-000000000001"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Jeneratör otomatik çalışma ve transfer senaryosu doğrulaması.", new Guid("50000000-0000-0000-0000-000000000001"), "Haftalık", new DateOnly(2026, 8, 3), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "Haftalık Jeneratör Testi", new DateTime(2026, 8, 3, 8, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "UPS bypass ve yük transfer testi.", new Guid("50000000-0000-0000-0000-000000000002"), "Aylık", new DateOnly(2026, 8, 4), new Guid("40000000-0000-0000-0000-000000000002"), "Completed", "UPS Yük Transfer Testi", new DateTime(2026, 8, 4, 10, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "AHU çalışma, sıcaklık ve drenaj testleri.", new Guid("50000000-0000-0000-0000-000000000003"), "Aylık", new DateOnly(2026, 8, 6), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "HVAC Çalışma Testi", new DateTime(2026, 8, 6, 14, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "PLC panel giriş/çıkış sinyal doğrulaması.", new Guid("50000000-0000-0000-0000-000000000004"), "3 Aylık", new DateOnly(2026, 8, 7), new Guid("40000000-0000-0000-0000-000000000003"), "Completed", "PLC I/O Testi", new DateTime(2026, 8, 7, 11, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000000005"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Acil durum yük devreye alma senaryosu.", new Guid("50000000-0000-0000-0000-000000000001"), "Tek Seferlik", new DateOnly(2026, 8, 9), new Guid("40000000-0000-0000-0000-000000000002"), "Completed", "Acil Durum Senaryo Testi", new DateTime(2026, 8, 9, 9, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("72000000-0000-0000-0000-000000000006"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "UPS batarya otonomi süresi ve alarm eşikleri test edilecek.", new Guid("50000000-0000-0000-0000-000000000002"), "6 Aylık", new DateOnly(2026, 8, 18), new Guid("40000000-0000-0000-0000-000000000003"), "Planned", "UPS Batarya Otonomi Testi", null }
                });

            migrationBuilder.InsertData(
                table: "TestRecords",
                columns: new[] { "Id", "AbnormalCondition", "CreatedAt", "Description", "DurationMinutes", "EquipmentId", "Result", "TestDate", "TestPlanId", "TestType", "TestedByUserId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("73000000-0000-0000-0000-000000000001"), null, new DateTime(2026, 8, 3, 8, 30, 0, 0, DateTimeKind.Utc), "Jeneratör otomatik olarak devreye girdi, gerilim ve frekans değerleri normal aralıkta izlendi.", 35, new Guid("50000000-0000-0000-0000-000000000001"), "Success", new DateTime(2026, 8, 3, 8, 30, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), "Haftalık Jeneratör Testi", new Guid("40000000-0000-0000-0000-000000000003"), null },
                    { new Guid("73000000-0000-0000-0000-000000000002"), "Transfer sonrası kısa süreli bypass alarmı izlendi.", new DateTime(2026, 8, 4, 10, 10, 0, 0, DateTimeKind.Utc), "Yük transferi tamamlandı ancak alarm eşiği bakımda yeniden değerlendirilecek.", 25, new Guid("50000000-0000-0000-0000-000000000002"), "ConditionalSuccess", new DateTime(2026, 8, 4, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000002"), "UPS Yük Transfer Testi", new Guid("40000000-0000-0000-0000-000000000002"), null },
                    { new Guid("73000000-0000-0000-0000-000000000003"), "Besleme havası sıcaklığı hedef aralığa düşmedi.", new DateTime(2026, 8, 6, 14, 5, 0, 0, DateTimeKind.Utc), "AHU soğutma performansı yetersiz. Bakım planı ile filtre ve sensör kontrolleri takip edilecek.", 40, new Guid("50000000-0000-0000-0000-000000000003"), "Failed", new DateTime(2026, 8, 6, 14, 5, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), "HVAC Çalışma Testi", new Guid("40000000-0000-0000-0000-000000000003"), null },
                    { new Guid("73000000-0000-0000-0000-000000000004"), null, new DateTime(2026, 8, 7, 11, 40, 0, 0, DateTimeKind.Utc), "Tüm dijital giriş/çıkış noktaları SCADA üzerinden doğrulandı.", 55, new Guid("50000000-0000-0000-0000-000000000004"), "Success", new DateTime(2026, 8, 7, 11, 40, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000004"), "PLC I/O Testi", new Guid("40000000-0000-0000-0000-000000000003"), null },
                    { new Guid("73000000-0000-0000-0000-000000000005"), "Yük alma süresi kabul kriterine çok yakın ölçüldü.", new DateTime(2026, 8, 9, 9, 45, 0, 0, DateTimeKind.Utc), "Değer sınırda olduğu için tekrar test planlanacak.", 30, new Guid("50000000-0000-0000-0000-000000000001"), "RetestRequired", new DateTime(2026, 8, 9, 9, 45, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000005"), "Acil Durum Senaryo Testi", new Guid("40000000-0000-0000-0000-000000000002"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "TestRecords",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "TestPlans",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000005"));
        }
    }
}
