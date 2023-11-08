using GuimasBurguerAppWeb.Models;

namespace GuimasBurguerAppWeb.Services;

public interface IHamburguerService
{
    IList<Hamburguer> ObterTodos();
    Hamburguer Obter(int id);
    void Incluir(Hamburguer hamburguer);
    void Alterar(Hamburguer hamburguer);
    void Excluir(int id);
}
