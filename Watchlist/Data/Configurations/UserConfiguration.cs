using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchlist.Data.DataModels;
using static Watchlist.Data.Constants.DataConstants;

namespace Watchlist.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(UserMailMaxLength)
                .IsRequired();
        }
    }
}
