namespace GuimasBurguerAppWeb.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Descricao { get; set; }
    public ICollection<Hamburguer>? Hamburgueres { get; set; }
}
