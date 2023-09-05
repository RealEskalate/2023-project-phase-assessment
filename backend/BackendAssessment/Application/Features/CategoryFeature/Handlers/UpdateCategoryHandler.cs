using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.CategoryDTO;
using Application.DTO.CategoryDTO.CategoryDTOValidator;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.CategoryFeature.Handlers;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, BaseCommandResponse<Category>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Category>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken){
        try{
            var AuthResponse = await _authService.TokenValidator(request.Token);
            if (AuthResponse.Role != "ADMIN") throw new BadRequestException("You Are Not Allowed To Do This");
            
            var validator = new CategoryDTOValidator(_unitOfWork.CategoryRepository);
            var validationResult = await validator.ValidateAsync(_mapper.Map<CategoryDTO>(request.Update));
            if (!validationResult.IsValid) throw new ValidationException(validationResult);
            
            var category = await _unitOfWork.CategoryRepository.Get(request.Update.Id);
            if (category == null) throw new NotFoundException(nameof(Category),"Category Not Found");
            _mapper.Map(request.Update, category);
            
            await _unitOfWork.CategoryRepository.Update(category);
            if (await _unitOfWork.Save() == 0)  throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<Category>.SuccessHandler(category);

        }
        catch(Exception e){
            return BaseCommandResponse<Category>.FailureHandler(e);

        }
    }
}