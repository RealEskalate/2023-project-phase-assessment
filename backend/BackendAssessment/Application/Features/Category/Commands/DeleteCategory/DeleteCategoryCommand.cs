using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public Guid CategoryId { get; set; }
}