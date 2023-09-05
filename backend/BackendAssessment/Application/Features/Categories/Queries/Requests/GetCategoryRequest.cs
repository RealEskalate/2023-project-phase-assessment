using Application.Common.Responses;
using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categorie.Queries.Requests;

public class GetCategoryRequest : IRequest<CommonResponse<CategoryDto>>
{
    public Guid CategoryId { get; set; }
}
