using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Final1.Data.Migrations
{
    /// <inheritdoc />
    public partial class createmigrationnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Course_CourseId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_Student_StudentId",
                table: "Register");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Course_CourseId",
                table: "Register",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Student_StudentId",
                table: "Register",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Course_CourseId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_Student_StudentId",
                table: "Register");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Register",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Register",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Course_CourseId",
                table: "Register",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Student_StudentId",
                table: "Register",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId");
        }
    }
}
