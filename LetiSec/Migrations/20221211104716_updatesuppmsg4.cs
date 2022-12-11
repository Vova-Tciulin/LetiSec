using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class updatesuppmsg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "SuppMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAECl0VRSQ7yFcz6M0rkXJEBhf23BUKP5LmezXo8I4CIsrVh1V2rnUIZCuDlZXpAmGVg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "SuppMessages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEKsBJlcdxZGQOd4oD8+lJV0/9XYItnHJcnuzH7nvT3xUZoBTBK79E1HJPU13clUQTA==");
        }
    }
}
