using BackendAssessment.Application.DTOs.ProductDtos;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace BackendAssessment.Application.Features.Products.Requests.Commands;

public class CreateProductRequest : IRequest<Product>
{
    public ProductDto ProductDto { get; set; }
}