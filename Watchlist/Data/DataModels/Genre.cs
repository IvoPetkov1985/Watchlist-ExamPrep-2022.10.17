using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Constants.DataConstants;

namespace Watchlist.Data.DataModels
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
