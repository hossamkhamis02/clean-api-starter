using CleanApi.Application.Common;
using CleanApi.Domain.Entities;
using CleanApi.Domain.Interfaces;
using MediatR;

namespace CleanApi.Application.Products.Commands;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Result.Failure($"Product with ID {request.Id} not found.");

        product.Name = request.Dto.Name;
        product.SKU = request.Dto.SKU;
        product.Price = request.Dto.Price;
        product.CategoryId = request.Dto.CategoryId;

        _productRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
