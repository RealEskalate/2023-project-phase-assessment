using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public IBookingProductRepository BookingProductRepository { get; }
        public Task<int> Save();
    }
}
