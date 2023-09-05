using MediatR;

namespace Application.Features.Category.Commands.Delete;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public Guid CategoryId { get; set; }
}