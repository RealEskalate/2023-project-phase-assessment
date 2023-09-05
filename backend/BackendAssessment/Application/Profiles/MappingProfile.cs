using Application.DTO;
using Application.DTO.UserDTO;
using Domain.Entites;

namespace Application.Profiles;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile(){
        
        CreateMap<Category, CategoryDTO>().ReverseMap();
        
        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();
        
    }
    
}