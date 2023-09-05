using Application.Contracts;
using Application.Exceptions;
using Application.Features.Cateogory.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cateogory.Handlers.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
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

        var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Category), request.Id);
        await _categoryRepository.DeleteAsync(categoryToDelete!);
        return Unit.Value;
    }
}

