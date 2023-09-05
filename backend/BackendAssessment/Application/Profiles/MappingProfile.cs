using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User Mapping
        CreateMap<UserRequestDto, UserEntity>().ReverseMap().ForAllMembers(options 
            =>options.Condition((src, dest, srcMember) =>
            {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
        
        CreateMap<UserResponseDto, UserEntity>().ReverseMap().ForAllMembers(options 
            =>options.Condition((src, dest, srcMember) =>
            {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
        
        // Product Mapping
        CreateMap<ProductRequestDto, ProductEntity>().ReverseMap().ForAllMembers(options 
            =>options.Condition((src, dest, srcMember) =>
            {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
        
        CreateMap<ProductResponseDto, ProductEntity>().ReverseMap().ForAllMembers(options 
            =>options.Condition((src, dest, srcMember) =>
            {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
        
        // Category Mapping
        CreateMap<CategoryRequestDto, CategoryEntity>().ReverseMap().ForAllMembers(options 
            =>options.Condition((src, dest, srcMember) =>
            {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
        
        CreateMap<CategoryResponseDto, CategoryEntity>().ReverseMap().ForAllMembers(options 
            =>options.Condition((src, dest, srcMember) =>
            {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
    }
}