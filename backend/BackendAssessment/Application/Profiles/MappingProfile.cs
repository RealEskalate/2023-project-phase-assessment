using Application.Dtos.Category;
using Application.Dtos.Product;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserEntity, UserRequestDto>().ReverseMap();
            CreateMap<UserEntity, UserResponseDto>().ReverseMap();

            CreateMap<ProductEntity, ProductRequestDto>().ReverseMap();
            CreateMap<ProductEntity, ProductResponseDto>().ReverseMap();

            CreateMap<CategoryEntity, CategoryRequestDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryResponseDto>().ReverseMap();
        }

    }
}