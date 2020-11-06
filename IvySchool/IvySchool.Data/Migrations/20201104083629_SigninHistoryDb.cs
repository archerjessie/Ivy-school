using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IvySchool.Data.Migrations
{
    public partial class SigninHistoryDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoggedin",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "SignInTime",
                table: "signIns",
                newName: "SigninTime");

            migrationBuilder.RenameColumn(
                name: "SignIn",
                table: "signIns",
                newName: "SigninIp");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "SigninTime",
                table: "signIns",
                newName: "SignInTime");

            migrationBuilder.RenameColumn(
                name: "SigninIp",
                table: "signIns",
                newName: "SignIn");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoggedin",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
