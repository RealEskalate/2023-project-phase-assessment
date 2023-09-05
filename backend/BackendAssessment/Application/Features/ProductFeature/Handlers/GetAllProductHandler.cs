using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.ProductDTO;
using Application.Features.ProductFeature.Requests;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductFeature.Handlers;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, BaseCommandResponse<List<ProductListDTO>>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public GetAllProductHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<List<ProductListDTO>>> Handle(GetAllProductRequest request, CancellationToken cancellationToken){
        try{
            var products = await _unitOfWork.ProductRepository.GetAll(request.PageNumber, request.PageSize);
            List<ProductListDTO> listProduct = _mapper.Map<List<ProductListDTO>>(products);
            return BaseCommandResponse<List<ProductListDTO>>.SuccessHandler(listProduct);
        }
        catch(Exception e){
            return BaseCommandResponse<List<ProductListDTO>>.FailureHandler(e);
        }
    }
}