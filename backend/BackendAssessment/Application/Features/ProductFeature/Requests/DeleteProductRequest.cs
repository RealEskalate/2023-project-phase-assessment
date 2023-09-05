using Application.Responses;
using MediatR;

namespace Application.Features.ProductFeature.Requests;

public class DeleteProductRequest  : IRequest<BaseCommandResponse<Unit>>{
    
    public required int ProductId { get; set; }
    public string Token { get; set; }
    
}