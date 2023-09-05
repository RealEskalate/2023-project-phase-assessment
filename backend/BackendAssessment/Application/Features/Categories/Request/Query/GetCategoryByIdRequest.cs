using Application.DTO.Category;
using MediatR;

namespace Application.Features.Categories.Request.Query
{
    public class GetCategoryByIdRequest : IRequest<CategoryDTO>
    {
        public Guid Id { get; set; }
    }
}