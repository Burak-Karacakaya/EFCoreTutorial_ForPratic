using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorail.Data.Migrations
{
    public partial class studentAddressChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.DropIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.DropColumn(
                name: "student_id",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                schema: "dbo",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_address_id",
                schema: "dbo",
                table: "Students",
                column: "address_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "Students",
                column: "address_id",
                principalSchema: "dbo",
                principalTable: "student_addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_address_id",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "address_id",
                schema: "dbo",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                schema: "dbo",
                table: "student_addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
