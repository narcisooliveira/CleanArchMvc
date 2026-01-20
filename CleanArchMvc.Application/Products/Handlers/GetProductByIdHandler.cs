using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class GetProductByIdHandler : ProductBaseHandler, IRequestHandler<GetProductByIdQuery, Product>
{
    public GetProductByIdHandler(IProductRepository productRepository) : base(productRepository)
    {
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await ProductRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

        return product;
    }
}
