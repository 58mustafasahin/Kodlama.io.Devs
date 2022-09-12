using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserSocialMediaAddressConfiguration : IEntityTypeConfiguration<UserSocialMediaAddress>
    {
        public void Configure(EntityTypeBuilder<UserSocialMediaAddress> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Url).HasMaxLength(500).IsRequired();
        }
    }
}
