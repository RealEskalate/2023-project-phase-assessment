using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Categorie.Queries.Requests;
using Application.Features.Categories.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handlers.Requests;

public class GetCategoryRequestHandler
    : IRequestHandler<GetCategoryRequest, CommonResponse<CategoryDto>>
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<CategoryDto>> Handle(
        GetCategoryRequest request,
        CancellationToken cancellationToken
    )
    {
      if (await _unitOfWork.CategoryRepository.ExistsAsync(request.CategoryId) == false) {
        return CommonResponse<CategoryDto>.FailureWithError("Category cannot be retrieved.", "Category doesn't exist.");
      }
        return CommonResponse<CategoryDto>.Success(_mapper.Map<CategoryDto>(await _unitOfWork.CategoryRepository.GetAsync(request.CategoryId)));
    }
}
