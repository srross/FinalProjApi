using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjApi.Migrations
{
    public partial class addMinAndMaxTemperatureColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutfitScale",
                table: "Outfits",
                newName: "MinTemperature");

            migrationBuilder.AddColumn<int>(
                name: "MaxTemperature",
                table: "Outfits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Outfits");

            migrationBuilder.RenameColumn(
                name: "MinTemperature",
                table: "Outfits",
                newName: "OutfitScale");
        }
    }
}
