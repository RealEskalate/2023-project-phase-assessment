using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DTOs.Catagory.Validators
{
    public class UpdateCatagoryDtoValidator : AbstractValidator<UpdateCatagoryDto>
    {
        public UpdateCatagoryDtoValidator()
        {
            Include(new ICatagoryDtoValidator());

            RuleFor(c => c.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}