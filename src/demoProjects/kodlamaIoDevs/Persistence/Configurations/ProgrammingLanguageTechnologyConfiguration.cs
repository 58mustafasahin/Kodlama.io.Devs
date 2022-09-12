using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ProgrammingLanguageTechnologyConfiguration : IEntityTypeConfiguration<ProgrammingLanguageTechnology>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguageTechnology> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds = { new(1, "ASP.NET", 1), new(2, "WPF", 1), new(3, "Sprint", 2), new(4, "JSP", 2) };
            builder.HasData(programmingLanguageTechnologyEntitySeeds);
        }
    }
}
