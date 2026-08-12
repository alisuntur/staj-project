using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftHandoverManagementSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "AssignedAt", "AssignedToUserId", "ClosedAt", "ClosedByUserId", "CreatedAt", "CreatedByUserId", "Description", "EquipmentId", "FaultNo", "LocationId", "Priority", "ResolutionDescription", "ResolvedAt", "ResolvedByUserId", "Source", "Status", "TechnicalSystemId", "UpdatedAt", "WaitingReason" },
                values: new object[,]
                {
                    { new Guid("60000000-0000-0000-0000-000000000010"), new DateTime(2026, 8, 12, 7, 30, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 12, 7, 10, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000001"), "UPS bypass hattında kısa süreli alarm gözlendi. Yük transferi ve alarm eşiği takip edilecek.", new Guid("50000000-0000-0000-0000-000000000002"), "ARZ-2026-010", new Guid("20000000-0000-0000-0000-000000000003"), "Critical", null, null, null, "ScadaObservation", "InProgress", new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 12, 7, 30, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60000000-0000-0000-0000-000000000011"), new DateTime(2026, 8, 12, 9, 15, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000003"), null, null, new DateTime(2026, 8, 12, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("40000000-0000-0000-0000-000000000004"), "AHU-T1-04 besleme havası sıcaklığı hedef aralığa düşmüyor. Filtre ve sensör kontrolleri takip edilecek.", new Guid("50000000-0000-0000-0000-000000000003"), "ARZ-2026-011", new Guid("20000000-0000-0000-0000-000000000001"), "High", null, null, null, "FieldObservation", "Assigned", new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 12, 9, 15, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "ShiftHandovers",
                columns: new[] { "Id", "CreatedAt", "CriticalNotes", "HandoverFromUserId", "HandoverNo", "HandoverToUserId", "ShiftDate", "ShiftType", "Summary", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("74000000-0000-0000-0000-000000000001"), new DateTime(2026, 8, 12, 8, 0, 0, 0, DateTimeKind.Utc), "Enerji merkezi UPS alarm eşiği ve yük transfer davranışı yakından izlenecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-001", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2026, 8, 12), "Morning", "Gece vardiyasından devralınan UPS alarmı ve bekleyen bakım faaliyetleri sabah vardiyasına aktarıldı.", null },
                    { new Guid("74000000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 12, 16, 0, 0, 0, DateTimeKind.Utc), "Terminal 1 HVAC sıcaklık takibi operasyon saatleri boyunca sürdürülecek.", new Guid("40000000-0000-0000-0000-000000000002"), "VDT-2026-002", new Guid("40000000-0000-0000-0000-000000000003"), new DateOnly(2026, 8, 12), "Evening", "Sabah vardiyasındaki açık arıza ve saha takip maddeleri akşam vardiyasına devredildi.", null },
                    { new Guid("74000000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 12, 23, 45, 0, 0, DateTimeKind.Utc), "Enerji merkezi çalışma izni ve PLC panel alarm listesi gece vardiyasında tekrar kontrol edilecek.", new Guid("40000000-0000-0000-0000-000000000003"), "VDT-2026-003", new Guid("40000000-0000-0000-0000-000000000002"), new DateOnly(2026, 8, 12), "Night", "Akşam vardiyasından gece vardiyasına takip edilecek cihazlar ve kritik saha notları aktarıldı.", null }
                });

            migrationBuilder.InsertData(
                table: "ShiftItems",
                columns: new[] { "Id", "CreatedAt", "Description", "EquipmentId", "FaultId", "IsCompleted", "ItemType", "MaintenancePlanId", "Priority", "ShiftHandoverId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("74100000-0000-0000-0000-000000000001"), new DateTime(2026, 8, 12, 8, 0, 0, 0, DateTimeKind.Utc), "UPS bypass alarmının tekrarlayıp tekrarlamadığı SCADA üzerinden izlenecek.", new Guid("50000000-0000-0000-0000-000000000002"), new Guid("60000000-0000-0000-0000-000000000010"), false, "OpenFault", null, "Critical", new Guid("74000000-0000-0000-0000-000000000001"), "ARZ-2026-010 - UPS bypass alarmı takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000000002"), new DateTime(2026, 8, 12, 8, 2, 0, 0, DateTimeKind.Utc), "UPS batarya bloğu ve bypass hattı bakım planı teknik yönetici onayıyla takip edilecek.", new Guid("50000000-0000-0000-0000-000000000002"), null, false, "PendingMaintenance", new Guid("70000000-0000-0000-0000-000000000003"), "Critical", new Guid("74000000-0000-0000-0000-000000000001"), "BKM-2026-003 - UPS yıllık bakım takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000000003"), new DateTime(2026, 8, 12, 8, 4, 0, 0, DateTimeKind.Utc), "Yük transfer testi veya bypass işlemi öncesinde operasyon merkezi bilgilendirilecek.", null, null, false, "CriticalNote", null, "High", new Guid("74000000-0000-0000-0000-000000000001"), "Enerji merkezi yük transferi sırasında haber verilecek", null },
                    { new Guid("74100000-0000-0000-0000-000000000004"), new DateTime(2026, 8, 12, 16, 0, 0, 0, DateTimeKind.Utc), "Terminal 1 AHU besleme sıcaklığı ve sensör okumaları akşam vardiyasında kontrol edilecek.", new Guid("50000000-0000-0000-0000-000000000003"), new Guid("60000000-0000-0000-0000-000000000011"), false, "OpenFault", null, "High", new Guid("74000000-0000-0000-0000-000000000002"), "ARZ-2026-011 - AHU sıcaklık takibi", null },
                    { new Guid("74100000-0000-0000-0000-000000000005"), new DateTime(2026, 8, 12, 16, 3, 0, 0, DateTimeKind.Utc), "Haftalık test sonrası jeneratör çalışma sesi ve yağ basıncı değerleri vardiya boyunca izlenecek.", new Guid("50000000-0000-0000-0000-000000000001"), null, false, "EquipmentToWatch", null, "Medium", new Guid("74000000-0000-0000-0000-000000000002"), "EQ-00032 - Jeneratör çalışma sesi izlenecek", null },
                    { new Guid("74100000-0000-0000-0000-000000000006"), new DateTime(2026, 8, 12, 16, 5, 0, 0, DateTimeKind.Utc), "Saha turunda jeneratör yakıt seviyesi ve sızıntı kontrolü yapılacak.", new Guid("50000000-0000-0000-0000-000000000001"), null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000000002"), "Jeneratör yakıt seviyesi manuel kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000000007"), new DateTime(2026, 8, 12, 23, 45, 0, 0, DateTimeKind.Utc), "PLC panel haberleşme alarmları gece vardiyasında kontrol edildi.", new Guid("50000000-0000-0000-0000-000000000004"), null, true, "EquipmentToWatch", null, "Low", new Guid("74000000-0000-0000-0000-000000000003"), "EQ-00067 - PLC panel haberleşme durumu", new DateTime(2026, 8, 12, 23, 58, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74100000-0000-0000-0000-000000000008"), new DateTime(2026, 8, 12, 23, 47, 0, 0, DateTimeKind.Utc), "Saat başı SCADA aktif alarm listesi kontrol edilip kritik alarmlar not alınacak.", null, null, false, "OngoingWork", null, "Medium", new Guid("74000000-0000-0000-0000-000000000003"), "SCADA alarm listesi nöbet kontrolü", null },
                    { new Guid("74100000-0000-0000-0000-000000000009"), new DateTime(2026, 8, 12, 23, 49, 0, 0, DateTimeKind.Utc), "Gece vardiyasında enerji merkezi girişinde plan dışı çalışma olup olmadığı kontrol edilecek.", null, null, false, "CriticalNote", null, "Critical", new Guid("74000000-0000-0000-0000-000000000003"), "Enerji merkezi girişinde çalışma izni kontrolü", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000003"));
        }
    }
}
