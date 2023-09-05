using Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Request.Queries
{
    public class GetCategoryRequest : IRequest<CategoryRetriveDto>
    {
        public Guid id { get; set; }
    }
}
