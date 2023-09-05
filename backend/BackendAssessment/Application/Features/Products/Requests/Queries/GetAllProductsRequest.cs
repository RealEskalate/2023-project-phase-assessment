
using BackendAssessment.Application.DTOs.ProductDtos;
using MediatR;

namespace BackendAssessment.Application.Features.Products.Requests.Queries;

public class GetAllProductsRequest : IRequest<List<ProductDto>>
{
    
}