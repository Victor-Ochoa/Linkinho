using Linkinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkinho.Infra.Repos.Mappings;

public class LinkMap : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Identificator).HasMaxLength(6).IsRequired();
        builder.HasIndex(x => x.Identificator);

        builder.Property(x => x.Url)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.CreateAt)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

        builder.Property(x => x.CountClick)
            .HasDefaultValue(0)
            .IsRequired();
    }
}
