using Application.DTO.CategoryDTO;
using Application.Responses;
using Domain.Entites;
using MediatR;

namespace Application.Features.CategoryFeature.Requests;

public class CreateCategoryRequest : IRequest<BaseCommandResponse<Category>>{
    public required CategoryDTO Create{ get; set; }
    public required string Token { get; set; }
    
}