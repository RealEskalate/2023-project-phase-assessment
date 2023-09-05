

using Application.DTO.CategoryDTO;
using Application.DTO.ProductDTO;
using Domain.Entites;

namespace Application.Profiles;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile(){
        CreateMap<Product, ProductListDTO>().ReverseMap();
        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Product, ProductDetailDTO>().ReverseMap();
        CreateMap<Product, UpdateProductDTO>().ReverseMap();
        
        CreateMap<Category, UpdateCategoryDTO>().ReverseMap();



        
        

    }
    
}