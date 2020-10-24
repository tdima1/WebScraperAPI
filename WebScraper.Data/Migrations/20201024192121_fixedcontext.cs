using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Data.Migrations
{
    public partial class fixedcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Products_ProductId",
                table: "Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_ProductId",
                table: "Price");

            migrationBuilder.RenameTable(
                name: "Price",
                newName: "Prices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId",
                table: "Prices",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Products_ProductId",
                table: "Prices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Products_ProductId",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ProductId",
                table: "Prices");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "Price");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Products_ProductId",
                table: "Price",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
