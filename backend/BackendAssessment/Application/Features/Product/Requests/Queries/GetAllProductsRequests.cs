using Application.Dtos;
using MediatR;

namespace Application.Features.Prodcut.Requests.Queries;

public class GetAllProductsRequest : IRequest<List<ProductDto>>
{
}