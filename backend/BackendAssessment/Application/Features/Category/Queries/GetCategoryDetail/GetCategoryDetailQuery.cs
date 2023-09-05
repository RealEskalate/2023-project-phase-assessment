using Application.DTOs.Category;    
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryDetail;

public class GetCategoryDetailQuery : IRequest<CategoryDetailsDto>
{
    public Guid Id { get; set; }
}
