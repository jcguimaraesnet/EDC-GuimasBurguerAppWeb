﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Models;

namespace GuimasBurguerAppWeb.Pages.Marcas
{
    public class DeleteModel : PageModel
    {
        private readonly GuimasBurguerAppWeb.Data.HamburgueriaDbContext _context;

        public DeleteModel(GuimasBurguerAppWeb.Data.HamburgueriaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Marca Marca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.MarcaId == id);

            if (marca == null)
            {
                return NotFound();
            }
            else 
            {
                Marca = marca;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }
            var marca = await _context.Marca.FindAsync(id);

            if (marca != null)
            {
                Marca = marca;
                _context.Marca.Remove(Marca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
