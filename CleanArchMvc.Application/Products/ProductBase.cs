using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products;

public abstract class ProductBase
{
    private readonly IProductRepository _productRepository;

    protected ProductBase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    protected IProductRepository ProductRepository => _productRepository;
}
