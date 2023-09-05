using Application.Dtos;
using Domain.Entities;
using AutoMapper;
using Application.Dtos.Auth;

namespace Application.Profiles;

public class MappingProfile : Profile{
    public MappingProfile()
    {
        //category
        CreateMap<CreateCategoryDto,Category>().ReverseMap();
        CreateMap<UpdateCategoryDto,Category>().ReverseMap();
        CreateMap<CategoryDto,Category>().ReverseMap();

        //product
        CreateMap<CreateProductDto,Product>().ReverseMap();
        CreateMap<UpdateProductDto,Product>().ReverseMap();
        CreateMap<ProductDto,Product>().ReverseMap();

        //user
        CreateMap<CreateUserDto,User>().ReverseMap();
        CreateMap<UpdateUserDto,User>().ReverseMap();
        CreateMap<UserDto,User>().ReverseMap();
        CreateMap<RegisterUserDto,User>().ReverseMap();
        CreateMap<LoginUserDto,User>().ReverseMap();
              
    }
}