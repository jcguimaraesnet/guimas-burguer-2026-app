using GuimasBurguer2026App.Data;
using GuimasBurguer2026App.Models;

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
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
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

    public IList<Hamburguer> ObterTodos()
    {
        return _context.Hamburguer.ToList();
    }
}
