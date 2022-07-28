using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerRater.Data.Migrations
{
    public partial class Ratingsfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Beers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
