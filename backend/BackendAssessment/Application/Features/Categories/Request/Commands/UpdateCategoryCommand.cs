using Application.Dtos.Category;
using Application.Dtos.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
