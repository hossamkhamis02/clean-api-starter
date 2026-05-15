using CleanApi.Domain.Common;

namespace CleanApi.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
