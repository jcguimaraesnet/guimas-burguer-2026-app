using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuimasBurguer2026App.Data;
using GuimasBurguer2026App.Models;

namespace GuimasBurguer2026App.Pages.Marcas
{
    public class CreateModel : PageModel
    {
        private readonly GuimasBurguer2026App.Data.HamburguerDbContext _context;

        public CreateModel(GuimasBurguer2026App.Data.HamburguerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Marca Marca { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Marca.Add(Marca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
