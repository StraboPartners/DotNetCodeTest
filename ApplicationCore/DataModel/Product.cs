namespace ApplicationCore.DataModel;

public record Product : BaseEntity
{
    public required string ProductNumber { get; set; }
    public string? Name { get; set; }

    public string UnitOfMeasureName { get; set; } = null!;
    public UnitOfMeasure UnitOfMeasure { get; set; } = null!;

    public int MinimumOrderQuantity { get; set; } = 1;

}
