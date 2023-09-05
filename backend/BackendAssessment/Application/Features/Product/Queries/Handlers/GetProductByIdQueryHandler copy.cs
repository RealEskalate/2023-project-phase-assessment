
using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Products.Queries.Requests;

namespace ProductHub.Application.Features.Products.Queries.Handlers;
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, CommonResponse<ProductDto>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        CommonResponse<ProductDto> response;
        response = CommonResponse<ProductDto>.Success(_mapper.Map<ProductDto>(await _unitOfWork.ProductRepository.GetAsync(request.Id)));
        return response;
    }
}