using Application.Contracts;
using Application.DTOs.Product;
using Application.DTOs.User;
using Application.Features.Products.Request.Command;
using AutoMapper;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CreateProductDTO>
    {
        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository i, IMapper mapper)
        {
            _Repository = i;
            _mapper = mapper;
        }
        public async Task<CreateProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _Repository.Get(request.id)!;
            if (product == null)
            {
                throw new Exception();
            }

            var categoryToUpdate = _mapper.Map(request, product);
            var updatedCategory = await _Repository.Update(categoryToUpdate);
            return _mapper.Map<CreateProductDTO>(updatedCategory);
        }
    }
}
