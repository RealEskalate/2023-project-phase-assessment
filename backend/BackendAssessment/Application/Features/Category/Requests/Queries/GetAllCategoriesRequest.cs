using Application.Dtos;
using MediatR;

namespace Application.Features.Cateogory.Requests;

public class GetAllCategoriesRequest : IRequest<List<CategoryDto>>
{
}