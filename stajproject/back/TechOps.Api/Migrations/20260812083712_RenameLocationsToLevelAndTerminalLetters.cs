using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameLocationsToLevelAndTerminalLetters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000002"),
                column: "Name",
                value: "UPS-LM-02");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"),
                column: "Name",
                value: "Terminal A");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                column: "Name",
                value: "Terminal B");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"),
                column: "Name",
                value: "Level Merkez");

            migrationBuilder.UpdateData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000001"),
                column: "CriticalNotes",
                value: "Level Merkez UPS alarm eşiği ve yük transfer davranışı yakından izlenecek.");

            migrationBuilder.UpdateData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000002"),
                column: "CriticalNotes",
                value: "Terminal A HVAC sıcaklık takibi operasyon saatleri boyunca sürdürülecek.");

            migrationBuilder.UpdateData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000003"),
                column: "CriticalNotes",
                value: "Level Merkez çalışma izni ve PLC panel alarm listesi gece vardiyasında tekrar kontrol edilecek.");

            migrationBuilder.UpdateData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000003"),
                column: "Title",
                value: "Level Merkez yük transferi sırasında haber verilecek");

            migrationBuilder.UpdateData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000004"),
                column: "Description",
                value: "Terminal A AHU besleme sıcaklığı ve sensör okumaları akşam vardiyasında kontrol edilecek.");

            migrationBuilder.UpdateData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000009"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Gece vardiyasında Level Merkez girişinde plan dışı çalışma olup olmadığı kontrol edilecek.", "Level Merkez girişinde çalışma izni kontrolü" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000002"),
                column: "Name",
                value: "UPS-EM-02");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"),
                column: "Name",
                value: "Terminal 1");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                column: "Name",
                value: "Terminal 2");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"),
                column: "Name",
                value: "Enerji Merkezi");

            migrationBuilder.UpdateData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000001"),
                column: "CriticalNotes",
                value: "Enerji merkezi UPS alarm eşiği ve yük transfer davranışı yakından izlenecek.");

            migrationBuilder.UpdateData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000002"),
                column: "CriticalNotes",
                value: "Terminal 1 HVAC sıcaklık takibi operasyon saatleri boyunca sürdürülecek.");

            migrationBuilder.UpdateData(
                table: "ShiftHandovers",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000003"),
                column: "CriticalNotes",
                value: "Enerji merkezi çalışma izni ve PLC panel alarm listesi gece vardiyasında tekrar kontrol edilecek.");

            migrationBuilder.UpdateData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000003"),
                column: "Title",
                value: "Enerji merkezi yük transferi sırasında haber verilecek");

            migrationBuilder.UpdateData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000004"),
                column: "Description",
                value: "Terminal 1 AHU besleme sıcaklığı ve sensör okumaları akşam vardiyasında kontrol edilecek.");

            migrationBuilder.UpdateData(
                table: "ShiftItems",
                keyColumn: "Id",
                keyValue: new Guid("74100000-0000-0000-0000-000000000009"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Gece vardiyasında enerji merkezi girişinde plan dışı çalışma olup olmadığı kontrol edilecek.", "Enerji merkezi girişinde çalışma izni kontrolü" });
        }
    }
}
