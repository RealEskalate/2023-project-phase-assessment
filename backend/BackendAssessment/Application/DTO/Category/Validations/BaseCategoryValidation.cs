using Application.DTO.Category.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Category.Validations
{
    public class BaseCategoryValidation : AbstractValidator<ICategoryDTO>
    {
        public BaseCategoryValidation()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must be less than 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must be less than 500 characters");
        }
    }
}
