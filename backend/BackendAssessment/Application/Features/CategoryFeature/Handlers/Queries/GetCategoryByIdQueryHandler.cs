using Application.Common;
using Application.Contracts;
using Application.DTO.Category.DTO;
using Application.Exceptions;
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
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIDQuery, BaseResponse<CategoryResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<CategoryResponseDTO>> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            var exists = await  _unitOfWork.CategoryRepository.Exists(request.CategoryId);
                
            if (!exists)
            {
                throw new NotFoundException("Category with this Id doesn't exist");
            }

            var result = await _unitOfWork.CategoryRepository.GetbyId(request.CategoryId);
            return new BaseResponse<CategoryResponseDTO>()
            {
                Success = true,
                Message = "the category is found",
                Value = _mapper.Map<CategoryResponseDTO>(result)
            };
        }
    }
}
