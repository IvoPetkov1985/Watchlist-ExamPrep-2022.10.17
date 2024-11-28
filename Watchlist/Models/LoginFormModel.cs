using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Common.DataConstants;

namespace Watchlist.Models
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [Display(Name = UsernameDisplayText)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
