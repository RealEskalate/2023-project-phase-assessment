using Application.Common;
using Application.Contracts;
using Application.DTO.Category.DTO;
using Application.Features.CategoryFeature.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Handlers.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, BaseResponse<List<CategoryResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<List<CategoryResponseDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CategoryRepository.GetAll();
            return new BaseResponse<List<CategoryResponseDTO>>()
            {
                Success = true,
                Message = "All categories",
                Value = _mapper.Map<List<CategoryResponseDTO>>(result)
            };
        }
    }
}
