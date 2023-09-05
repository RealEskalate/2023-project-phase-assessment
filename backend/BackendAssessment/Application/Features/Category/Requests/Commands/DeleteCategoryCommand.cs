using MediatR;

namespace Application.Features.Cateogory.Commands;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
}