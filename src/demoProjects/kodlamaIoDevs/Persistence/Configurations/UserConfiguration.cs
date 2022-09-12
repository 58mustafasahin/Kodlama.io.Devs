using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.PasswordSalt);
            builder.Property(p => p.PasswordHash);
            builder.Property(p => p.Status);
            builder.Property(p => p.AuthenticatorType);
        }
    }
}
