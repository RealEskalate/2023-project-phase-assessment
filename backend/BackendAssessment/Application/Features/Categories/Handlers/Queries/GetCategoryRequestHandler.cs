using Application.Contracts.Persistence;
using AutoMapper;
using BackendAssessment.Application.Common.Exceptions;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Application.Features.Categories.Requests.Queries;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Handlers.Queries;

public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryDto>
{
    private readonly ICategoryRepository _CategoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryRequestHandler(ICategoryRepository CategoryRepository, IMapper mapper)
    {
        _CategoryRepository = CategoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken token)
    {
        var Category = await _CategoryRepository.Get(request.Id);
        if (Category == null)
            throw new NotFoundException(nameof(Category), request.Id);
        return _mapper.Map<CategoryDto>(Category);
    }
}