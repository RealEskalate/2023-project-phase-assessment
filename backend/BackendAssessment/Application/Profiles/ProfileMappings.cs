using Application.DTO.Category;
using Application.DTO.Product;
using Application.DTO.User;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles;

public class ProfileMappings : Profile
{
    public ProfileMappings()
    {
        CreateMap<CreateUserDTO, User>().ReverseMap();
        CreateMap<GetUserDTO, User>().ReverseMap();
        CreateMap<UpdateUserDTO, User>().ReverseMap();

        CreateMap<CreateProductDTO, Product>().ReverseMap();
        CreateMap<GetProductDTO, Product>().ReverseMap();
        CreateMap<UpdateProductDTO, Product>().ReverseMap();

        CreateMap<CategoryDTO, Category>().ReverseMap();
    }
}