
using BackendAssessment.Application.DTOs.CategoryDtos;
using MediatR;

namespace BackendAssessment.Application.Features.Categories.Requests.Queries;

public class GetAllCategoriesRequest : IRequest<List<CategoryDto>>
{
    
}