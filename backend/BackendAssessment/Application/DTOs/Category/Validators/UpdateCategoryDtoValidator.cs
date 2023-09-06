using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Contracts.Persistence;
using Application.DTOs.Product;
using Application.DTOs.Product.Validators;
using FluentValidation;

namespace Application.DTOs.Category.Validators
{
      
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategoryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
    Include(new ICategoryDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}