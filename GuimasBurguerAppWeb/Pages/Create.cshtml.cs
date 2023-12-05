using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguerAppWeb.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private IHamburguerService _service;
        public SelectList MarcaOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }

        public CreateModel(IHamburguerService hamburguerService)
        {
            _service = hamburguerService;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));
        }


        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public IActionResult OnPost()
        {
            Hamburguer.Categorias = _service.ObterTodasAsCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Hamburguer);

            return RedirectToPage("/Index");
        }
    }
}