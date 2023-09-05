using Application.DTO.CategoryDTO;
using Application.DTO.ProductCategoryDTO;
using Application.DTO.ProductDTO;
using Application.DTO.UserDTO;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
