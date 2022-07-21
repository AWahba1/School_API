using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AcademicYear_AcademicYearId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYearId",
                table: "Student",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AcademicYear_AcademicYearId",
                table: "Student",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "AcademicYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AcademicYear_AcademicYearId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYearId",
                table: "Student",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AcademicYear_AcademicYearId",
                table: "Student",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
