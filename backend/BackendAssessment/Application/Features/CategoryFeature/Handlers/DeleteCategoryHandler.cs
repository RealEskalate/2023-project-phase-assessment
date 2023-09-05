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

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, BaseCommandResponse<Unit>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public DeleteCategoryHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken){
        try{
            var AuthResponse = await _authService.TokenValidator(request.Token);
            if (AuthResponse.Role != "ADMIN") throw new BadRequestException("You Are Not Allowed To Do This");

            var category = await _unitOfWork.CategoryRepository.Get(request.CategoryId);
            if (category == null) throw new NotFoundException(nameof(Category),"Category Not Found");

            await _unitOfWork.CategoryRepository.Delete(category);
            if (await _unitOfWork.Save() == 0)  throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);

        }
        catch(Exception e){
            return BaseCommandResponse<Unit>.FailureHandler(e);

        }
    }
}