using Application.DTO.ProductDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.ProductFeature.Requests;

public class UpdateProductRequest : IRequest<BaseCommandResponse<ProductListDTO>>{
    public required UpdateProductDTO Update{ get; set; }
    public required string Token { get; set; }
}