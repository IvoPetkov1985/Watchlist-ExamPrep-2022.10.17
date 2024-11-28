using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchlist.Data.DataModels;

namespace Watchlist.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre()
            {
                Id = 1,
                Name = "Action"
            },
            new Genre()
            {
                Id = 2,
                Name = "Comedy"
            },
            new Genre()
            {
                Id = 3,
                Name = "Drama"
            },
            new Genre()
            {
                Id = 4,
                Name = "Horror"
            },
            new Genre()
            {
                Id = 5,
                Name = "Romantic"
            },
            new Genre()
            {
                Id = 6,
                Name = "Documentary"
            },
            new Genre()
            {
                Id = 7,
                Name = "Thriller"
            },
            new Genre()
            {
                Id = 8,
                Name = "Animation"
            },
            new Genre()
            {
                Id = 9,
                Name = "SciFi"
            },
            new Genre()
            {
                Id = 10,
                Name = "Biographic"
            });
        }
    }
}
