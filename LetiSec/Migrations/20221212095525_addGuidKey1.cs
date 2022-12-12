using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class addGuidKey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys");

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
                value: "AQAAAAEAACcQAAAAEPX+swmop74qtY69cl7EvROumsEwL5AGjG17C6mrlsLt9Y57+fzKAEgIThApAQ9S9A==");

            migrationBuilder.AddForeignKey(
                name: "FK_GuidKeys_Orders_OrderId",
                table: "GuidKeys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
