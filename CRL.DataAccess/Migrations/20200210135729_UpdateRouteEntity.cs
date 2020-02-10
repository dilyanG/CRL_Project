using Microsoft.EntityFrameworkCore.Migrations;

namespace CRL.DataAccess.Migrations
{
    public partial class UpdateRouteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndCityId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartCityId",
                table: "Routes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndCityId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartCityId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
