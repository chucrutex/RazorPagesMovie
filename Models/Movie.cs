using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)] // especifica o tamanho máximo e mínimo do campo
        [Display(Name = "Título")] // especifica o texto que denomina o campo
        [Required] // indica campo obrigatório
        public string Title { get; set; } = string.Empty; // inicializa o campo em branco

        [Display(Name = "Data de lançamento")] // especifica o texto que denomina o campo
        [DataType(DataType.Date)]// especifica que o campo é do dipo data (sem hora)
        public DateTime ReleaseDate { get; set; }

        // investimento do filme
        [Range(1, 100)] // especifica que é um número entre 1 e 100
        [DataType(DataType.Currency)] // especifica que é um número do tipo moeda
        [Display(Name = "Investimento")] // especifica o texto que denomina o campo
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Gênero")] // especifica o texto que denomina o campo
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] // especifica a ER que rege o campo
        [Required] // indica campo obrigatório
        [StringLength(30)] // especifica o tamanho máximo do campo
        public string Genre { get; set; } = string.Empty; // inicializa o campo em branco

        // avaliação do filme
        [Display(Name = "Classificação")] // especifica o texto que denomina o campo
        [Required] // indica campo obrigatório
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")] // especifica a ER que rege o campo
        [StringLength(5)] // especifica o tamanho máximo do campo
        public string Rating { get; set; } = string.Empty; // inicializa o campo em branco

    }
}