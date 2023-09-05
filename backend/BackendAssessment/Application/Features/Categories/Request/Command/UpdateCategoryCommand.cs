using MediatR;
using Application.DTO.Category;

namespace Application.Features.Categories.Request.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryDTO>
    {
        public CategoryDTO categoryDTO { get; set; }
    }
}