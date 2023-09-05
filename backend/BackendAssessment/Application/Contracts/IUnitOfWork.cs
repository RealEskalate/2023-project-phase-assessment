

namespace Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository {get;}
        ICategoryRepository CategoryRepository {get;}
        IBookingRepository BookingRepository {get;}
        Task<int> Save();
    }
}