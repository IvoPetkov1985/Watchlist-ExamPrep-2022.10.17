using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Constants.DataConstants;

namespace Watchlist.Models
{
    public class MovieFormModel
    {
        [Required]
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength, ErrorMessage = MovieInputErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(MovieDirectorMaxLength, MinimumLength = MovieDirectorMinLength, ErrorMessage = MovieInputErrorMessage)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [StringLength(MovieImageUrlMaxLength, ErrorMessage = MovieImageUrlTooLong)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), MovieRatingMinValue, MovieRatingMaxValue, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
