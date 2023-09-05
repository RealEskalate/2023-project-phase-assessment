using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Categories.Request.Query
{
    public class GetCategoryByIdRequest : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}