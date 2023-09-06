
using AutoMapper;

namespace Application.Profiles;
using Domain.Entities.Product;
using Application.DTOs.Product;
using Application.DTOs.Category;
using Domain.Entities.Category;

public class MappingProfile : Profile 
{

    public MappingProfile()
    {
        #region Product Mapping
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
          CreateMap<Product, UpdateProductDto>().ReverseMap();
          CreateMap<Product, IProductDto>().ReverseMap();
        #endregion
        #region Category Mapping
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, ICategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        #endregion
       

     
    }
}