using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.ProductDTO;
using Application.Exceptions;
using Application.Features.ProductFeature.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProductFeature.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, BaseCommandResponse<ProductDetailDTO>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<ProductDetailDTO>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken){
        try{
            var product = await _unitOfWork.ProductRepository.Get(request.ProductId);
            if (product == null) throw new NotFoundException(nameof(Product),"Product not found");
            return BaseCommandResponse<ProductDetailDTO>.SuccessHandler(_mapper.Map<ProductDetailDTO>(product));
            
        }
        catch(Exception e){
            return BaseCommandResponse<ProductDetailDTO>.FailureHandler(e);
        }
    }
}