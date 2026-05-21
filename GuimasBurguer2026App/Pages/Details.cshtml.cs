using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguer2026App.Pages
{
    public class DetailsModel : PageModel
    {
        public Hamburguer Hamburguer { get; set; }
        private IHamburguerService _service;
        public Marca Marca { get; set; }

        public DetailsModel(IHamburguerService service)
        {
            _service = service;
        }


        public void OnGet(int id)
        {
            Hamburguer = _service.Obter(id);
            Marca = _service.ObterTodasMarcas()
                .SingleOrDefault(item => item.MarcaId == Hamburguer.MarcaId);
        }
    }
}
