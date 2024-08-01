using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Parent_App.Migrations
{
    /// <inheritdoc />
    public partial class DateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AcknowledgeDate",
                table: "Circulars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Acknowledged",
                table: "Circulars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcknowledgeDate",
                table: "Circulars");

            migrationBuilder.DropColumn(
                name: "Acknowledged",
                table: "Circulars");
        }
    }
}
