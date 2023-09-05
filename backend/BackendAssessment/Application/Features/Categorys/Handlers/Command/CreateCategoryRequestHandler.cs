using Application.Contracts;
using Application.DTOs.Categorys;
using Application.DTOs.Categorys.Validation;
using Application.Features.Categorys.Requests.Command;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handlers.Command
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, CategoryDetailsDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDetailsDto> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCategoryDto);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var category = _mapper.Map<Category>(request.CreateCategoryDto);
            category = await _categoryRepository.Add(category);

            return _mapper.Map<CategoryDetailsDto>(category);   
        }
    }
    
}
