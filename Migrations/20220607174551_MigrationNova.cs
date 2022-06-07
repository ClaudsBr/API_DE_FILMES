using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Filmes.Migrations
{
    public partial class MigrationNova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "Nacionalidade",
                table: "Filmes",
                newName: "Pais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Filmes",
                newName: "Nacionalidade");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
