using Application.Contracts.Persistence;
using Application.DTOs.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategories
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDetailsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryListHandler(IUnitOfWork unitOfWork,
             IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDetailsDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            return _mapper.Map<List<CategoryDetailsDto>>(categories);

        }
    }
}
