using CleanArchMvc.Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
        => _sender = sender;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _sender.Send(new GetProductsQuery());
        return View(products);
    }
}
