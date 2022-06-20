using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Gênero")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Investimento")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}