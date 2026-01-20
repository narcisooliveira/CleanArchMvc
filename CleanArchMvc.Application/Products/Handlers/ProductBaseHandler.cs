using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers;

public abstract class ProductBaseHandler
{
    private readonly IProductRepository _productRepository;

    protected ProductBaseHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    protected IProductRepository ProductRepository => _productRepository;
}
