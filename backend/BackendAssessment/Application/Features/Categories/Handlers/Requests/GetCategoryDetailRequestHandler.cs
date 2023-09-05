using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Features.Categories.Requests.Queries;

namespace ProductHub.Application.Features.Categories.Handlers.Requests;

public class GetCategoryDetailRequestHandler : IRequestHandler<GetCategoryDetailRequest, CommonResponse<CategoryDto>> 
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<CategoryDto>> Handle(
        GetCategoryDetailRequest request,
        CancellationToken cancellationToken
    )
    {
        var category = await _unitOfWork.CategoryRepository.GetAsync(request.CategoryId);
        if(category == null){
            return CommonResponse<CategoryDto>.Failure("Category Not Found");
        }
        
        return CommonResponse<CategoryDto>.Success( _mapper.Map<CategoryDto>(category));
    }
}
