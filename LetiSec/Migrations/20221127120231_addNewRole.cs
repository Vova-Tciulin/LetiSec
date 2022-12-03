using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    public partial class addNewRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Users_UserId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetails_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "moderator" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOmhe8/yFmncMmh4EorTNEmBS/6FVIsr/QB41LO9ryWOVWMqk5DuBDPNs9DZiuUMeg==");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAjz2cq1pnU9yUvvwwhHi0A0ozV5J+6AlAdt1WrSyMr9hGqtFIbSwJiCCmk4qsoM9Q==");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Users_UserId",
                table: "OrderDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderDetails_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "OrderDetails",
                principalColumn: "Id");
        }
    }
}
