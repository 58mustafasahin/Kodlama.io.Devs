using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Token).HasMaxLength(500);
            builder.Property(p => p.Expires);
            builder.Property(p => p.Created);
            builder.Property(p => p.CreatedByIp).HasMaxLength(20);
            builder.Property(p => p.Revoked);
            builder.Property(p => p.RevokedByIp);
            builder.Property(p => p.ReplacedByToken);
            builder.Property(p => p.ReasonRevoked);
        }
    }
}
