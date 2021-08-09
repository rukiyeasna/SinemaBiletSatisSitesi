using Microsoft.EntityFrameworkCore.Migrations;

namespace SBSSProje.DataAccess.Migrations
{
    public partial class AddColumnStatusInMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "movies");
        }
    }
}
