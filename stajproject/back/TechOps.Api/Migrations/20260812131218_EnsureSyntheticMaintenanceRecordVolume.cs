using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class EnsureSyntheticMaintenanceRecordVolume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "ChecklistJson", "CompletedAt", "CreatedAt", "Description", "EquipmentId", "MaintenancePlanId", "MaintenanceType", "PerformedByUserId", "ResultStatus", "StartedAt", "UpdatedAt", "UsedMaterials" },
                values: new object[,]
                {
                    { new Guid("71000000-0000-0000-0000-000000001079"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 3, 31, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 31, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001047"), new Guid("70000000-0000-0000-0000-000000001002"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 3, 31, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001080"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 1, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 1, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001052"), new Guid("70000000-0000-0000-0000-000000001003"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 1, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001081"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 2, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 2, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001057"), new Guid("70000000-0000-0000-0000-000000001004"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 2, 10, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001082"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 5, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 5, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001072"), new Guid("70000000-0000-0000-0000-000000001007"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 5, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001083"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 6, 12, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 6, 12, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001077"), new Guid("70000000-0000-0000-0000-000000001008"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 6, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001084"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 7, 14, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 7, 14, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001082"), new Guid("70000000-0000-0000-0000-000000001009"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 7, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001085"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 10, 15, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 10, 15, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001097"), new Guid("70000000-0000-0000-0000-000000001012"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 4, 10, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001086"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 11, 17, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 11, 17, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001102"), new Guid("70000000-0000-0000-0000-000000001013"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 11, 13, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001087"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 12, 13, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 12, 13, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001107"), new Guid("70000000-0000-0000-0000-000000001014"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 12, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001088"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 15, 14, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 15, 14, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000000002"), new Guid("70000000-0000-0000-0000-000000001017"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 15, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001089"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 16, 16, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 16, 16, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001003"), new Guid("70000000-0000-0000-0000-000000001018"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 16, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001090"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 17, 18, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 17, 18, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001008"), new Guid("70000000-0000-0000-0000-000000001019"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 17, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001091"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 20, 13, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 20, 13, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001023"), new Guid("70000000-0000-0000-0000-000000001022"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 20, 10, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001092"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 21, 15, 9, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 21, 15, 9, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001028"), new Guid("70000000-0000-0000-0000-000000001023"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 21, 11, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001093"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 22, 17, 12, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 22, 17, 12, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001033"), new Guid("70000000-0000-0000-0000-000000001024"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 22, 12, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001094"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 25, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 25, 12, 21, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001048"), new Guid("70000000-0000-0000-0000-000000001027"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 25, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001095"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 26, 14, 24, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 26, 14, 24, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001053"), new Guid("70000000-0000-0000-0000-000000001028"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 26, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001096"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 27, 16, 27, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 27, 16, 27, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001058"), new Guid("70000000-0000-0000-0000-000000001029"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 27, 11, 0, 0, 0, DateTimeKind.Utc), null, "Filtre, etiket, temizlik spreyi" },
                    { new Guid("71000000-0000-0000-0000-000000001097"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 4, 30, 11, 36, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 30, 11, 36, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001073"), new Guid("70000000-0000-0000-0000-000000001032"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 4, 30, 8, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001098"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 1, 13, 39, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 1, 13, 39, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001078"), new Guid("70000000-0000-0000-0000-000000001033"), "6 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 1, 9, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001099"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 2, 15, 42, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 2, 15, 42, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001083"), new Guid("70000000-0000-0000-0000-000000001034"), "Yıllık", new Guid("40000000-0000-0000-0000-000000000003"), "PartiallyCompleted", new DateTime(2026, 5, 2, 10, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" },
                    { new Guid("71000000-0000-0000-0000-000000001100"), "[{\"Text\":\"Fiziksel kontrol yapıldı.\",\"IsChecked\":true},{\"Text\":\"Fonksiyon testi yapıldı.\",\"IsChecked\":true},{\"Text\":\"Kayıtlar güncellendi.\",\"IsChecked\":true}]", new DateTime(2026, 5, 5, 16, 6, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 5, 16, 6, 0, 0, DateTimeKind.Utc), "Sentetik bakım kaydı: planlı bakım adımları tamamlandı ve operasyon değerleri kayıt altına alındı.", new Guid("50000000-0000-0000-0000-000000001098"), new Guid("70000000-0000-0000-0000-000000001037"), "3 Aylık", new Guid("40000000-0000-0000-0000-000000000003"), "Completed", new DateTime(2026, 5, 5, 13, 0, 0, 0, DateTimeKind.Utc), null, "Kontrol formu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001079"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001080"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001081"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001082"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001083"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001084"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001085"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001086"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001087"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001088"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001089"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001090"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001091"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001092"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001093"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001094"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001095"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001096"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001097"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001098"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001099"));

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000001100"));
        }
    }
}
