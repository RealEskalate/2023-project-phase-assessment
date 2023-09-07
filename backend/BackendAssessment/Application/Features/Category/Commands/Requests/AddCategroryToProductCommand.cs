using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Features.Category.DTO;
using MediatR;

namespace BackendAssessment.Application.Features.Category.Commands.Requests;

public class AddCategroryToProductCommand : IRequest<CommonResponse<int>>
{
    public AddCategoryDto addCategoryDto;
}