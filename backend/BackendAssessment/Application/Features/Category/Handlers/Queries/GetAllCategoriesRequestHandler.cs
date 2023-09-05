using Application.Contracts;
using Application.Dtos;
using Application.Features.Cateogory.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Cateogory.Handlers.Queries
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}