using Application.DTOs.Category;
using Application.Features.Categories.Request.Query;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handler.Query
{
    public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, CategoryDto>
    {
        public IMapper _mapper;
        public ICategoryRepository _categoryRepository;

        public GetCategoryByIdRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _categoryRepository.GetById(request.Id);
            return _mapper.Map<CategoryDto>(product);
        }
    }
}