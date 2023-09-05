using Application.DTOs.Category;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class ProfileMappings : Profile
{
    public ProfileMappings()
    {
        CreateMap<ProductDto, ProductEntity>().ReverseMap();
        CreateMap<ProductReqResDto, ProductEntity>().ReverseMap();
        CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
        CreateMap<CategoryReqResDto, CategoryEntity>().ReverseMap();
        CreateMap<CreateProductDto, ProductEntity>().ReverseMap();
    }
}