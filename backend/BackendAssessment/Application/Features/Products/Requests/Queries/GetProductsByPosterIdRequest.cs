
using BackendAssessment.Application.DTOs.ProductDtos;
using MediatR;

namespace BackendAssessment.Application.Features.Products.Requests.Queries;

public class GetProductsByUserIdRequest : IRequest<List<ProductDto>>
{
    public int UserId { get; set; }
}