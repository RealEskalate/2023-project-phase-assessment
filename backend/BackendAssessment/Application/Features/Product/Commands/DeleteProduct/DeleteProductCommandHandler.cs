using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id);
            
            if(product == null)
                throw new NotFoundException(nameof(Domain.Entites.Products.Product), request.Id);
            
            if(_userService.UserId != product.UserId.ToString() && !await _userService.IsAdmin())
                throw new UnauthorizedAccessException("Not Authorized To Delete Product");
            
            //delete the product
            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
