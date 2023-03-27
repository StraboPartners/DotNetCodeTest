using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Database;

public sealed class PriceTypeConfiguration : BaseEntityConfiguration<PriceType>
{
    public override void Configure(EntityTypeBuilder<PriceType> builder)
    {
        base.Configure(builder);

        builder.HasKey(priceType => priceType.Name);

        builder.Property(priceType => priceType.Name)
            .HasMaxLength(20);

        builder.Property(priceType => priceType.Description)
            .HasMaxLength(80);

        builder.Property(priceType => priceType.ExternalId)
            .HasMaxLength(20);
    }
}
