using Application.Contracts;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, CreateProductDTO>
    {
        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;

        public GetProductRequestHandler(IProductRepository i, IMapper mapper)
        {
            _Repository = i;
            _mapper = mapper;
        }
        public async Task<CreateProductDTO> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var res = await _Repository.Get(request.Id)!;

            if (res == null)
            {
                throw new Exception();
            }

            var categoryResponse = _mapper.Map<CreateProductDTO>(res);
            return categoryResponse;
        }
    }
}
