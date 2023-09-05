using Application.Contracts.persistence;
using Application.Dtos.Category.validator;
using Application.Dtos.Product.Validator;
using Application.Exceptions;
using Application.Features.Products.Request.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Commands
{
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateCategoryValidator();
            var validationResult = await validation.ValidateAsync(request.CreateCategoryDto, cancellationToken);
            if (validationResult.IsValid == true)
            {
                var category = _mapper.Map<Category>(request.CreateCategoryDto);
                category = await _categoryRepository.Add(category);
                return category.Id;
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            
        }
    }
}
