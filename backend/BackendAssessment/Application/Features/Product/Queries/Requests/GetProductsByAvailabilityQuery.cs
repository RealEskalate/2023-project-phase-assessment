using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Domain.Entities;

namespace ProductHub.Application.Features.Products.Queries.Requests;
public class GetProductsByAvailabilityQuery : IRequest<CommonResponse<List<ProductDto>>>
{
    public Availability Availability { get; set; }
}