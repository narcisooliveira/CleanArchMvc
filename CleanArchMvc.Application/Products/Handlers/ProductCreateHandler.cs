using AutoMapper;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductCreateHandler : ProductBaseHandler, IRequestHandler<ProductCreateCommand, Product>
{
    private readonly IMapper _mapper;

    public ProductCreateHandler(IProductRepository productRepository, IMapper mapper) : base(productRepository)
    {
        _mapper = mapper;
    }

    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await ProductRepository.CreateAsync(product, cancellationToken);
        return product;
    }
}
