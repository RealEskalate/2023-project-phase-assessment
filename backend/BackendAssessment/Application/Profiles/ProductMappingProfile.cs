using AutoMapper;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Domain.Entities;

namespace ProductHub.Application.Profiles;

public class ProductsMappingProfile: Profile{
    public ProductsMappingProfile()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, DeleteProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    }

}