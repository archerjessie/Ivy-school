using Microsoft.EntityFrameworkCore.Migrations;

namespace IvySchool.Data.Migrations
{
    public partial class newCourseStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentDb_Courses_CourseId",
                table: "CourseStudentDb");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentDb_Student_StudentId",
                table: "CourseStudentDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudentDb",
                table: "CourseStudentDb");

            migrationBuilder.RenameTable(
                name: "CourseStudentDb",
                newName: "CourseStudents");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentDb_StudentId",
                table: "CourseStudents",
                newName: "IX_CourseStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_CourseId",
                table: "CourseStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Student_StudentId",
                table: "CourseStudents",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_CourseId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Student_StudentId",
                table: "CourseStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.RenameTable(
                name: "CourseStudents",
                newName: "CourseStudentDb");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudentDb",
                newName: "IX_CourseStudentDb_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudentDb",
                table: "CourseStudentDb",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentDb_Courses_CourseId",
                table: "CourseStudentDb",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentDb_Student_StudentId",
                table: "CourseStudentDb",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
