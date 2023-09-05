using Application.DTOs.Category;
using AutoMapper;
using Domain.Entites.Categories;

namespace Application.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<CategoryDetailsDto, Category>().ReverseMap();
    }
    
}