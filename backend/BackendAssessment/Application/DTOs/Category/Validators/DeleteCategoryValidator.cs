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
      
    public class DeleteCategoryDtoValidator : AbstractValidator<DeleteCategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}