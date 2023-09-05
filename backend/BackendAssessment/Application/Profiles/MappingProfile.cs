using Application.DTO.Category.DTO;
using Application.DTO.Product.DTO;
using AutoMapper;
using Domain.Entites;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<ProductCreateDTO, Product>().ReverseMap();
            CreateMap<ProductResponseDTO, Product>().ReverseMap();



            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryResponseDTO, Category>().ReverseMap();
        }
    }
}
