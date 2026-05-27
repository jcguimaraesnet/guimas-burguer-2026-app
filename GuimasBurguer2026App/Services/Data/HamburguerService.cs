using GuimasBurguer2026App.Data;
using GuimasBurguer2026App.Models;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguer2026App.Services.Data;

public class HamburguerService : IHamburguerService
{
    private HamburguerDbContext _context;

    public HamburguerService(HamburguerDbContext context)
    {
        _context = context;
    }

    public void Alterar(Hamburguer hamburguer)
    {
        var hamburguerExistente = Obter(hamburguer.HamburguerId);
        hamburguerExistente.Nome = hamburguer.Nome;
        hamburguerExistente.Descricao = hamburguer.Descricao;
        hamburguerExistente.Preco = hamburguer.Preco;
        hamburguerExistente.EntregaExpressa = hamburguer.EntregaExpressa;
        hamburguerExistente.DataCadastro = hamburguer.DataCadastro;
        hamburguerExistente.ImagemUri = hamburguer.ImagemUri;
        hamburguerExistente.MarcaId = hamburguer.MarcaId;

        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var hamburguerExistente = Obter(id);
        _context.Hamburguer.Remove(hamburguerExistente);

        _context.SaveChanges();
    }

    public void Incluir(Hamburguer hamburguer)
    {
        _context.Hamburguer.Add(hamburguer);
        _context.SaveChanges();
    }

    public Hamburguer Obter(int id)
    {
        return _context.Hamburguer
            .SingleOrDefault(item => item.HamburguerId == id);
    }

    public IList<Hamburguer> ObterComFiltro(string nome, string descricao)
    {
        IQueryable<Hamburguer> query = _context.Hamburguer;

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(h =>
            EF.Functions.Collate(h.Nome, "Latin1_General_CI_AI")
            .Contains(nome));
        }

        if (!string.IsNullOrEmpty(descricao))
        {
            query = query.Where(h =>
                EF.Functions.Collate(h.Descricao,
                     "Latin1_General_CI_AI")
                     .Contains(descricao));
        }

        return query.ToList();

    }

    public IList<Marca> ObterTodasMarcas()
    {
        return _context.Marca.ToList();
    }

    public IList<Hamburguer> ObterTodos()
    {
        return _context.Hamburguer.ToList();
    }
}
