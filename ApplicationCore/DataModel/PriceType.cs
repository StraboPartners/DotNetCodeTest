namespace ApplicationCore.DataModel;

public record PriceType : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ExternalId { get; set; }
}
