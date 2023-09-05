using Application.DTOs.Product;
using AutoMapper;
using Domain.Entites.Products;

namespace Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<ProductDetailsDto, Product>().ReverseMap();
    }
}