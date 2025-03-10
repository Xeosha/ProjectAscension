using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameService.Data.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Proffesion_ProffesionId",
                table: "UserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Proffesion_ProffesionId",
                table: "UserCharacters",    
                column: "ProffesionId",
                principalTable: "Proffesion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Proffesion_ProffesionId",
                table: "UserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Proffesion_ProffesionId",
                table: "UserCharacters",
                column: "ProffesionId",
                principalTable: "Proffesion",
                principalColumn: "Id");
        }
    }
}
