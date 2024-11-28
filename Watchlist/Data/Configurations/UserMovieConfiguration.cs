using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchlist.Data.DataModels;

namespace Watchlist.Data.Configurations
{
    public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {
            builder.HasKey(um => new
            {
                um.UserId,
                um.MovieId
            });

            builder.HasOne(um => um.Movie)
                .WithMany(m => m.UsersMovies)
                .HasForeignKey(um => um.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(um => um.User)
                .WithMany(u => u.UsersMovies)
                .HasForeignKey(um => um.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
