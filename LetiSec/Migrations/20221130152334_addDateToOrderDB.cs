using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    public partial class addDateToOrderDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEFv+nUk0bOYMXJ2mAsW/rdVywginDfq83VBK60sS/pYWg1m7WDg5a7lOb32nWiV4SQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEANFNl4vaAfMGCPN2yCrwX3dbiXfq+rUEC4oyrRHkwDfa9ZwxHNnZduFZMEirrI9aQ==");
        }
    }
}
