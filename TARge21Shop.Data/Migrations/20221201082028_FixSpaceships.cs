using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARge21Shop.Data.Migrations
{
    public partial class FixSpaceships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShips",
                table: "SpaceShips");

            migrationBuilder.RenameTable(
                name: "SpaceShips",
                newName: "Spaceships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships");

            migrationBuilder.RenameTable(
                name: "Spaceships",
                newName: "SpaceShips");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShips",
                table: "SpaceShips",
                column: "Id");
        }
    }
}
