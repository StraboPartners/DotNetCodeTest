using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Database;

public class PriceConfiguration : BaseEntityConfiguration<Price>
{
    public override void Configure(EntityTypeBuilder<Price> builder)
    {
        base.Configure(builder);

        builder.HasIndex(price => new { price.ProductId, price.PriceTypeName, price.FromDate, price.QuantityFrom });

        builder.HasOne(price => price.Product)
            .WithMany();

        builder.HasOne(price => price.PriceType)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(price => price.UnitOfMeasure)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
