using Application.Contracts;
using Application.DTO.BookingProduct.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.BookingProduct.Validation
{
    public class BookingValidation : AbstractValidator<BookProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;



            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required")
                .GreaterThan(0).WithMessage("ProductId must be greater than 0")
                .MustAsync(async (ProductId, cancellation) =>
                {
                    return await _unitOfWork.ProductRepository.Exists(ProductId);
                    // chek if it exists
                }).WithMessage("Product with this Id doesn't exist");  


            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");    

            RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate is required");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("EndDate is required");
        }
    }
}
