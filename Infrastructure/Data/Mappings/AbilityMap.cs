using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class AbilityMap : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder.ToTable("Ability");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.Description).HasColumnType("nvarchar").HasMaxLength(150);
        }
    }
}
