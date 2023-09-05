using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.CategoryDTO;
using Application.DTO.ProductDTO;
using Application.Features.CategoryFeature.Requests;
using Application.Features.ProductFeature.Requests;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductFeature.Handlers;

public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, BaseCommandResponse<List<CategoryListDTO>>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public GetAllCategoryHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<List<CategoryListDTO>>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken){
        try{
            var products = await _unitOfWork.CategoryRepository.GetAll(request.PageNumber, request.PageSize);
            return BaseCommandResponse<List<CategoryListDTO>>.SuccessHandler(_mapper.Map<List<CategoryListDTO>>(products));
        }
        catch(Exception e){
            return BaseCommandResponse<List<CategoryListDTO>>.FailureHandler(e);
        }
    }
   
}