using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedApp.Migrations
{
    public partial class GetDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GeneratedValueT",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'REFERENCE_' + CONVERT(varchar, NEXT VALUE FOR ReSe)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GeneratedValueT",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'REFERENCE_' + CONVERT(varchar, NEXT VALUE FOR ReSe)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
