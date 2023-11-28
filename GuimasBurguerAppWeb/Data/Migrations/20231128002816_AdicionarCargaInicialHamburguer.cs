using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialHamburguer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new HamburgueriaDbContext();
            context.Hamburguer.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Hamburguer> ObterCargaInicial()
        {
            return new List<Hamburguer>()
            {
                new Hamburguer
                {
                    Nome = "Beef Burger",
                    Descricao = "Hambúrguer simples: suculento, saboroso e delicioso.",
                    ImagemUri = "/images/beef-burger.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = true,
                    Preco = 19.00,
                },
                new Hamburguer
                {
                    Nome = "Canoe Burger",
                    Descricao = "Delicioso hambúrguer com batata canoa crocante. Uma explosão de sabores em cada mordida!",
                    ImagemUri = "/images/beef-burger-canoe-potatoes.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = false,
                    Preco = 29.00,
                },
                new Hamburguer
                {
                    Nome = "Pepper Burger",
                    Descricao = "Hambúrguer irresistível com pimentão: sabor picante e suculento em cada pedaço!",
                    ImagemUri = "/images/beef-burger-peppers.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = true,
                    Preco = 39.00,
                },
                new Hamburguer
                {
                    Nome = "Chickpea Burger",
                    Descricao = "Saboroso hambúrguer de grão de bico: uma opção saudável e incrivelmente saborosa!",
                    ImagemUri = "/images/chickpea-burger.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = true,
                    Preco = 49.00,
                },
            };
        }

    }
}
