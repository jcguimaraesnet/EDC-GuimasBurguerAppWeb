using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguerAppWeb.Pages
{
    public class CreateModel : PageModel
    {
        private IHamburguerService _service;
        public SelectList MarcaOptionItems { get; set; }

        public CreateModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));
        }


        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Hamburguer);

            return RedirectToPage("/Index");
        }
    }
}