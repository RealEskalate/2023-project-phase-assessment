using BackendAssessment.Application.DTOs.ProductDtos;
using MediatR;

namespace BackendAssessment.Application.Features.Products.Requests.Queries;

public class GetProductRequest : IRequest<ProductDto>
{
    public int Id { get; set; }
}