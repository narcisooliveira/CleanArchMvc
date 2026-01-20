using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products;

public class ProductUpdate : ProductBase, IRequestHandler<ProductUpdateCommand, Product>
{
    public ProductUpdate(IProductRepository productRepository) : base(productRepository)
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

public class ProductUpdateCommand : ProductCommand
{
    public int Id { get; set; }
}