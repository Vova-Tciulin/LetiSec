using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class updatesuppmsg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEKsBJlcdxZGQOd4oD8+lJV0/9XYItnHJcnuzH7nvT3xUZoBTBK79E1HJPU13clUQTA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAECN5KDTwMGI7r9ivFg3VhtcsVP4lU+W3vYfgD2wbnC1rUxTY+Ql2jkOybbcxAIOV4Q==");
        }
    }
}
