using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedApp.Migrations
{
    public partial class ReSeme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ReSe",
                startValue: 100L,
                incrementBy: 3);

            migrationBuilder.AddColumn<string>(
                name: "GeneratedValueT",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: @"'REFERENCE_' + CONVERT(varchar, NEXT VALUE FOR ReSe)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "ReSe");

            migrationBuilder.DropColumn(
                name: "GeneratedValueT",
                table: "Employees");
        }
    }
}
