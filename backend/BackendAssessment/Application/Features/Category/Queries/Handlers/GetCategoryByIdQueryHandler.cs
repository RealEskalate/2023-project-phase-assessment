
using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Features.Categories.Queries.Requests;

namespace ProductHub.Application.Features.Categories.Queries.Handlers;
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CommonResponse<CategoryDto>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        CommonResponse<CategoryDto> response;
        response = CommonResponse<CategoryDto>.Success(_mapper.Map<CategoryDto>(await _unitOfWork.CategoryRepository.GetAsync(request.Id)));
        return response;
    }
}