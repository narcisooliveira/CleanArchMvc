using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products;

public class GetProducts : ProductBase, IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
{
    private readonly IMapper _mapper;

    public GetProducts(IProductRepository productRepository, IMapper mapper) : base(productRepository)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var productEntity = await ProductRepository.GetProductAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
    }
}

public class GetProductsQuery : IRequest<IEnumerable<ProductDTO>> { }