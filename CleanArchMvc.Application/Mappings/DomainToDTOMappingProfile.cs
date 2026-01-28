using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<ProductCreateCommand, ProductDTO>().ReverseMap();
        CreateMap<ProductCreateCommand, Product>().ReverseMap();
        CreateMap<ProductUpdateCommand, ProductDTO>().ReverseMap();
        CreateMap<ProductUpdateCommand, Product>().ReverseMap();
    }
}
