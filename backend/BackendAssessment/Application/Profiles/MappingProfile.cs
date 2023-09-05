using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<User, UserProfileDto>().ReverseMap();
        
        CreateMap<Product, CreateProductDto>().ReverseMap();
        
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
    }
}