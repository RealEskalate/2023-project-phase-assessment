using Application.DTO.CategoryDTO;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse<int>>
    {
        public CategoryDto categoryDto { get; set; }
    }
}
