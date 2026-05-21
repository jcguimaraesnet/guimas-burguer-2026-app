using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.ConstrainedExecution;

namespace GuimasBurguer2026App.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Hamburguer Hamburguer { get; set; }
        public SelectList MarcaOptionItems { get; set; }

        private IHamburguerService _service;

        public CreateModel(IHamburguerService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));

        }

        public IActionResult OnPost()
        {
            if (Hamburguer.Nome == Hamburguer.Descricao)
            {
                ModelState.AddModelError("Hamburguer.Nome", "O nome não pode ser igual a descrição.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Hamburguer);

            return RedirectToPage("/Index");
        }
    }
}
