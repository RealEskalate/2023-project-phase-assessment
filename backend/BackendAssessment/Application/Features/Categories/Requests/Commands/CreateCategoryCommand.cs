using Application.DTOs.Category;
using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Requests.Commands;

public class CreateCategoryCommand : IRequest<BaseCommandResponse<Category>>
{
    public CreateCategoryDto CategoryDto { get; set; } = new(); 
}