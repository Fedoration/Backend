using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplicationLaputin.Migrations
{
    public partial class addedUnitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Valves",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "TemperatureSensors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "PressureSensors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "ConsumptionSensors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Unknown")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valves_UnitId",
                table: "Valves",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureSensors_UnitId",
                table: "TemperatureSensors",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PressureSensors_UnitId",
                table: "PressureSensors",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionSensors_UnitId",
                table: "ConsumptionSensors",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumptionSensors_Units_UnitId",
                table: "ConsumptionSensors",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PressureSensors_Units_UnitId",
                table: "PressureSensors",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemperatureSensors_Units_UnitId",
                table: "TemperatureSensors",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Valves_Units_UnitId",
                table: "Valves",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumptionSensors_Units_UnitId",
                table: "ConsumptionSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_PressureSensors_Units_UnitId",
                table: "PressureSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_TemperatureSensors_Units_UnitId",
                table: "TemperatureSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Valves_Units_UnitId",
                table: "Valves");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Valves_UnitId",
                table: "Valves");

            migrationBuilder.DropIndex(
                name: "IX_TemperatureSensors_UnitId",
                table: "TemperatureSensors");

            migrationBuilder.DropIndex(
                name: "IX_PressureSensors_UnitId",
                table: "PressureSensors");

            migrationBuilder.DropIndex(
                name: "IX_ConsumptionSensors_UnitId",
                table: "ConsumptionSensors");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Valves");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "TemperatureSensors");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "PressureSensors");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ConsumptionSensors");
        }
    }
}
