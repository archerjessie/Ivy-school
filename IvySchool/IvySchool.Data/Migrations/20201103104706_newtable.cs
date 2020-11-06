using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IvySchool.Data.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoggedin",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "signIns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SignInTime = table.Column<DateTime>(nullable: false),
                    SignIn = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_signIns_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SignUpSource = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    NumberOfLogins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_signIns_userId",
                table: "signIns",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "signIns");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropColumn(
                name: "LastLoggedin",
                table: "User");
        }
    }
}
