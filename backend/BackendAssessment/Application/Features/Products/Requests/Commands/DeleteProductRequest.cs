using MediatR;

namespace BackendAssessment.Application.Features.Products.Requests.Commands;

public class DeleteProductRequest : IRequest<Unit>
{
    public int Id { get; set; }
}