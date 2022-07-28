using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerRater.Data.Migrations
{
    public partial class updatescoretodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Ratings",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
