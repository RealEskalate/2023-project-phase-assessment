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
      
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
    Include(new IProductDtoValidator());
            RuleFor(c => c.CategoryId)
            .MustAsync(async (id, token) => {
                var categoryExists = await _unitOfWork.CategoryRepository.Exists(id);
                return categoryExists ;
            })
            .WithMessage("{ProperyName} does not exist.");
        }
    }
}