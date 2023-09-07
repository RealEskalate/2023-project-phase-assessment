using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Product.Commands.Requests;
using BackendAssessment.Application.Features.Product.DTO.Validator;
using MediatR;

namespace BackendAssessment.Application.Features.Product.Commands.Handlers;

public class AcquireProductCommandHandler : IRequestHandler<AcquireProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public AcquireProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<CommonResponse<int>> Handle(AcquireProductCommand command, CancellationToken cancellationToken)
    {
        var response = new CommonResponse<int>();
        var Validator = new AcquireProductDtoValidator(_unitOfWork);

        var validationResult = await Validator.ValidateAsync(command.acquireProductDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.FailureWithError(message: "failed to acquire product",
                error: validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        else
        {
            var foundProduct = await _unitOfWork.ProductRepository.GetAsync(command.acquireProductDto.ProductId);
            foundProduct.UserId = command.acquireProductDto.CustomerId;
            await _unitOfWork.ProductRepository.UpdateAsync(
                foundProduct
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                return CommonResponse<int>.Success(foundProduct.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Failed to acquire product");
            }
        }
    }
}