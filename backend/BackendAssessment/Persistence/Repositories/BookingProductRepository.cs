using Application.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BookingProductRepository : GenericRepository<BookProduct>, IBookingProductRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public BookingProductRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }

}