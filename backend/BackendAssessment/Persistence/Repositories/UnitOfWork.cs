using Application.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IBookingProductRepository _bookingProductRepository;




        private readonly ProductHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(ProductHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }

                return _productRepository;
            }
        }


        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbContext);
                }

                return _categoryRepository;
            }
        }

        public IBookingProductRepository BookingProductRepository
        {
            get
            {
                if (_bookingProductRepository == null)
                {
                    _bookingProductRepository = new BookingProductRepository(_dbContext);
                }

                return _bookingProductRepository;
            }
        }

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
