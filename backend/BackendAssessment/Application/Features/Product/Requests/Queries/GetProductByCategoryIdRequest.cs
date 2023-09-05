using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Queries;

public class GetProductByCategoryIdRequest : IRequest<BaseCommandResponse<List<ProductDTO>>>
{
   public int CategoryId { get; set; }
}