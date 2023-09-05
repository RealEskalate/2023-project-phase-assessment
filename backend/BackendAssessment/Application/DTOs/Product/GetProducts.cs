using ErrorOr;
using MediatR;

namespace Backend.Application.DTOs.Product;

public class GetProducts : IRequest<ErrorOr<IEnumerable<ProductDto>>>
{
    
}