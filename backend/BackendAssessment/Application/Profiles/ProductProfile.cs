using AutoMapper;
using BackendAssessment.Application.DTOs.Authentication;
using BackendAssessment.Application.Features.Product.DTO;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<User, RegisterUserDto>().ReverseMap();
        CreateMap<RegisterUserDto, User>().ReverseMap();
    }
}