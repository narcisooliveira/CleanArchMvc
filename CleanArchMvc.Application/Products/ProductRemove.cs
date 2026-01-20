using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products;

public class ProductRemove : ProductBase, IRequestHandler<ProductRemoveCommand, Product>
{
    public ProductRemove(IProductRepository productRepository) : base(productRepository) { }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await ProductRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

        await ProductRepository.RemoveAsync(product, cancellationToken);

        return product;
    }
}

public class ProductRemoveCommand : IRequest<Product>
{
    public int Id { get; set; }

    public ProductRemoveCommand(int id)
    {
        Id = id;
    }
}
