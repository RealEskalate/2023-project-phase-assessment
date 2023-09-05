using AutoMapper;
using Backend.Application.DTOs.Product;
using Backend.Domain.Entities;

namespace Backend.Application.Profiles.ProductMappingProfile;
public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<GetProducts, Product>().ReverseMap();
    }
}