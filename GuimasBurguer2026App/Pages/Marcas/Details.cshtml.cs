using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuimasBurguer2026App.Data;
using GuimasBurguer2026App.Models;

namespace GuimasBurguer2026App.Pages.Marcas
{
    public class DetailsModel : PageModel
    {
        private readonly GuimasBurguer2026App.Data.HamburguerDbContext _context;

        public DetailsModel(GuimasBurguer2026App.Data.HamburguerDbContext context)
        {
            _context = context;
        }

        public Marca Marca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.MarcaId == id);

            if (marca is not null)
            {
                Marca = marca;

                return Page();
            }

            return NotFound();
        }
    }
}
