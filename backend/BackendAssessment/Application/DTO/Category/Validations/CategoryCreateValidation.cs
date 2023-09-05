using Application.DTO.Category.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Category.Validations
{
    public class CategoryCreateValidation :AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateValidation()
        {
            Include(new BaseCategoryValidation());
        }
    }
}
