using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedApp.Migrations
{
    public partial class Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecondaryIdentity_Employees_PrimarySSN_PrimaryFirstName_PrimaryFamilyName",
                table: "SecondaryIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_SecondaryIdentity_Employees_PrimarySSN_PrimaryFirstName_PrimaryFamilyName",
                table: "SecondaryIdentity",
                columns: new[] { "PrimarySSN", "PrimaryFirstName", "PrimaryFamilyName" },
                principalTable: "Employees",
                principalColumns: new[] { "SSN", "FirstName", "FamilyName" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecondaryIdentity_Employees_PrimarySSN_PrimaryFirstName_PrimaryFamilyName",
                table: "SecondaryIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_SecondaryIdentity_Employees_PrimarySSN_PrimaryFirstName_PrimaryFamilyName",
                table: "SecondaryIdentity",
                columns: new[] { "PrimarySSN", "PrimaryFirstName", "PrimaryFamilyName" },
                principalTable: "Employees",
                principalColumns: new[] { "SSN", "FirstName", "FamilyName" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
