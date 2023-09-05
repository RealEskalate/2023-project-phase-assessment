using MediatR;

namespace Application.Features.Prodcut.Requests.Commands;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
}