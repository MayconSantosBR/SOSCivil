using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UnityOfMeasurement)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.TotalQuantityWithUnity)
                .IsRequired();

            builder.ToTable("Items");
        }
    }
}
