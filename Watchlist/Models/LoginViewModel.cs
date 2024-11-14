using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
