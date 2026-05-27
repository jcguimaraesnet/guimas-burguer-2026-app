using GuimasBurguer2026App.Models;

namespace GuimasBurguer2026App.Services.Memory;

public class HamburguerService : IHamburguerService
{
    private IList<Hamburguer> _hamburguers;

    public HamburguerService()
    {
        CarregarListaInicial();
    }

    public IList<Hamburguer> ObterTodos()
    {
        return _hamburguers;
    }

    public IList<Hamburguer> ObterPorNome(string nome, string descricao)
    {
        IEnumerable<Hamburguer> query = _hamburguers;

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(h => h.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(descricao))
        {
            query = query.Where(h => h.Descricao.Contains(descricao, StringComparison.OrdinalIgnoreCase));
        }

        return query.ToList();
    }

    public Hamburguer Obter(int id)
    {
        return _hamburguers.Single(item => item.HamburguerId == id);
    }

    private void CarregarListaInicial()
    {
        _hamburguers = new List<Hamburguer>()
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

    public void Incluir(Hamburguer hamburguer)
    {
        var proximoNumero = _hamburguers.Max(item => item.HamburguerId) + 1;
        hamburguer.HamburguerId = proximoNumero;
        _hamburguers.Add(hamburguer);
    }

    public void Alterar(Hamburguer hamburguerAlterado)
    {
        var hamburguerExistente = Obter(hamburguerAlterado.HamburguerId);
        hamburguerExistente.Nome = hamburguerAlterado.Nome;
        hamburguerExistente.Descricao = hamburguerAlterado.Descricao;
        hamburguerExistente.Preco = hamburguerAlterado.Preco;
        hamburguerExistente.EntregaExpressa = hamburguerAlterado.EntregaExpressa;
        hamburguerExistente.DataCadastro = hamburguerAlterado.DataCadastro;
        hamburguerExistente.ImagemUri = hamburguerAlterado.ImagemUri;
    }

    public void Excluir(int id)
    {
        var hamburguerExistente = Obter(id);
        _hamburguers.Remove(hamburguerExistente);

    }

    public IList<Marca> ObterTodasMarcas()
    {
        throw new NotImplementedException();
    }
}
