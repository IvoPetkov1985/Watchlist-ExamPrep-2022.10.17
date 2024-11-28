using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.DataModels
{
    [Comment("The mapping table between users and movies")]
    public class UserMovie
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [Comment("Movie identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
