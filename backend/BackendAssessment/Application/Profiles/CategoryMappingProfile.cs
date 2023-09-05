using AutoMapper;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Domain.Entities;

namespace ProductHub.Application.Profiles;

public class CategoriesMappingProfile: Profile{
    public CategoriesMappingProfile()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, DeleteCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }

}