using Application.Contracts.Persistence;
using BackendAssessment.Application.DTOs.CategoryDtos;
using AutoMapper;
using MediatR;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using BackendAssessment.Application.Features.Categories.Requests.Queries;

namespace BackendAssessment.Application.Features.Categories.Handlers.Queries;

public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<CategoryDto>>
{
    private readonly ICategoryRepository _CategoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesRequestHandler(ICategoryRepository CategoryRepository, IMapper mapper)
    {
        _CategoryRepository = CategoryRepository;
        _mapper = mapper;
    }
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesRequest request, CancellationToken token)
    {
        var Categorys = await _CategoryRepository.GetAll();

        return _mapper.Map<List<CategoryDto>>(Categorys);
    }

   
}