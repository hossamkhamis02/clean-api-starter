using CleanApi.Application.Common;
using CleanApi.Application.Products.DTOs;
using CleanApi.Domain.Entities;
using CleanApi.Domain.Interfaces;
using MediatR;

namespace CleanApi.Application.Products.Queries;

public sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResult<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;

    public GetProductsQueryHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.ListAllAsync(cancellationToken);
        var totalCount = await _productRepository.CountAsync(cancellationToken);

        var pagedItems = products
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.SKU,
                p.Price,
                p.CategoryId,
                p.Category?.Name ?? string.Empty,
                p.CreatedAt,
                p.UpdatedAt))
            .ToList();

        return new PagedResult<ProductDto>(pagedItems.AsReadOnly(), request.Page, request.PageSize, totalCount);
    }
}
