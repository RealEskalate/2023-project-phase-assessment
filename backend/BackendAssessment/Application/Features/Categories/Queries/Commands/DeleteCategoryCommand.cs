using Application.Common.Responses;
using MediatR;

namespace Application.Features.Categories.Queries.Commands;

public class DeleteCategoryCommand : IRequest<CommonResponse<Unit>>
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}
