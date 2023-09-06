using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DTOs.Catagory.Validators
{
    public class CreateCatagoryDtoValidator : AbstractValidator<CreateCatagoryDto>
    {
        public CreateCatagoryDtoValidator()
        {
            Include(new ICatagoryDtoValidator());
        }
    }
}