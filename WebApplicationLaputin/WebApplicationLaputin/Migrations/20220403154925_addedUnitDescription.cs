using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationLaputin.Migrations
{
    public partial class addedUnitDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");
        }
    }
}
