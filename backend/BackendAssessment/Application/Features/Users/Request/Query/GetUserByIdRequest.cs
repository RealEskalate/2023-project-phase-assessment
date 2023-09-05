using Application.DTOs.User;
using MediatR;

namespace Application.Features.Users.Request.Query
{
    public class GetUserByIdRequest : IRequest<GetUserDto>
    {
        public Guid Id { get; set; }
    }
}