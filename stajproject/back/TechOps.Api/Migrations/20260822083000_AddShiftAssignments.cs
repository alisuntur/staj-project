using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ShiftDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_CreatedByUserId",
                table: "ShiftAssignments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_ShiftDate",
                table: "ShiftAssignments",
                column: "ShiftDate");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_ShiftType",
                table: "ShiftAssignments",
                column: "ShiftType");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_UserId_ShiftDate",
                table: "ShiftAssignments",
                columns: new[] { "UserId", "ShiftDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftAssignments");
        }
    }
}
