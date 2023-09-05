using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Categorys.Handlers.Commands;

public class DeleteCategoryCommandHandler
    : IRequestHandler<DeleteCategoryCommand, CommonResponse<Unit>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Unit>> Handle(
        DeleteCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        if (await _unitOfWork.CategoryRepository.ExistsAsync(request.CategoryId))
        {
            return CommonResponse<Unit>.FailureWithError(
                "Category deletion failed",
                "Category doesn't exist."
            );
        }

        if (await _unitOfWork.UserRepository.ExistsAsync(request.UserId))
        {
            return CommonResponse<Unit>.FailureWithError(
                "Category deletion failed",
                "User cannot delete this category."
            );
        }

        await _unitOfWork.CategoryRepository.DeleteAsync(request.CategoryId);
        if (await _unitOfWork.SaveAsync() > 0)
        {
            return new CommonResponse<Unit> { };
        }
        else
        {
            return CommonResponse<Unit>.Failure("category creation failed.");
        }
    }
}
