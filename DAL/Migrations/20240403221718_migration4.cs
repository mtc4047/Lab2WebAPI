using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPositions_Products_OrderId",
                table: "OrdersPositions");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrdersPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPositions_ProductId",
                table: "OrdersPositions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPositions_Products_ProductId",
                table: "OrdersPositions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPositions_Products_ProductId",
                table: "OrdersPositions");

            migrationBuilder.DropIndex(
                name: "IX_OrdersPositions_ProductId",
                table: "OrdersPositions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrdersPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPositions_Products_OrderId",
                table: "OrdersPositions",
                column: "OrderId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
