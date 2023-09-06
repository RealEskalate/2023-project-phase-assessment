using Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Request.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryRetriveDto>
    {
        public string name { get; set; }
        public string description { get; set; }
        public Guid id { get; set; }
    }
}
