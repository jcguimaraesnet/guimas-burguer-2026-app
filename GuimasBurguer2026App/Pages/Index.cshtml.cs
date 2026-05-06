using GuimasBurguer2026App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguer2026App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IList<Hamburguer> Hamburguers { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Hamburguers = new List<Hamburguer>()
            {
                new Hamburguer
                {
                    HamburguerId = 1,
                    Nome = "Beef Burger",
                    Descricao = "Hambúrguer simples: suculento, saboroso e delicioso.",
                    ImagemUri = "/imagens/beef-burger.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = true,
                    Preco = 19.00,
                },
                new Hamburguer
                {
                    HamburguerId = 2,
                    Nome = "Canoe Burger",
                    Descricao = "Delicioso hambúrguer com batata canoa crocante. Uma explosão de sabores em cada mordida!",
                    ImagemUri = "/imagens/beef-burger-canoe-potatoes.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = false,
                    Preco = 29.00,
                },
                new Hamburguer
                {
                    HamburguerId = 3,
                    Nome = "Pepper Burger",
                    Descricao = "Hambúrguer irresistível com pimentão: sabor picante e suculento em cada pedaço!",
                    ImagemUri = "/imagens/beef-burger-peppers.jpg",
                    DataCadastro = DateTime.Now,
                    EntregaExpressa = true,
                    Preco = 39.00,
                },
            };
        }
    }
}
