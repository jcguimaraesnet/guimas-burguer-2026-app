using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguer2026App.Pages
{
    public class DetailsModel : PageModel
    {
        public Hamburguer Hamburguer { get; set; }

        public void OnGet(int id)
        {
            var service = new HamburguerService();
            Hamburguer = service.Obter(id);
        }
    }
}
