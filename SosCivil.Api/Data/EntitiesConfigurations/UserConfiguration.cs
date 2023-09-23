using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired()
                .HasMaxLength(32);

            builder.Property(x => x.Email).IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Password).IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Person)
                .WithMany()
                .HasForeignKey(x => x.PersonId)
                .IsRequired();

            builder.HasMany(x => x.Occurrences)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.ToTable("Users");

        }
    }
}
