using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new HamburgueriaDbContext();
            context.Categoria.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Categoria> ObterCargaInicial()
        {
            return new List<Categoria>()
            {
                new Categoria() { Descricao = "Apimentado" },
                new Categoria() { Descricao = "Sem Glúten" },
                new Categoria() { Descricao = "Vegano" },
                new Categoria() { Descricao = "Zero Lactose" },
            };
        }
    }
}
