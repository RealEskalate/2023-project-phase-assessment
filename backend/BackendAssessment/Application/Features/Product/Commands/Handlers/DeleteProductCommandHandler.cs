using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Product.Commands.Requests;
using BackendAssessment.Application.Features.Product.DTO.Validator;
using MediatR;

namespace BackendAssessment.Application.Features.Product.Commands.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<int>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var response = new CommonResponse<int>();
        var Validator = new DeleteProductDtoValidator(_unitOfWork);

        var validationResult = Validator.ValidateAsync(command.deleteProductDto);

        if (!validationResult.Result.IsValid)
        {
            return CommonResponse<int>.FailureWithError(message: "failed to update product",
                error: validationResult.Result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        else
        {
            var foundProduct = await _unitOfWork.ProductRepository.GetAsync(
                command.deleteProductDto.Id);
            if (foundProduct != null)
            {
                await _unitOfWork.ProductRepository.DeleteAsync(foundProduct);
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    return CommonResponse<int>.Success(foundProduct.Id);
                }
                else
                {
                    return CommonResponse<int>.Failure("Failed to update product");
                }
            }
            else
            {
                return    CommonResponse<int>.Failure("Product not found");
            }
            
        }
    }
}