using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Database;

internal class ProductConfiguration : BaseEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.Property(product => product.ProductNumber)
            .HasMaxLength(48);

        builder.HasIndex(product => product.ProductNumber)
            .IsUnique(false);

        builder.Property(product => product.Name)
            .HasMaxLength(80);

        builder.HasOne(product => product.UnitOfMeasure)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
