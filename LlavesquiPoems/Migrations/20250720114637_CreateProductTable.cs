using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlavesquiPoems.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Recitals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Recitals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Recitals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Recitals",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Recitals");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Recitals");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Recitals");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Recitals");
        }
    }
}
