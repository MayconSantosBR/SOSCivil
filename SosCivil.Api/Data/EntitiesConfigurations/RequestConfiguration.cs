using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Status)
                .IsRequired();

            builder.Property(r => r.RequestDate)
                .IsRequired();
            
            builder.Property(r => r.DeliveryDate)
                .IsRequired(false);

            builder.HasMany(r => r.RequestItems)
                .WithOne(ri => ri.Request)
                .HasForeignKey(ri => ri.RequestId);

            builder.ToTable("Requests");




        }
    }
}
