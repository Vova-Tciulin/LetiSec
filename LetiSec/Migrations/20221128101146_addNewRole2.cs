using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    public partial class addNewRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEMZ5sersvcAtOh/6W1NwwU73YOnKr3QUk0e4eX5e4WBj4mgLUX4Fi4aRiN0Kl9jL6Q==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEP7uH+x8808hr8AGLL5SXBnVrO0heuBn2MTu96RuctkmfO2jMqpKzGmSwfYhd0I2yQ==");
        }
    }
}
