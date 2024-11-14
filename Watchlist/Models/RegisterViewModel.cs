using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Constants.DataConstants;

namespace Watchlist.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(UserMailMaxLength, MinimumLength = UserMailMinLength)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(UserPwdMaxLength, MinimumLength = UserPwdMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
