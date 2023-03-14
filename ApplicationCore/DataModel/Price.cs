namespace ApplicationCore.DataModel;

public record Price : BaseEntity
{
    public required long ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public required string PriceTypeName { get; set; }
    public PriceType PriceType { get; set; } = null!;

    public decimal Amount { get; set; }

    public required string UnitOfMeasureName { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; } = null!;

    public int? QuantityFrom { get; set; }
    public int? QuantityTo { get; set; }

    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
}
