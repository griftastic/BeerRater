using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerRater.Data.Migrations
{
    public partial class breweryfkfrombeers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BreweryId",
                table: "Beers");

            migrationBuilder.AddColumn<int>(
                name: "BreweriesId",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweriesId",
                table: "Beers",
                column: "BreweriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweriesId",
                table: "Beers",
                column: "BreweriesId",
                principalTable: "Breweries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweriesId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BreweriesId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BreweriesId",
                table: "Beers");

            migrationBuilder.AddColumn<int>(
                name: "BreweryId",
                table: "Beers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers",
                column: "BreweryId",
                principalTable: "Breweries",
                principalColumn: "Id");
        }
    }
}
