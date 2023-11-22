using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguerAppWeb.Services.Data;

public class HamburguerService : IHamburguerService
{
    private HamburgueriaDbContext _context;

    public HamburguerService(HamburgueriaDbContext context)
    {
        _context = context;
    }

    public void Alterar(Hamburguer hamburguer)
    {
        var hamburguerEncontrado = Obter(hamburguer.HamburguerId);
        hamburguerEncontrado.Nome = hamburguer.Nome;
        hamburguerEncontrado.Descricao = hamburguer.Descricao;
        hamburguerEncontrado.Preco = hamburguer.Preco;
        hamburguerEncontrado.EntregaExpressa = hamburguer.EntregaExpressa;
        hamburguerEncontrado.DataCadastro = hamburguer.DataCadastro;
        hamburguerEncontrado.ImagemUri = hamburguer.ImagemUri;
        
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var hamburguerEncontrado = Obter(id);
        _context.Hamburguer.Remove(hamburguerEncontrado);
        _context.SaveChanges();
    }

    public void Incluir(Hamburguer hamburguer)
    {
        _context.Hamburguer.Add(hamburguer);
        _context.SaveChanges();
    }

    public Hamburguer Obter(int id)
    {
        return _context.Hamburguer.SingleOrDefault(item => item.HamburguerId == id);
    }

    public IList<Marca> ObterTodasAsMarcas()
    {
        return _context.Marca.ToList();
    }

    public IList<Hamburguer> ObterTodos()
    {
        return _context.Hamburguer.ToList();
    }
}
