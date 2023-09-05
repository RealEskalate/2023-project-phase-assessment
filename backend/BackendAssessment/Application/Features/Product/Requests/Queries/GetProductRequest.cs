using Application.Dtos.ProductDto;
using Application.Response;
using MediatR;

namespace Application.Features.Product.Requests.Queries;

public class GetProductRequest: IRequest<BaseCommandResponse<List<ProductDto>>>
{
    public int Id{ get; set; }

    
}