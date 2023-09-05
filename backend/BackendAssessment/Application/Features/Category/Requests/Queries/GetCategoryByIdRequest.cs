using Application.Dtos;
using MediatR;

namespace Application.Features.Cateogory.Requests;

public class GetCategoryByIdRequest : IRequest<CategoryDto>
{
    public int Id { get; set; }
}
