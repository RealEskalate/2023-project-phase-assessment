using Application.Contracts;
using Application.Exceptions;
using Application.Features.Cateogory.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cateogory.Handlers.Commands;

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
        var DoesExist = await _categoryRepository.ExistsAsync(request.UpdateCategoryDto.Id);
        if (!DoesExist)
        {
            throw new NotFoundException(nameof(Category), request.UpdateCategoryDto.Id);
        }

        var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.UpdateCategoryDto.Id);
        _mapper.Map(request.UpdateCategoryDto, categoryToUpdate);
        await _categoryRepository.UpdateAsync(categoryToUpdate!);
        
        return Unit.Value;
    }
}