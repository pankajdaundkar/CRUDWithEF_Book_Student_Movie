using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWithEF.Models
{
    [Table("movie")]
    public class Movie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]

        public DateTime release_date { get; set; }
        [Required]
        public string? movie_type { get; set; }
        [Required]
        public string? star_name { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
