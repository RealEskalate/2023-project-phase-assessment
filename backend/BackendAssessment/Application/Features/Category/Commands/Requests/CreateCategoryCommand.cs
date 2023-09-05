using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Features.Category.DTO;
using MediatR;

namespace BackendAssessment.Application.Features.Category.Commands.Requests;

public class CreateCategoryCommand :IRequest<CommonResponse<int>>
{
    public CreateCategoryDto createCategoryDto { get; set; }
}