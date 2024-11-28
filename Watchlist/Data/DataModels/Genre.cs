using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Common.DataConstants;

namespace Watchlist.Data.DataModels
{
    [Comment("The genre of the movie")]
    public class Genre
    {
        [Key]
        [Comment("Genre identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The name of the genre")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
