using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages;

public class IndexModel : PageModel
{
    private IHamburguerService _service;

    public IndexModel(IHamburguerService hamburguerService)
    {
        _service = hamburguerService;
    }

    public IList<Hamburguer> ListaHamburguer { get; private set; }

    public void OnGet()
    {
        ViewData["Title"] = "Home page";

        ListaHamburguer = _service.ObterTodos();
    }
}