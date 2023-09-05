using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Products.Requests.Commands;

namespace ProductHub.Application.Features.Products.Handlers.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommonResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken){
        
        var product = await _unitOfWork.ProductRepository.GetAsync(request.ProductId);
        if(product == null){
            return CommonResponse<Unit>.Failure("Product Not Found");
        }
        await _unitOfWork.ProductRepository.DeleteAsync(product);

        if( await _unitOfWork.SaveAsync() == 0)
        {
            return CommonResponse<Unit>.Failure("Error While Saving Changes!");
        }

        return CommonResponse<Unit>.Success(Unit.Value);
    }
}
