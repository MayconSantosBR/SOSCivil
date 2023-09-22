using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PersonType)
                .IsRequired();

            builder.Property(p => p.CpfCnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(p => p.Cellphone)
                .IsRequired(false)
                .HasMaxLength(15);

            builder.HasMany(p => p.Establishments)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId);
            
            builder.HasMany(p => p.Occurrences)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId);

            builder.ToTable("Persons");

            
        }
    }
}
