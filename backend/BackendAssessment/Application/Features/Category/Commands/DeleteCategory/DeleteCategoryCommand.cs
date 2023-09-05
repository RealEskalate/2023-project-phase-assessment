using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
