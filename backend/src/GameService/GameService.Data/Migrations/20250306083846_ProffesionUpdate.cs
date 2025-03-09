using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameService.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProffesionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_CharacterProfessions_ProffesionId",
                table: "UserCharacters");

            migrationBuilder.DropTable(
                name: "CharacterProfessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProffesionId",
                table: "UserCharacters",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "Proffesion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proffesion", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_Proffesion_ProffesionId",
                table: "UserCharacters",
                column: "ProffesionId",
                principalTable: "Proffesion",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_Proffesion_ProffesionId",
                table: "UserCharacters");

            migrationBuilder.DropTable(
                name: "Proffesion");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProffesionId",
                table: "UserCharacters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterProfessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterProfessions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_CharacterProfessions_ProffesionId",
                table: "UserCharacters",
                column: "ProffesionId",
                principalTable: "CharacterProfessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
