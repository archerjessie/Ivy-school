using Microsoft.EntityFrameworkCore.Migrations;

namespace IvySchool.Data.Migrations
{
    public partial class newUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleUserId",
                table: "RoleUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleUserId",
                table: "RoleUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
