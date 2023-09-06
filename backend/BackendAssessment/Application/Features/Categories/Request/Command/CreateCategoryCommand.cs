using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catergories;
using ErrorOr;
using MediatR;

namespace Application.Features.Categories.Request.Command
{
    public class CreateCategoryCommand : IRequest<ErrorOr<CategoryResponseDto>>
    {
        public int UserId { get; set; }
        public CreateCategoryDto CreateCategoryDto { get; set; } = null!;
        
    }
}