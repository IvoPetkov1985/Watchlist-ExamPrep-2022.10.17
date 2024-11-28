using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Configurations;
using Watchlist.Data.DataModels;

namespace Watchlist.Data
{
    public class WatchlistDbContext : IdentityDbContext<User>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Movie> Movies { get; set; } = null!;

        public DbSet<UserMovie> UsersMovies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new UserMovieConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
