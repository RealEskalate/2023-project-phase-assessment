using MediatR;

namespace BackendAssessment.Application.Features.Categories.Requests.Commands;

public class DeleteCategoryRequest : IRequest<Unit>
{
    public int Id { get; set; }
}