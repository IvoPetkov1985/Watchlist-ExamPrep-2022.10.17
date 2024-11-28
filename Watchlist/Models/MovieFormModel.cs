using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Common.DataConstants;

namespace Watchlist.Models
{
    public class MovieFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMsg)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength, ErrorMessage = StringLengthErrorMsg)]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [Range(typeof(decimal), RatingMinValue, RatingMaxValue, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
