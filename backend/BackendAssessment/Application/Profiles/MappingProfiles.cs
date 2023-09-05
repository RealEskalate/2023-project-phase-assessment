using Application.Features.Authentication.Dtos;
using Application.Features.Categories.Dtos;
using Application.Features.Products.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();

        CreateMap<RegisterUserDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
