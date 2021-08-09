using Microsoft.EntityFrameworkCore.Migrations;

namespace SBSSProje.DataAccess.Migrations
{
    public partial class AddStatusInBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "branches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "branches");
        }
    }
}
