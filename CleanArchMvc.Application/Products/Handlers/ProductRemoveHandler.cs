using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductRemoveHandler : ProductBaseHandler, IRequestHandler<ProductRemoveCommand, Product>
{
    public ProductRemoveHandler(IProductRepository productRepository) : base(productRepository)
    {
    }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await ProductRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

        await ProductRepository.RemoveAsync(product, cancellationToken);

        return product;
    }
}
