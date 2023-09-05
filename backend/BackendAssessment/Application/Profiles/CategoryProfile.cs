using AutoMapper;
using BackendAssessment.Application.DTOs.Authentication;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<User, RegisterUserDto>().ReverseMap();
        CreateMap<RegisterUserDto, User>().ReverseMap();
    }
};