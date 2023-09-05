using MediatR;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Categories.Requests.Commands;

public class DeleteCategoryCommand : IRequest<CommonResponse<Unit>>
{
    public int CategoryId {get; set;}
}
