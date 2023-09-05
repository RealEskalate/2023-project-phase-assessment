using Application.Contracts;
using AutoMapper;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaDbContext _dbContext;
        private readonly IMapper _mapper;
        IProductRepository _ProductRepository;
        ICategoryRepository _CategoryRepository;
        public UnitOfWork(SocialMediaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IProductRepository ProductRepository
        {
            get{
                if (_ProductRepository == null){
                    _ProductRepository = new ProductRepository(_dbContext);
                }
                return _ProductRepository;
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get{
                if (_CategoryRepository == null){
                    _CategoryRepository = new CategoryRepository(_dbContext);
                }
                return _CategoryRepository;
            }
        }

        public IBookingRepository BookingRepository => throw new NotImplementedException();

        ICategoryRepository IUnitOfWork.CategoryRepository => throw new NotImplementedException();

        public void Dispose()
        {
             _dbContext.Dispose();
        GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}