using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorail.Data.Migrations
{
    public partial class InıtMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "teachers",
                newName: "teachers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Student",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "courses",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "teachers",
                schema: "dbo",
                newName: "teachers");

            migrationBuilder.RenameTable(
                name: "Student",
                schema: "dbo",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "courses",
                schema: "dbo",
                newName: "courses");
        }
    }
}
