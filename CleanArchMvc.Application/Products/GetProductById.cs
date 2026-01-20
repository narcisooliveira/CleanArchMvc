using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products;

public class GetProductById : ProductBase, IRequestHandler<GetProductByIdQuery, Product>
{
    public GetProductById(IProductRepository productRepository) : base(productRepository) { }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await ProductRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

        return product;
    }
}

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}