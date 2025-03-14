using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameService.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Proffesions_ProffesionId",
                table: "UserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Proffesions_ProffesionId",
                table: "UserCharacters",
                column: "ProffesionId",
                principalTable: "Proffesions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Proffesions_ProffesionId",
                table: "UserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Proffesions_ProffesionId",
                table: "UserCharacters",
                column: "ProffesionId",
                principalTable: "Proffesions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
