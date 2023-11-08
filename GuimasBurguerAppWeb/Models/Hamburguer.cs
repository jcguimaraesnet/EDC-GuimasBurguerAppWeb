using System.ComponentModel.DataAnnotations;

namespace GuimasBurguerAppWeb.Models;

public class Hamburguer
{
    public int HamburguerId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Nome' obrigatório.")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Campo 'Nome'deve conter entre 10 e 50 caracteres.")]
    public string Nome { get; set; }

    public string NomeSlug => Nome.ToLower().Replace(" ", "-");

    [Display(Name = "Descrição")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Descrição' obrigatório.")]
    [StringLength(100, MinimumLength = 50, ErrorMessage = "Campo 'Nome'deve conter entre 50 e 100 caracteres.")]
    public string Descricao { get; set; }

    [Display(Name = "Caminho da Imagem")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Caminho da Image' obrigatório.")]
    public string ImagemUri { get; set; }
    
    [Display(Name = "Preço")]
    [Required(ErrorMessage = "Campo 'Preço' obrigatório.")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }

    [Display(Name = "Entrega Expressa")]
    public bool EntregaExpressa { get; set; }

    public string EntregaExpressaFormatada => EntregaExpressa ? "Sim" : "Não";

    [Display(Name = "Disponível em")]
    [Required(ErrorMessage = "Campo 'Disponível em' obrigatório.")]
    [DataType("month")]
    [DisplayFormat(DataFormatString = "{0:MMMM \\de yyyy}")]
    public DateTime DataCadastro { get; set; }

}
