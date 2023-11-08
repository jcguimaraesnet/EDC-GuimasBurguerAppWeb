using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class EditModel : PageModel
    {
        private IHamburguerService _service;
        public EditModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        public void OnGet(int id)
            => Hamburguer = _service.Obter(id);

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(Hamburguer);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(Hamburguer.HamburguerId);

            return RedirectToPage("/Index");
        }
    }
}
