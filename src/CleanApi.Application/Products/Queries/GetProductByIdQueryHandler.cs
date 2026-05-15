using CleanApi.Application.Common;
using CleanApi.Application.Products.DTOs;
using CleanApi.Domain.Entities;
using CleanApi.Domain.Interfaces;
using MediatR;

namespace CleanApi.Application.Products.Queries;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;

    public GetProductByIdQueryHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Result<ProductDto>.Failure($"Product with ID {request.Id} not found.");

        var dto = new ProductDto(
            product.Id,
            product.Name,
            product.SKU,
            product.Price,
            product.CategoryId,
            product.Category?.Name ?? string.Empty,
            product.CreatedAt,
            product.UpdatedAt);

        return Result<ProductDto>.Success(dto);
    }
}
