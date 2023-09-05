using Application.Contracts;
using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryValidator();
        var validationResult = await validator.ValidateAsync(request.CategoryReqResDto, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var newCategory = _mapper.Map<CategoryEntity>(request.CategoryReqResDto);
        
        var createdCategory = await _categoryRepository.CreateAsync(newCategory);
        
        return _mapper.Map<CategoryDto>(createdCategory);
    }
}