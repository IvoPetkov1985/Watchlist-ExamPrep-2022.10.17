using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Data.Constants.DataConstants;

namespace Watchlist.Data.DataModels
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(MovieDirectorMaxLength)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [MaxLength(MovieImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public IEnumerable<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
