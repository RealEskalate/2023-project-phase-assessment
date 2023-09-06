using Application.Contracts;
using Application.DTOs.Product;
using Application.DTOs.User;
using Application.Features.Products.Request.Command;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDTO>
    {

        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository i, IMapper mapper)
        {
            _Repository = i;
            _mapper = mapper;
        }
        public async Task<CreateProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var result = await _Repository.Add(product);

            var response = _mapper.Map<CreateProductDTO>(result);
            return response;
        }
    }
}
