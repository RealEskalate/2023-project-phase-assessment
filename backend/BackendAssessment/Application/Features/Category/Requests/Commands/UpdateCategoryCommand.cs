
using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Category.Request.Commands;

public class UpdateCategoryCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required CategoryDTO updatedCategory{ get; set; }
}
