using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerRater.Data.Migrations
{
    public partial class breweryfkfrombeerschangednametoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Brewery",
                table: "Beers",
                newName: "BreweryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BreweryId",
                table: "Beers",
                newName: "Brewery");
        }
    }
}
