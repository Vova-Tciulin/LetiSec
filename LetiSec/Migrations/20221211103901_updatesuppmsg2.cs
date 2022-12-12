using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class updatesuppmsg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAECN5KDTwMGI7r9ivFg3VhtcsVP4lU+W3vYfgD2wbnC1rUxTY+Ql2jkOybbcxAIOV4Q==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGkbD5XtdUDTmcjXpNOgifgbVt5d49oE8RZ/JOAdMjxOILEdEwOw8GaOrIVmimMKVQ==");
        }
    }
}
