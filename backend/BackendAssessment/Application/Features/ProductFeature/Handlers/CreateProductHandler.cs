using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.ProductDTO;
using Application.DTO.ProductDTO.Validators;
using Application.Exceptions;
using Application.Features.ProductFeature.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProductFeature.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, BaseCommandResponse<ProductListDTO>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public CreateProductHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<ProductListDTO>> Handle(CreateProductRequest request, CancellationToken cancellationToken){
        try{
            var validator = new CreateProductDTOValidator(_unitOfWork.ProductRepository, _unitOfWork.CategoryRepository);
            var validationResult = await validator.ValidateAsync(request.Create);
            if (!validationResult.IsValid) throw new ValidationException(validationResult);
            var product = _mapper.Map<Product>(request.Create);
            var AuthResponse = await _authService.TokenValidator(request.Token);
            product.UserId = AuthResponse.Id;

            await _unitOfWork.ProductRepository.Add(product);
            if (await _unitOfWork.Save() == 0)  throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<ProductListDTO>.SuccessHandler(_mapper.Map<ProductListDTO>(product));


        }
        catch(Exception e){
            return BaseCommandResponse<ProductListDTO>.FailureHandler(e);

        }
    }
}