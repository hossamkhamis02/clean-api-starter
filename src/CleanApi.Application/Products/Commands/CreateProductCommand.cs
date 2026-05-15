using CleanApi.Application.Common;
using CleanApi.Application.Products.DTOs;
using MediatR;

namespace CleanApi.Application.Products.Commands;

public sealed record CreateProductCommand(CreateProductDto Dto) : IRequest<Result<Guid>>;
