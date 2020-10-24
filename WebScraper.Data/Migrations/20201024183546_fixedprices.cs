using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Data.Migrations
{
    public partial class fixedprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PriceDifferenceInPercentage",
                table: "Price",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PriceDifferenceInPercentage",
                table: "Price",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
