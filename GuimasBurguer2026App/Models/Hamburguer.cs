using System.ComponentModel.DataAnnotations;

namespace GuimasBurguer2026App.Models
{
    public class Hamburguer
    {
        public int HamburguerId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Nome' obrigatório.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Campo 'Nome' deve conter entre 10 e 50 caracterres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Descrição' obrigatório.")]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "Campo 'Descrição' deve conter entre 50 e 100 caracterres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Imagem' obrigatório.")]
        [Display(Name = "Imagem")]
        public string ImagemUri { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo 'Preço' obrigatório.")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Display(Name = "Entrega Expressa")]
        public bool EntregaExpressa { get; set; }

        public string EntregaExpressaFormatada => EntregaExpressa ? "Sim" : "Não";

        [Display(Name = "Disponível desde")]
        [Required(ErrorMessage = "Campo 'Disponível desde' obrigatório.")]
        [DataType("month")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Marca")]
        public int? MarcaId { get; set; }
    }
}
