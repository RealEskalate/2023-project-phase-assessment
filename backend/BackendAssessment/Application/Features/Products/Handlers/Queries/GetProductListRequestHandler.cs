using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Products.Requests.Queries;

namespace ProductHub.Application.Features.Products.Handlers.Queries;

public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, CommonResponse<List<ProductDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<ProductDto>>> Handle(
        GetProductListRequest request,
        CancellationToken cancellationToken
    )
    {
        // var user = await _unitOfWork.UserRepository.GetAsync(request.UserId);
        // if (user == null){
        //     return CommonResponse<List<NotificationListDto>>.Failure("User Doesn't Exist");
        // }

        var products = await _unitOfWork.ProductRepository.GetProductsByUserId(request.UserId);
        // Handle null case
        if(products == null)
        {
            CommonResponse<List<ProductDto>>.Failure("Products Not Found");
        }

        return CommonResponse<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products));

    }
}
