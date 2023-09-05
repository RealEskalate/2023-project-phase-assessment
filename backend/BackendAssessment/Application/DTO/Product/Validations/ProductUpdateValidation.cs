using Application.Contracts;
using Application.DTO.Product.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Product.Validations
{
    public class ProductUpdateValidation :  AbstractValidator<ProductUpdateDTO>
    
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductUpdateValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            Include(new BaseProductDTOValidation());


            RuleFor(x => x.CategoryId)
               .NotEmpty()
               .WithMessage("CategoryId is required")
               .GreaterThan(0)
               .WithMessage("CategoryId must be greater than 0")
               .MustAsync(async (CategoryId, cancellation) =>
               {
                   return await _unitOfWork.CategoryRepository.Exists(CategoryId);
               }).WithMessage("Category with this Id doesn't exist");
        }
    }
}
