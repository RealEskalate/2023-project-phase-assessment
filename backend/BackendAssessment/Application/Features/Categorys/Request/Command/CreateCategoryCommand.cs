using Application.DTO.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Request.Command
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryDto categoryDto { get; set; }
    }
}
