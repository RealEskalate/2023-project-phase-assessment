using Application.Dtos.CategoryDtos;
using Application.Response;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public class CreateCategoryCommand :  IRequest<BaseCommandResponse<int?>>
{
    public CreateCategoryDto CreateCategory { get; set; }
    public int UserId { get; set; }
}