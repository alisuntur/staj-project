using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShiftRoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "IsSystemRole", "Name", "UpdatedAt" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Devir teslim süreçlerini yönetir", true, "Vardiya Personeli", null });
        }
    }
}
