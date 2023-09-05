using Application.Responses;
using Domain.Entites;
using MediatR;

namespace Application.Features.CategoryFeature.Requests;

public class GetCategoryByIdRequest :  IRequest<BaseCommandResponse<Category>>{
    public int Id{ get; set; }
    
}