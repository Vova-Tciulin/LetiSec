using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    public partial class updateOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAENgFquh3/EG9HG8IGxpsUBugNAUZ3JQURxjUQx433pR2Dz3F6vTjtq5jaa4P5FLpbg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEIFFRRdGnBapXBYFZgFr12Qefy3dPlN3EJg8FPmjGqShU1yJC5Ouw65nijoeQTSWeA==");
        }
    }
}
