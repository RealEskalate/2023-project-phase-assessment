using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.Features.Categories.Request.Command;
using Application.DTOs.User;
using Application.Features.Users.Request.Command;
using Application.Features.Products.Request.Command;
using Application.DTOs.Product;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryRetriveDto, CreateCategoryCommand>().ReverseMap();
            CreateMap<CreateUserDto, CreateUserCommand>().ReverseMap();
            CreateMap<CreateProductDTO, CreateProductCommand>().ReverseMap();

        }
    }
}
