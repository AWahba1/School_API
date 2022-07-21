using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    public partial class V17 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AcademicYear",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndMonth",
                table: "AcademicYear",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartMonth",
                table: "AcademicYear",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "StartMonth",
                table: "AcademicYear");

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
