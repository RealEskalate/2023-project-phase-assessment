using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Features.Category.DTO;
using MediatR;

namespace BackendAssessment.Application.Features.Category.Commands.Requests;

public class UpdateCategoryCommand :IRequest<CommonResponse<int>>
{
    public UpdateCategoryDto updateCategoryDto { get; set; }
}