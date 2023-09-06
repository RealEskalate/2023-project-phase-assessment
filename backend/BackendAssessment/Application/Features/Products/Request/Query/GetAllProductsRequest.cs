using Application.DTO.Products;
using MediatR;

namespace Application.Features.Products.Request.Query;

public interface GetAllProducts : IRequest<List<ProductDto>>
{
    
}