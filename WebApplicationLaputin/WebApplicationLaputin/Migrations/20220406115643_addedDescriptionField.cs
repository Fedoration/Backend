using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationLaputin.Migrations
{
    public partial class addedDescriptionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "TemperatureSensors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "PressureSensors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "ConsumptionSensors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "TemperatureSensors");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "PressureSensors");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "ConsumptionSensors");
        }
    }
}
