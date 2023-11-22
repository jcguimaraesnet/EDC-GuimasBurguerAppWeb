using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new HamburgueriaDbContext();
            context.Marca.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Marca> ObterCargaInicial()
        {
            return new List<Marca>()
            {
                new Marca() { Descricao = "Sadia" },
                new Marca() { Descricao = "Perdigão" },
                new Marca() { Descricao = "Seara" },
            };
        }
    }
}
