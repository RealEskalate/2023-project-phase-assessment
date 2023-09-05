using Application.Responses;
using MediatR;

namespace Application.Features.CategoryFeature.Requests;

public class DeleteCategoryRequest : IRequest<BaseCommandResponse<Unit>>{
    public required int CategoryId { get; set; }
    public string Token { get; set; }
}