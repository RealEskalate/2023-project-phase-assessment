using Application.DTO.CategoryDTO;
using Application.Responses;
using Domain.Entites;
using MediatR;

namespace Application.Features.CategoryFeature.Requests;

public class UpdateCategoryRequest  : IRequest<BaseCommandResponse<Category>>{
    public required UpdateCategoryDTO Update{ get; set; }
    public required string Token { get; set; }
    
}