using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catergories;
using ErrorOr;
using MediatR;

namespace Application.Features.Categories.Request.Queries
{
    public class GetCategoryRequest : IRequest<ErrorOr<CategoryResponseDto>>
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        
    }
}