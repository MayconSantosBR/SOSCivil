﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.EntitiesConfigurations
{
    public class OccurenceConfigurations : IEntityTypeConfiguration<Occurrence>
    {
        public void Configure(EntityTypeBuilder<Occurrence> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasMany(r => r.RequestItem)
                .WithOne(ri => ri.Occurrence)
                .HasForeignKey(ri => ri.OccurrenceId);

            builder.ToTable("Occurences");

        }
    }
}
