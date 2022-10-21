using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => new { x.SSN, x.FirstName, x.FamilyName });
                });

            migrationBuilder.CreateTable(
                name: "SecondaryIdentity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InActiveUse = table.Column<bool>(type: "bit", nullable: false),
                    PrimarySSN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrimaryFirstName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrimaryFamilyName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryIdentity_Employees_PrimarySSN_PrimaryFirstName_PrimaryFamilyName",
                        columns: x => new { x.PrimarySSN, x.PrimaryFirstName, x.PrimaryFamilyName },
                        principalTable: "Employees",
                        principalColumns: new[] { "SSN", "FirstName", "FamilyName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryIdentity_PrimarySSN_PrimaryFirstName_PrimaryFamilyName",
                table: "SecondaryIdentity",
                columns: new[] { "PrimarySSN", "PrimaryFirstName", "PrimaryFamilyName" },
                unique: true,
                filter: "[PrimarySSN] IS NOT NULL AND [PrimaryFirstName] IS NOT NULL AND [PrimaryFamilyName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondaryIdentity");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
