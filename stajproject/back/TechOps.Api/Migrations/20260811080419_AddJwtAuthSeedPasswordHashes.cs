using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddJwtAuthSeedPasswordHashes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "pbkdf2-sha256$100000$dGVjaG9wcy1hZG1pbi0wMQ==$4bPH94C+/0I4E/NcauyxiZTaIRbc+p919s+gnQiXw4I=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "pbkdf2-sha256$100000$dGVjaG9wcy1tYW5hZ2VyMQ==$2JU5bt9x2uS/3kp8oY1vE/qobOLfoTy1SkB90ybtopU=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "pbkdf2-sha256$100000$dGVjaG9wcy10ZWNoLTAwMQ==$sf498N38LrE5MyaWcpBXOto0kRMQNFh+bvhz0I6fpSQ=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "pbkdf2-sha256$100000$dGVjaG9wcy1vcGVyLTAwMQ==$f3lnNMIH5Qx0gyXdU4xxnWGdeU3DhcO+MKX/Xooisp0=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "demo-hash");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "PasswordHash",
                value: "demo-hash");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "PasswordHash",
                value: "demo-hash");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "PasswordHash",
                value: "demo-hash");
        }
    }
}
