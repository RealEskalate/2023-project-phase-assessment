using Application.DTO.ProductDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.ProductFeature.Requests;

public class CreateProductRequest : IRequest<BaseCommandResponse<ProductListDTO>>{
    
    public required CreateProductDTO Create{ get; set; }
    public required string Token { get; set; }
    
}