namespace GuimasBurguerAppWeb.Models;

public class Marca
{
    public int MarcaId { get; set; }
    public string Descricao { get; set; }

    public ICollection<Hamburguer> Hamburgueres { get; set; }
}
