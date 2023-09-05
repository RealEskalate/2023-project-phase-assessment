using Application.Contracts;
using Application.DTOs.Categorys;
using Application.Features.Categorys.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Handlers.Queries
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<CategoryDetailsDto>>
    {

        ICategoryRepository _categoryRepo;
        IMapper _mapper;

        public GetAllCategoriesRequestHandler(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public async Task<List<CategoryDetailsDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            
            var categories = await _categoryRepo.GetAll();

            return _mapper.Map<List<CategoryDetailsDto>>(categories);
        }
    }
}
