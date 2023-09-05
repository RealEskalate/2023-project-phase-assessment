using MediatR;
using Application.DTOs.Category;

namespace Application.Features.Categories.Request.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryDto categoryDTO { get; set; }
    }
}