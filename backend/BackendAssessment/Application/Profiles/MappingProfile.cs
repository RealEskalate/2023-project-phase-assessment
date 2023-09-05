using Application.Dtos.BookingDtos;
using Application.Dtos.CategoryDtos;
using Application.Dtos.ProductDto;
using Application.Dtos.UserDtos;
using Domain.Entites;

namespace Application.Profiles;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile()
    {   
        // User
        CreateMap<User, CreateUserDto>().ReverseMap();
        
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        
        CreateMap<Booking, BookingResponseDto>().ReverseMap();

        CreateMap<Category, CreateCategoryDto>().ReverseMap();
    }
}    