using Microsoft.EntityFrameworkCore.Migrations;

namespace GameApi.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rarity",
                table: "Items",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "Rarity");
        }
    }
}
