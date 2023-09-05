using Application.Features.Products.Request.Query;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Query
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            return _mapper.Map<Product>(product);
        }
    }
}
