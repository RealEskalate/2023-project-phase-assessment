using Application.Contracts;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var validation = new DeleteCategoryCommandValidator(_categoryRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        await _categoryRepository.DeleteAsync(category!.Id);
        return Unit.Value;
    }
}