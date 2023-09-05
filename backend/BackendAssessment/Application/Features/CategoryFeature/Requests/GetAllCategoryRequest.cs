using Application.DTO.CategoryDTO;
using Application.DTO.ProductDTO;
using Application.Responses;
using Domain.Entites;
using MediatR;

namespace Application.Features.CategoryFeature.Requests;

public class GetAllCategoryRequest : IRequest<BaseCommandResponse<List<CategoryListDTO>>>{
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;

}