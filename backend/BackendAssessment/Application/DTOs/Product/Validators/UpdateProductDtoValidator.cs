using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Contracts.Persistence;
using Application.DTOs.Product;
using Application.DTOs.Product.Validators;
using FluentValidation;

namespace Application.DTOs.Product.Validators
{
      
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
    Include(new IProductDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}