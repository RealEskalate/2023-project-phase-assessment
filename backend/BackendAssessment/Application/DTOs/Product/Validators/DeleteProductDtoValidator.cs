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
      
    public class DeleteProductDtoValidator : AbstractValidator<DeleteProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
    
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}