using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Products;
using Application.DTOs.Users;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Request.Queries
{
    public class GetUserRequest : IRequest<ErrorOr<UserDto>>
    {
        public int UserId { get; set; }
        
    }
}