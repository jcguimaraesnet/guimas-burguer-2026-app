namespace GuimasBurguer2026App.Models
{
    public class Hamburguer
    {
        public int HamburguerId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemUri { get; set; }
        public double Preco { get; set; }
        public bool EntregaExpressa { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
