using AutoMapper;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Domain.Entites;
namespace ProductHub.Application.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
        {
            
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
}
