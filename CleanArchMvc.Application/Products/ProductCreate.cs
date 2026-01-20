using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products;

public class ProductCreate : ProductBase, IRequestHandler<ProductCreateCommand, Product>
{
    private readonly IMapper _mapper;

    public ProductCreate(IProductRepository productRepository, IMapper mapper) : base(productRepository)
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

public class ProductCreateCommand : ProductCommand { }