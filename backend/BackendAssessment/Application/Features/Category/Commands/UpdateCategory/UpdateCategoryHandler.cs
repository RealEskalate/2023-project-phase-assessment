using Application.Contracts;
using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var updatedCategory = _mapper.Map<CategoryEntity>(request.CategoryReqResDto);
        
        await _categoryRepository.UpdateAsync(request.CategoryId, updatedCategory);
        
        return _mapper.Map<CategoryDto>(updatedCategory);
    }
}