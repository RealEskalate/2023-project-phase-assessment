using Application.Contracts;
using Application.Dtos.Category;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private IMapper _mapper;
    private ICategoryRepository _categoryRepository;
    public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper; 
        _categoryRepository = categoryRepository;  
    }

    public async Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetSingleAsync(command.CategoryId,cancellationToken);
        if(category == null)
            throw new Exception("Category Id not found");
        await _categoryRepository.DeleteAsync(category,cancellationToken);
        return Unit.Value;
    }
}