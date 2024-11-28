using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Common.DataConstants;

namespace Watchlist.Models
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = StringLengthErrorMsg)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = StringLengthErrorMsg)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = StringLengthErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
