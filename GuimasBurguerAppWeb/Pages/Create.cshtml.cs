using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class CreateModel : PageModel
    {
        private IHamburguerService _service;
        public CreateModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
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