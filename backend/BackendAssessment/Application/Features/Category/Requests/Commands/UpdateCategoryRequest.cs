using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Responses;
using MediatR;

namespace Application.Features.Category.Requests.Commands
{
    public class UpdateCategoryRequest : IRequest<BaseCommandResponse>
    {
        public required UpdateCategoryDto UpdateCategoryDto {get; set;}
    }
}