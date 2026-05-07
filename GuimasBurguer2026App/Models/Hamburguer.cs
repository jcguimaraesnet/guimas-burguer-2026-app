using System.ComponentModel.DataAnnotations;

namespace GuimasBurguer2026App.Models
{
    public class Hamburguer
    {
        public int HamburguerId { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem")]
        public string ImagemUri { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Display(Name = "Entrega Expressa")]
        public bool EntregaExpressa { get; set; }

        public string EntregaExpressaFormatada => EntregaExpressa ? "Sim" : "Não";

        [Display(Name = "Disponível desde")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DataCadastro { get; set; }
    }
}
