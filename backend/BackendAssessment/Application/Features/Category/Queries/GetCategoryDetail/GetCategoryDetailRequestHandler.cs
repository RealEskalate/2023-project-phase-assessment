using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.DTOs.Category;
using Application.Exceptions;
using Application.Features.Category.Queries.GetCategoryDetail;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryDetailRequestHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetCategoryDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            // get the category
            var category = await _unitOfWork.CategoryRepository.Get(request.Id);
            
            if(category == null)
                throw new NotFoundException(nameof(Domain.Entites.Categories.Category), request.Id);
            
            return _mapper.Map<CategoryDetailsDto>(category);
        }
    }
}
