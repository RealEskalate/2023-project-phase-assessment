using Application.Dtos.CategoryDtos;
using Application.Response;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public class UpdateCategoryCommand : IRequest<BaseCommandResponse<Unit?>>
{
    public UpdateCategoryDto updateCategory { get; set; }
    public int UserId { get; set; }
}
