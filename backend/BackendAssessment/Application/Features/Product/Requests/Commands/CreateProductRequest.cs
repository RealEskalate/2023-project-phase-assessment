using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Commands
{
    public class CreateProductRequest : IRequest<BaseCommandResponse>
    {
        public required CreateProductDto CreateProductDto {get; set;}
        public Guid UserId {get; set;}
    }
}