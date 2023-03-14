namespace ApplicationCore.DataModel;

public record Product : BaseEntity
{
    public string ProductNumber { get; set; } = null!;
    public string? Name { get; set; }

    public string UnitOfMeasureName { get; set; } = null!;
    public UnitOfMeasure UnitOfMeasure { get; set; } = null!;

    public int MinimumOrderQuantity { get; set; } = 1;

    public List<Price> Prices { get; set; } = new();

}
