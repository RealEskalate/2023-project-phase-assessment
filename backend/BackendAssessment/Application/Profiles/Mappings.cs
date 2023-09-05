using Application.Dto.Category;
using Application.Dto.Product;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreationDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
    }
    
}