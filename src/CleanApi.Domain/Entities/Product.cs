using CleanApi.Domain.Common;

namespace CleanApi.Domain.Entities;

public sealed class Product : BaseEntity
{
    public string Name { get; set; } = default!;
    public string SKU { get; set; } = default!;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
