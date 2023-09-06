using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Request.Query
{
    public class GetUserByIdRequest : IRequest<GetUserDTO>
    {
        public Guid Id { get; set; }
    }
}