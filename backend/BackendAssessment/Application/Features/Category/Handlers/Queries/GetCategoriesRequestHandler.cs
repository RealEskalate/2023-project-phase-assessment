using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Features.Category.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Queries
{
    public class GetCategoriesRequestHandler: IRequestHandler<GetCategoriesRequest, List<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetCategoriesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<List<CategoryDto>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}