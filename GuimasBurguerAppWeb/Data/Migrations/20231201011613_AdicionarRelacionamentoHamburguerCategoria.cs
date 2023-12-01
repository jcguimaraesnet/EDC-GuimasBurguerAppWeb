using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoHamburguerCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaHamburguer",
                columns: table => new
                {
                    CategoriasCategoriaId = table.Column<int>(type: "int", nullable: false),
                    HamburgueresHamburguerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaHamburguer", x => new { x.CategoriasCategoriaId, x.HamburgueresHamburguerId });
                    table.ForeignKey(
                        name: "FK_CategoriaHamburguer_Categoria_CategoriasCategoriaId",
                        column: x => x.CategoriasCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaHamburguer_Hamburguer_HamburgueresHamburguerId",
                        column: x => x.HamburgueresHamburguerId,
                        principalTable: "Hamburguer",
                        principalColumn: "HamburguerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaHamburguer_HamburgueresHamburguerId",
                table: "CategoriaHamburguer",
                column: "HamburgueresHamburguerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaHamburguer");
        }
    }
}
