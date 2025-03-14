using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameService.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCascade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Teams_TeamId",
                table: "UserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Teams_TeamId",
                table: "UserCharacters",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Teams_TeamId",
                table: "UserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Teams_TeamId",
                table: "UserCharacters",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
