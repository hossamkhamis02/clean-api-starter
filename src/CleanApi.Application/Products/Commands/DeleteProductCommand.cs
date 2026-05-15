using CleanApi.Application.Common;
using MediatR;

namespace CleanApi.Application.Products.Commands;

public sealed record DeleteProductCommand(Guid Id) : IRequest<Result>;
