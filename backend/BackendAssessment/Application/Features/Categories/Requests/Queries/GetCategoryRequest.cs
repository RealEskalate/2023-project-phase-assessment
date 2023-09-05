using BackendAssessment.Application.DTOs.CategoryDtos;
using MediatR;

namespace BackendAssessment.Application.Features.Categories.Requests.Queries;

public class GetCategoryRequest : IRequest<CategoryDto>
{
    public int Id { get; set; }
}