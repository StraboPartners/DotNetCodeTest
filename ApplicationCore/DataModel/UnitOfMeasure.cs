namespace ApplicationCore.DataModel;

public record UnitOfMeasure : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ExternalId { get; set; }
}
