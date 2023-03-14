using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Database;

internal class UnitOfMeasureConfiguration : BaseEntityConfiguration<UnitOfMeasure>
{
    public override void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        base.Configure(builder);

        builder.HasKey(uom => uom.Name);

        builder.Property(uom => uom.Description)
            .HasMaxLength(80);

        builder.Property(uom => uom.ExternalId)
            .HasMaxLength(4);
    }
}
