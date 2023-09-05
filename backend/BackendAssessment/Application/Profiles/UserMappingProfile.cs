using AutoMapper;
using Backend.Application.DTOs.Auth;
using Backend.Application.Contract.Authentication;
using Backend.Application.DTOs.Users;
using Backend.Application.Features.Auth.Requests.Commands;
using Backend.Application.Features.Auth.Requests.Queries;
using Backend.Domain.Entities;

namespace Backend.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<RegisterCommand, User>();
        CreateMap<LoginRequest, LoginQuery>();
        CreateMap<User, UserDto>().ReverseMap();
    }
}