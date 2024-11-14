using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.DataModels
{
    public class User : IdentityUser
    {
        public IEnumerable<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
