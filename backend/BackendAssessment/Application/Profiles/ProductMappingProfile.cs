using AutoMapper;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Domain.Entites;
namespace ProductHub.Application.Profiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
        {
            
            CreateMap<Product, ProductDto>();;
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

        }
}
