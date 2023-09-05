using Application.Common.Responses;
using MediatR;

namespace Application.Features.Categories.Queries.Commands;

public class DeleteCategoryCommand : IRequest<CommonResponse<Unit>>
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}
