using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages;

public class DetailsModel : PageModel
{
    private IHamburguerService _service;

    public DetailsModel(IHamburguerService hamburguerService)
    {
        _service = hamburguerService;
    }

    public Hamburguer Hamburguer { get; private set; }
    public Marca Marca { get; private set; }

    public IActionResult OnGet(int id)
    {
        Hamburguer = _service.Obter(id);
        Marca = _service.ObterTodasAsMarcas().SingleOrDefault(item => item.MarcaId == Hamburguer.MarcaId);
        
        if (Hamburguer == null)
        {
            return NotFound();
        }

        return Page();
    }
}
