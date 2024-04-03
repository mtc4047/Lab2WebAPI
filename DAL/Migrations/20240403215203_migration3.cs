using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPositions_Orders_OrderId",
                table: "OrdersPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPositions_Orders_OrderId",
                table: "OrdersPositions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPositions_Orders_OrderId",
                table: "OrdersPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPositions_Orders_OrderId",
                table: "OrdersPositions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
