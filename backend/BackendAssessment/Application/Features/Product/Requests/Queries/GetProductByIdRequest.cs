using Application.Dtos;
using MediatR;

namespace Application.Features.Prodcut.Requests.Queries;

public class GetProductByIdRequest : IRequest<ProductDto>
{
    public int Id { get; set; }
}