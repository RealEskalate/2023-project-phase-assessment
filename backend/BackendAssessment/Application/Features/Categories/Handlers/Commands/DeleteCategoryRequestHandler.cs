using Application.Contracts.Persistence;
using BackendAssessment.Application.Common.Exceptions;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Categories.Requests.Commands;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands;

public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Unit>
{
    private readonly ICategoryRepository _CategoryRepository;

    public DeleteCategoryRequestHandler(ICategoryRepository CategoryRepository)
    {
        _CategoryRepository = CategoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken token)
    {
        var Category = await _CategoryRepository.Get(request.Id);

        if (Category == null)
            throw new NotFoundException(nameof(Category), request.Id);
        
        await _CategoryRepository.Delete(Category);

        return Unit.Value;
    }
}