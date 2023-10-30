using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class CobradeConfiguration : IEntityTypeConfiguration<Cobrade>
    {
        public void Configure(EntityTypeBuilder<Cobrade> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CobradeCode)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(e => e.CobradeType)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder.ToTable("Cobrades");
        }
    }
}
