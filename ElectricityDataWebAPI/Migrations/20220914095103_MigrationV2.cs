using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectricityDataWebAPI.Migrations
{
    public partial class MigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Difference",
                table: "ElectricityData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difference",
                table: "ElectricityData");
        }
    }
}
