using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguer2026App.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Hamburguer Hamburguer { get; set; }
        public SelectList MarcaOptionItems { get; set; }


        private IHamburguerService _service;

        public EditModel(IHamburguerService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Hamburguer = _service.Obter(id);

            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));
        }

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
            TempData["TempMensagemSucesso"] = true;

            _service.Excluir(Hamburguer.HamburguerId);
            return RedirectToPage("/Index");
        }
    }
}
