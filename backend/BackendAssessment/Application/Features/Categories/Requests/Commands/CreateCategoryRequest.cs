using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace BackendAssessment.Application.Features.Categories.Requests.Commands;

public class CreateCategoryRequest : IRequest<Category>
{
    public CategoryDto CategoryDto { get; set; }
}