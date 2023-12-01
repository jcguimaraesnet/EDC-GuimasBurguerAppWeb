using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace GuimasBurguerAppWeb.Pages
{
    public class EditModel : PageModel
    {
        private IToastNotification _toastNotification;
        private IHamburguerService _service;
        public SelectList MarcaOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }

        public EditModel(IHamburguerService hamburguerService, 
                         IToastNotification toastNotification)
        {
            _service = hamburguerService;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public void OnGet(int id)
        {
            Hamburguer = _service.Obter(id);

            CategoriaIds = Hamburguer.Categorias.Select(item => item.CategoriaId).ToList();

            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));
        }

        public IActionResult OnPost()
        {
            Hamburguer.Categorias = _service.ObterTodasAsCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(Hamburguer);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(Hamburguer.HamburguerId);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}
