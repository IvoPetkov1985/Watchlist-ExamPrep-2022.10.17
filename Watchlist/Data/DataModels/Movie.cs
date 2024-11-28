using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Data.Common.DataConstants;

namespace Watchlist.Data.DataModels
{
    [Comment("The movie with its characteristics")]
    public class Movie
    {
        [Key]
        [Comment("Movie identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Movie title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DirectorMaxLength)]
        [Comment("The director(s) of the movie")]
        public string Director { get; set; } = string.Empty;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("The official image of the movie")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("The rating of the movie between 0 and 10 points")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Genre identifier")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public IEnumerable<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
