using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Queries;

public class GetProductRequest : IRequest<BaseCommandResponse<ProductDTO>>
{
    public int ProductId { get; set; }
}