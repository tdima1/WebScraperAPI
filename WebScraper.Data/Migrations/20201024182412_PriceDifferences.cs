using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Data.Migrations
{
    public partial class PriceDifferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceDifferenceInPercentage",
                table: "Price",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceDifferenceInValue",
                table: "Price",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceDifferenceInPercentage",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "PriceDifferenceInValue",
                table: "Price");
        }
    }
}
