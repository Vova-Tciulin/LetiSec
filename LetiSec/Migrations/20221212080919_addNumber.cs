using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class addNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Number", "Password" },
                values: new object[] { "+79991234567", "AQAAAAEAACcQAAAAEBIjeKe3iqZxKYqkQj6XsNgknvRv3w+S7KCzPagmvv1l2gX2aYL39vMgx5eMm5dmRA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJzWP9ymzyMZCv7UFz0aZ6Ukxe93sHnMfnnLVBd4HRQW8qQomJ7BvQ8l5snI+Ow/gA==");
        }
    }
}
