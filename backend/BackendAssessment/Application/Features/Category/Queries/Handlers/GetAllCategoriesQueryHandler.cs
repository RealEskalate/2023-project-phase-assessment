
using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Features.Categories.Queries.Requests;

namespace ProductHub.Application.Features.Categories.Queries.Handlers;
public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CommonResponse<List<CategoryDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        CommonResponse<List<CategoryDto>> response;
        response = CommonResponse<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(await _unitOfWork.CategoryRepository.GetAsync()));
        return response;
    }
}