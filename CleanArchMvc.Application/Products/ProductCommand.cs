using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products;

public abstract class ProductCommand : IRequest<Product>
{
    public string Name { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public decimal Price { get; protected set; }
    public int Stock { get; protected set; }
    public string Image { get; protected set; } = string.Empty;
    public int CategoryId { get; protected set; }
}
