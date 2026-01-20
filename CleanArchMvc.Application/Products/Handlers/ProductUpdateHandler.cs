using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductUpdateHandler : ProductBaseHandler, IRequestHandler<ProductUpdateCommand, Product>
{
    public ProductUpdateHandler(IProductRepository productRepository) : base(productRepository)
    {
    }

    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await ProductRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

        product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
        await ProductRepository.UpdateAsync(product, cancellationToken);
        return product;
    }
}
