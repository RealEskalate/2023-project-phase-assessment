using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Request.Commands;

public class CreateCategoryCommand : IRequest<BaseCommandResponse<int>>
{
    public required CategoryDTO createCategory { get; set; }
    
}