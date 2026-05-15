using CleanApi.Application.Common;
using CleanApi.Application.Products.DTOs;
using MediatR;

namespace CleanApi.Application.Products.Queries;

public sealed record GetProductsQuery(int Page = 1, int PageSize = 10) : IRequest<PagedResult<ProductDto>>;
