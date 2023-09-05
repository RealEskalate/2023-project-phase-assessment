using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Catagory;
using Application.Features.Catagories.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Catagories.Handlers.Queries
{
    public class GetAllCatagoriesRequestHandler : IRequestHandler<GetAllCatagoriesRequest, List<CatagoryListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetAllCatagoriesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<List<CatagoryListDto>> Handle(GetAllCatagoriesRequest request, CancellationToken cancellationToken)
        {
            var catagories = await _unitOfWork.CatagoryRepository.GetAll(request.PageIndex, request.PageSize);
            return _mapper.Map<List<CatagoryListDto>>(catagories);
        }
    }
}