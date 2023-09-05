using Application.DTO.ProductDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.ProductFeature.Requests;

public class GetAllProductRequest : IRequest<BaseCommandResponse<List<ProductListDTO>>>{
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;
}