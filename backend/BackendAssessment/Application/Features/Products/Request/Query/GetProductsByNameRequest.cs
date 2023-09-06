using Application.DTO.Products;
using MediatR;

namespace Application.Features.Products.Request.Query;

public interface GetProductsByNameRequest : IRequest<List<ProductDto>>
{
    public string Name { get; set; }

}