using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class GetProductsHandler : ProductBaseHandler, IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    public GetProductsHandler(IProductRepository productRepository) : base(productRepository)
    {
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        => await ProductRepository.GetProductAsync(cancellationToken);
}
