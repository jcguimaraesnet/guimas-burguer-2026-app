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
    public class IndexModel : PageModel
    {
        private readonly GuimasBurguer2026App.Data.HamburguerDbContext _context;

        public IndexModel(GuimasBurguer2026App.Data.HamburguerDbContext context)
        {
            _context = context;
        }

        public IList<Marca> Marca { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Marca = await _context.Marca.ToListAsync();
        }
    }
}
