namespace ApplicationCore.DataModel;

public record UnitOfMeasure : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ExternalId { get; set; }
}
