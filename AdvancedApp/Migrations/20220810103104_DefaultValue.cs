using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedApp.Migrations
{
    public partial class DefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
