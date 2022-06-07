using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Filmes.Migrations
{
    public partial class CretingNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diretor",
                table: "Filmes");

            migrationBuilder.AddColumn<int>(
                name: "DiretorId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidade",
                table: "Filmes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "RatingIMDB",
                table: "Filmes",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TituloOriginal",
                table: "Filmes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nacionalidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nacionalidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AtorFilme",
                columns: table => new
                {
                    ElencoId = table.Column<int>(type: "int", nullable: false),
                    TrabalhosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtorFilme", x => new { x.ElencoId, x.TrabalhosId });
                    table.ForeignKey(
                        name: "FK_AtorFilme_Atores_ElencoId",
                        column: x => x.ElencoId,
                        principalTable: "Atores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtorFilme_Filmes_TrabalhosId",
                        column: x => x.TrabalhosId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");

            migrationBuilder.CreateIndex(
                name: "IX_AtorFilme_TrabalhosId",
                table: "AtorFilme",
                column: "TrabalhosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes",
                column: "DiretorId",
                principalTable: "Diretores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes");

            migrationBuilder.DropTable(
                name: "AtorFilme");

            migrationBuilder.DropTable(
                name: "Diretores");

            migrationBuilder.DropTable(
                name: "Atores");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "DiretorId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "Nacionalidade",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "RatingIMDB",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "TituloOriginal",
                table: "Filmes");

            migrationBuilder.AddColumn<string>(
                name: "Diretor",
                table: "Filmes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
