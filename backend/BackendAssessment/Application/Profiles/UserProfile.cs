using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BackendAssessment.Application.DTOs.Authentication;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Profiles;

public class UserProfile : Profile

{
    public UserProfile()
    {
        CreateMap<User, RegisterUserDto>().ReverseMap();
        CreateMap<RegisterUserDto, User>().ReverseMap();
    }
}