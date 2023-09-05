using BackendAssessment.Application.Common.Responses;
using MediatR;

namespace BackendAssessment.Application.Features.Category.Commands.Requests;

public class DeleteCategoryCommand :IRequest<CommonResponse<int>>
{
    public int Id { get; set; }
}