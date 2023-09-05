using AutoMapper;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Domain.Entites;
namespace ProductHub.Application.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
        {
            
            CreateMap<User, User>();;
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

        }
}
