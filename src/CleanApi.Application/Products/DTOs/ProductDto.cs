namespace CleanApi.Application.Products.DTOs;

public sealed record CreateProductDto(string Name, string SKU, decimal Price, Guid CategoryId);

public sealed record ProductDto(
    Guid Id,
    string Name,
    string SKU,
    decimal Price,
    Guid CategoryId,
    string CategoryName,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

public sealed record UpdateProductDto(string Name, string SKU, decimal Price, Guid CategoryId);
