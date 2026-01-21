using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _productContext;

    public ProductRepository(ApplicationDbContext context)
        => _productContext = context;
   
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        await _productContext.AddAsync(product, cancellationToken);
        await _productContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _productContext.Products
            .Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<IEnumerable<Product>> GetProductAsync(CancellationToken cancellationToken)    
        => await _productContext.Products.ToListAsync(cancellationToken);    

    public async Task<Product> RemoveAsync(Product product, CancellationToken cancellationToken)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync(cancellationToken);
        return product;
    }
}
