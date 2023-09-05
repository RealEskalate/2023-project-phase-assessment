using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Categories.Requests.Commands;

namespace ProductHub.Application.Features.Categories.Handlers.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommonResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken){
        
        var category = await _unitOfWork.CategoryRepository.GetAsync(request.CategoryId);
        if(category == null){
            return CommonResponse<Unit>.Failure("Category Not Found");
        }
        await _unitOfWork.CategoryRepository.DeleteAsync(category);

        if( await _unitOfWork.SaveAsync() == 0)
        {
            return CommonResponse<Unit>.Failure("Error While Saving Changes!");
        }

        return CommonResponse<Unit>.Success(Unit.Value);
    }
}
