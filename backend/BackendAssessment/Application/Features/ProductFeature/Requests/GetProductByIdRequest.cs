using Application.DTO.ProductDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.ProductFeature.Requests;

public class GetProductByIdRequest : IRequest<BaseCommandResponse<ProductDetailDTO>>{
    public required int ProductId{ get; set; }

}