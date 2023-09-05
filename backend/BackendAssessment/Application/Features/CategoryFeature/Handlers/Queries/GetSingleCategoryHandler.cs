using Application.Contracts;
using Application.DTO.CategoryDTO.DTO;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;


namespace Application.Features.CategoryFeature.Handlers.Queries
{
    public class GetSingleCategoryHandler : IRequestHandler<GetSingleCategoryQuery, BaseResponse<CategoryResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSingleCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<CategoryResponseDTO>> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CategoryRepository.Get(request.Id);
            if (result == null)
            {
                throw new NotFoundException("Category is not found");
            }

            var Category = _mapper.Map<CategoryResponseDTO>(result);
            
            return new BaseResponse<CategoryResponseDTO>{
                Success = true,
                Message = "Category is retrieved successfully",
                Value = Category
            };
            
        }
    }
}
