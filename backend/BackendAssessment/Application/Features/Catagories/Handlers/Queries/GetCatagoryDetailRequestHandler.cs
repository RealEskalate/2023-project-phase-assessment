using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Catagory;
using Application.DTOs.Product;
using Application.Exceptions;
using Application.Features.Catagories.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Catagories.Handlers.Queries
{
    public class GetCatagoryDetailRequestHandler : IRequestHandler<GetCatagoryDetailRequest, CatagoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetCatagoryDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<CatagoryDto> Handle(GetCatagoryDetailRequest request, CancellationToken cancellationToken)
        {
            var catagory = await _unitOfWork.CatagoryRepository.Get(request.Id);
            
            if(catagory is null)
                throw new NotFoundException(nameof(catagory), request.Id);
                
            return _mapper.Map<CatagoryDto>(catagory);
        }
    }
}