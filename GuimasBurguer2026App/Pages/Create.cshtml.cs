using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguer2026App.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        private IHamburguerService _service;

        public CreateModel(IHamburguerService service)
        {
            _service = service;
        }

        public IActionResult OnPost()
        {
            _service.Incluir(Hamburguer);

            return RedirectToPage("/Index");
        }
    }
}
