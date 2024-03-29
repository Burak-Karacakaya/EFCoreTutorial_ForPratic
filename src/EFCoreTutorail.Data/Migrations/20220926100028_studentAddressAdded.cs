﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorail.Data.Migrations
{
    public partial class studentAddressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                schema: "dbo",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                schema: "dbo",
                newName: "Students",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                schema: "dbo",
                table: "Students",
                column: "id");

            migrationBuilder.CreateTable(
                name: "student_addresses",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    district = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    full_address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    student_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_addresses", x => x.id);
                    table.ForeignKey(
                        name: "student_address_id_fk",
                        column: x => x.student_id,
                        principalSchema: "dbo",
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_addresses",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                schema: "dbo",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "dbo",
                newName: "Student",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                schema: "dbo",
                table: "Student",
                column: "id");
        }
    }
}
