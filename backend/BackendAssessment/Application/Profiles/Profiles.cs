using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catergories;
using Application.DTOs.Products;
using Application.DTOs.Users;
using Application.Features.Auth.Requests.Commands;
using Application.Features.Auth.Requests.Queries;
using Application.Features.Users.Request.Command;



// using Application.DTOs.Auth;
using AutoMapper;
using Domain.Entites;
using Galacticos.Application.DTOs.Auth;

namespace Application.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Product, ProductDetailDto>().ReverseMap();
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<RegisterCommand, User>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UpdatePasswordTokenRequestDTO, User>().ReverseMap();
            CreateMap<UpdatePasswordTokenRequest, UpdatePasswordTokenRequestDTO>().ReverseMap();
            CreateMap<UpdatePasswordTokenRequest, User>();
        }
        
    }
}