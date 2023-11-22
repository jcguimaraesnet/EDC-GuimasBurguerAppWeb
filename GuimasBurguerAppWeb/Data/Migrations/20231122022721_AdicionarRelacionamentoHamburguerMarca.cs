using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoHamburguerMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Hamburguer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hamburguer_MarcaId",
                table: "Hamburguer",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamburguer_Marca_MarcaId",
                table: "Hamburguer",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamburguer_Marca_MarcaId",
                table: "Hamburguer");

            migrationBuilder.DropIndex(
                name: "IX_Hamburguer_MarcaId",
                table: "Hamburguer");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Hamburguer");
        }
    }
}
