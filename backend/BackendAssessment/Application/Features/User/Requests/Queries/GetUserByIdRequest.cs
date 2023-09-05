using Application.Dtos;
using MediatR;

namespace Application.Features.User.Requests.Queries;

public class GetUserByIdRequest : IRequest<UserDto>
{
    public int Id { get; set; }
}