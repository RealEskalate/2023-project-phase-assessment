using Application.DTOs.Users;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Request.Queries
{
    public class GetAllUserRequest : IRequest<ErrorOr<List<UserDto>>>
    {
        public int UserId { get; set; }   
    }
}