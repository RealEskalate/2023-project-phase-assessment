using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.Exceptions;
using Application.Features.Catagories.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Catagories.Handlers.Commands
{
    public class DeleteCatagoryCommandHandler : IRequestHandler<DeleteCatagoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCatagoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCatagoryCommand request, CancellationToken cancellationToken)
        {
            var catagory = await _unitOfWork.CatagoryRepository.Get(request.Id);

            if (catagory == null)
                throw new NotFoundException(nameof(catagory), request.Id);

            // if (catagory.UserId != request.RequestingUserId)
            //     throw new UnauthorizedAccessException("User is not authorized.");

            await _unitOfWork.CatagoryRepository.Delete(catagory);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}