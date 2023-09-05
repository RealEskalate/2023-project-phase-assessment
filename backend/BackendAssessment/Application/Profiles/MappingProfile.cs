using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catagory;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        protected internal MappingProfile()
        {
            #region Catagory Mapping
            CreateMap<Catagory, CatagoryDto>().ReverseMap();
            CreateMap<Catagory, CatagoryListDto>().ReverseMap();
            CreateMap<Catagory, CreateCatagoryDto>().ReverseMap();
            CreateMap<Catagory, UpdateCatagoryDto>().ReverseMap();
            #endregion

            #region Product Mapping
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductsByCatagoryDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            #endregion
        }
    }
}