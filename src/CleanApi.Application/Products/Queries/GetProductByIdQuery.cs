using CleanApi.Application.Common;
using CleanApi.Application.Products.DTOs;
using MediatR;

namespace CleanApi.Application.Products.Queries;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductDto>>;
