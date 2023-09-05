using Application.Contracts;
using Application.DTOs.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Products.Validation
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Product description is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Product category is required")
                .MustAsync((catId , CancellationToken) =>
                {
                    var exists = categoryRepository.Exists(catId);
                    return exists;
                }).WithMessage("Category doesn't exist");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Product user is required");
                
            RuleFor(x => x.Availability).NotEmpty().WithMessage("Product availability is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product price is required");
        }
    }
}
