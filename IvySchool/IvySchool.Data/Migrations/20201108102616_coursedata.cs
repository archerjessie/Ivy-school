using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IvySchool.Data.Migrations
{
    public partial class coursedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_signIns_User_userId",
                table: "signIns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_signIns",
                table: "signIns");

            migrationBuilder.RenameTable(
                name: "signIns",
                newName: "SignIns");

            migrationBuilder.RenameIndex(
                name: "IX_signIns_userId",
                table: "SignIns",
                newName: "IX_SignIns_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignIns",
                table: "SignIns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    PrerequisiteKnowledge = table.Column<string>(nullable: true),
                    CommenceDate = table.Column<DateTime>(nullable: false),
                    StartAppliedDate = table.Column<DateTime>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: false),
                    Tuition = table.Column<decimal>(nullable: false),
                    Teacher = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudentDb",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentDb", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudentDb_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudentDb_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentDb_StudentId",
                table: "CourseStudentDb",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignIns_User_userId",
                table: "SignIns",
                column: "userId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignIns_User_userId",
                table: "SignIns");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "CourseStudentDb");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SignIns",
                table: "SignIns");

            migrationBuilder.RenameTable(
                name: "SignIns",
                newName: "signIns");

            migrationBuilder.RenameIndex(
                name: "IX_SignIns_userId",
                table: "signIns",
                newName: "IX_signIns_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_signIns",
                table: "signIns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_signIns_User_userId",
                table: "signIns",
                column: "userId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
