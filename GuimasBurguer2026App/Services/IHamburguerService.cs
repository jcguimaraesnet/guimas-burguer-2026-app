using GuimasBurguer2026App.Models;

namespace GuimasBurguer2026App.Services
{
    public interface IHamburguerService
    {
        IList<Hamburguer> ObterTodos();
        Hamburguer Obter(int id);
        void Incluir(Hamburguer hamburguer);
        void Salvar(Hamburguer hamburguer);
        void Excluir(int id);
        IList<Marca> ObterTodasMarcas();
        IList<Categoria> ObterTodasCategorias();
        IList<Hamburguer> ObterComFiltro(string nome, string descricao);
    }
}
