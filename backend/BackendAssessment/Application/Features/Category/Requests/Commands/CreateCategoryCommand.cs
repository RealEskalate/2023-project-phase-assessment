using Application.Dtos;
using MediatR;

namespace Application.Features.Cateogory.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public required CreateCategoryDto CreateCategory { get; set; }
}