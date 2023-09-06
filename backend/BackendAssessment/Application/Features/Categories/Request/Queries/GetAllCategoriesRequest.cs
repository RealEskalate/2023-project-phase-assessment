using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catergories;
using ErrorOr;
using MediatR;

namespace Application.Features.Categories.Request.Queries
{
    public class GetAllCategoriesRequest : IRequest<ErrorOr<List<CategoryResponseDto>>>
    {
        public int UserId { get; set; }
        
    }
}