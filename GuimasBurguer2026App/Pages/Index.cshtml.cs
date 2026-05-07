using GuimasBurguer2026App.Models;
using GuimasBurguer2026App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguer2026App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IList<Hamburguer> Hamburguers { get; set; }
        private IHamburguerService _service;

        public IndexModel(ILogger<IndexModel> logger, IHamburguerService service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {
            //var service = new HamburguerMemoryService();
            //var service = new HamburguerDatabaseService();
            Hamburguers = _service.ObterTodos();
        }
    }
}
