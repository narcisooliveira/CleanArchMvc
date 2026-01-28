using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products;
using CleanArchMvc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;

    public ProductsController(ISender sender, IMapper mapper, ICategoryService categoryService)
    {
        _sender = sender;
        _mapper = mapper;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _sender.Send(new GetProductsQuery());
        return View(products);
    }

    [HttpGet()]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _sender.Send(productCreateCommand);
            return RedirectToAction(nameof(Index));
        }
        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
            return NotFound();

        var product = await _sender.Send(new GetProductByIdQuery(id.Value));
        if (product is null)
            return NotFound();

        ViewBag.Categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
        var productDTO = _mapper.Map<ProductDTO>(product);  
        return View(productDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO product)
    {
        if (ModelState.IsValid)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
            await _sender.Send(productUpdateCommand);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return NotFound();

        var product = await _sender.Send(new GetProductByIdQuery(id.Value));
        if (product is null)
            return NotFound();

        var productDTO = _mapper.Map<ProductDTO>(product);
        return View(productDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _sender.Send(new ProductRemoveCommand(id));
        return RedirectToAction(nameof(Index));
    }
}
