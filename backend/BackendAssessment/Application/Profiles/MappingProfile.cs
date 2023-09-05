using AutoMapper;
using BackendAssessment.Application.DTOs.Auth;
using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Application.DTOs.ProductDtos;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<User, RegisterRequestDto>().ReverseMap();
        CreateMap<User, LoginRequestDto>().ReverseMap();
        CreateMap<User, LoginResponseDto>().ReverseMap();
    }
}

