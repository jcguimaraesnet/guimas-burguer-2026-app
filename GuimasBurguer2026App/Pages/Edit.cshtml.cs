using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuimasBurguer2026App.Pages
{
    public class EditModel : PageModel
    {
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

            CarregarMarcas();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Hamburguer = _service.Obter(id);
            if (Hamburguer == null) return NotFound();

            if (await TryUpdateModelAsync(Hamburguer, nameof(Hamburguer),
                    h => h.Nome,
                    h => h.Descricao,
                    h => h.Preco,
                    h => h.EntregaExpressa,
                    h => h.DataCadastro,
                    h => h.ImagemUri,
                    h => h.MarcaId))
            {
                _service.Salvar();
                return RedirectToPage("/Index");
            }

            CarregarMarcas();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            TempData["TempMensagemSucesso"] = true;

            _service.Excluir(id);
            return RedirectToPage("/Index");
        }

        private void CarregarMarcas()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));
        }
    }
}
