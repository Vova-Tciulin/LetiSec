using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetiSec.Migrations
{
    /// <inheritdoc />
    public partial class addAnswersQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SuppMessages");

            migrationBuilder.CreateTable(
                name: "SuppAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuppMessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuppAnswers_SuppMessages_SuppMessageId",
                        column: x => x.SuppMessageId,
                        principalTable: "SuppMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuppQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuppMessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuppQuestions_SuppMessages_SuppMessageId",
                        column: x => x.SuppMessageId,
                        principalTable: "SuppMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBkYbJzIiSWI0ZjfIcNy/VHONyvyMFtedxWbM50xCeuEHSiEnBT4sV/ky2P93ESQnA==");

            migrationBuilder.CreateIndex(
                name: "IX_SuppAnswers_SuppMessageId",
                table: "SuppAnswers",
                column: "SuppMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuppQuestions_SuppMessageId",
                table: "SuppQuestions",
                column: "SuppMessageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuppAnswers");

            migrationBuilder.DropTable(
                name: "SuppQuestions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SuppMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEO1RKh/zN74J1ifQ5c/xkvG66PnG5lF66hMhGPX3a9pe9fnyKrTgMeLQfZ7GojuLnA==");
        }
    }
}
