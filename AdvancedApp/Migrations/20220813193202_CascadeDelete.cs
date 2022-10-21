using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedApp.Migrations
{
    public partial class CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         //  migrationBuilder.DropColumn(
           //     name: "RowVersion",
          //     table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Employees",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
