using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Product.DTO;
using BackendAssessment.Application.Features.Product.Queries.Requests;
using MediatR;

namespace BackendAssessment.Application.Features.Product.Queries.Handlers;

public class GetProductByIdRequestHandler: IRequestHandler<GetProductByIdRequest, CommonResponse<CreateProductDto>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetProductByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<CreateProductDto>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var foundProduct = await _unitOfWork.ProductRepository.GetAsync(request.Id);
        if (foundProduct != null)
        {
            return CommonResponse<CreateProductDto>.Success(value: _mapper.Map<CreateProductDto>(foundProduct));
        }
        else
        {
            return CommonResponse<CreateProductDto>.Failure(message: "Product not found");
        }
    }
}