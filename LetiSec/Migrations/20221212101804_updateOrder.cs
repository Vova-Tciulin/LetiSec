using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class updateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "GuidKeys",
                newName: "Key");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "GuidKeys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAECYiXn+Ino6jw8+kfpLztmJEmhh98Pb9lnLAdc+K4NY7TXGVJjypzNcE5vcCaudMtQ==");

            migrationBuilder.AddForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "GuidKeys",
                newName: "Guid");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "GuidKeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM8PUHHNWChjQkQgTvepjzcIQXAG9Fp4CQHPiXUuV8cjuIdpkF/9zaIwVZvnCBk94A==");

            migrationBuilder.AddForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
