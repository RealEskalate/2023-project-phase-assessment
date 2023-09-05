using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Products.Queries.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers.Commands;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, CommonResponse<Unit>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Unit>> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken
    )
    {
        if (await _unitOfWork.ProductRepository.ExistsAsync(request.ProductId))
        {
            return CommonResponse<Unit>.FailureWithError(
                "Product deletion failed",
                "Product doesn't exist."
            );
        }

        if (await _unitOfWork.UserRepository.ExistsAsync(request.UserId))
        {
            return CommonResponse<Unit>.FailureWithError(
                "Product deletion failed",
                "User cannot delete this product."
            );
        }

        await _unitOfWork.ProductRepository.DeleteAsync(request.ProductId);
        if (await _unitOfWork.SaveAsync() > 0)
        {
            return new CommonResponse<Unit> { };
        }
        else
        {
            return CommonResponse<Unit>.Failure("product creation failed.");
        }
    }
}
