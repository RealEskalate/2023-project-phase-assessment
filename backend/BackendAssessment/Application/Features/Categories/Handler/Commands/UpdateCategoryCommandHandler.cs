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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var CategoryToBeUpdated = await _categoryRepository.GetById(request.UpdateCategoryDto.Id);
            var validation = new UpdateCategoryValidator();
            var validationResult = await validation.ValidateAsync(request.UpdateCategoryDto, cancellationToken);
            if (validationResult.IsValid == true)
            {
                _mapper.Map(request.UpdateCategoryDto, CategoryToBeUpdated);
                await _categoryRepository.Update(CategoryToBeUpdated);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            return Unit.Value;
        }
    }
}
