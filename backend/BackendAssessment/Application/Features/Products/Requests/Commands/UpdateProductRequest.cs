using BackendAssessment.Application.DTOs.ProductDtos;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace BackendAssessment.Application.Features.Products.Handlers.Commands;

public class UpdateProductRequest : IRequest<ProductDto>
{
    public int Id;
    public ProductDto ProductDto;
}