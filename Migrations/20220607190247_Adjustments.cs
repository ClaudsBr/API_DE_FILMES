using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Filmes.Migrations
{
    public partial class Adjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Atores_ElencoId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Filmes_TrabalhosId",
                table: "AtorFilme");

            migrationBuilder.RenameColumn(
                name: "TrabalhosId",
                table: "AtorFilme",
                newName: "FilmesId");

            migrationBuilder.RenameColumn(
                name: "ElencoId",
                table: "AtorFilme",
                newName: "AtoresId");

            migrationBuilder.RenameIndex(
                name: "IX_AtorFilme_TrabalhosId",
                table: "AtorFilme",
                newName: "IX_AtorFilme_FilmesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Atores_AtoresId",
                table: "AtorFilme",
                column: "AtoresId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Filmes_FilmesId",
                table: "AtorFilme",
                column: "FilmesId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Atores_AtoresId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Filmes_FilmesId",
                table: "AtorFilme");

            migrationBuilder.RenameColumn(
                name: "FilmesId",
                table: "AtorFilme",
                newName: "TrabalhosId");

            migrationBuilder.RenameColumn(
                name: "AtoresId",
                table: "AtorFilme",
                newName: "ElencoId");

            migrationBuilder.RenameIndex(
                name: "IX_AtorFilme_FilmesId",
                table: "AtorFilme",
                newName: "IX_AtorFilme_TrabalhosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Atores_ElencoId",
                table: "AtorFilme",
                column: "ElencoId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Filmes_TrabalhosId",
                table: "AtorFilme",
                column: "TrabalhosId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
