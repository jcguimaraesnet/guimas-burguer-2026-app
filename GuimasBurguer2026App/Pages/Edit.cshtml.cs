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
        public SelectList CategoriaOptionItems { get; set; }

        [BindProperty]
        public IList<int>? CategoriaId { get; set; }

        private IHamburguerService _service;

        public EditModel(IHamburguerService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));

            CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));

            Hamburguer = _service.Obter(id);
            CategoriaId = Hamburguer.Categorias?
                            .Select(item => item.CategoriaId).ToList();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Hamburguer = _service.Obter(id);
            if (Hamburguer == null) return NotFound();

            Hamburguer.Categorias = _service.ObterTodasCategorias()
                    .Where(item => CategoriaId.Contains(item.CategoriaId))
                    .ToList();

            if (await TryUpdateModelAsync(Hamburguer, nameof(Hamburguer),
                    h => h.Nome,
                    h => h.Descricao,
                    h => h.Preco,
                    h => h.EntregaExpressa,
                    h => h.DataCadastro,
                    h => h.ImagemUri,
                    h => h.MarcaId,
                    h => h.Categorias))
            {
                _service.Salvar(Hamburguer);
                return RedirectToPage("/Index");
            }

            CarregarMarcas();
            return Page();
        }

        public IActionResult OnPostDelete()
        {
            TempData["TempMensagemSucesso"] = true;

            _service.Excluir(Hamburguer.HamburguerId);
            return RedirectToPage("/Index");
        }

        public void CarregarMarcas()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Nome));
        }
    }
}
