using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class EstablishmentConfiguration : IEntityTypeConfiguration<Establishment>
    {
        public void Configure(EntityTypeBuilder<Establishment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Neighborhood)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(8);

            builder.HasMany(e => e.Occurrences)
                .WithOne(o => o.Establishment)
                .HasForeignKey(o => o.EstablishmentId);

            builder.ToTable("Establishments");

        }
    }
}
