using Application.Responses;
using MediatR;

namespace Application.Features.Category.Request.Commands;

public class DeleteCategoryCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required int CategoryId{ get; set; }
    public required int UserId{ get; set; }
    
}