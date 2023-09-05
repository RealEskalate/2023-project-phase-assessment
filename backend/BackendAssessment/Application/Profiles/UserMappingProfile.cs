using AutoMapper;
using ProductHub.Application.DTOs.Authentication;
using ProductHub.Domain.Entites;
namespace ProductHub.Application.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
        {
            
            CreateMap<User, UserDto>();;
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();

        }
}
