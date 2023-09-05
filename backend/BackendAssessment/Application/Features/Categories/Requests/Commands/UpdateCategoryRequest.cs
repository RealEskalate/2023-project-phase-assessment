using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace BackendAssessment.Application.Features.Categories.Handlers.Commands;

public class UpdateCategoryRequest : IRequest<CategoryDto>
{
    public int Id;
    public CategoryDto CategoryDto;
}