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
        }
    }
}
