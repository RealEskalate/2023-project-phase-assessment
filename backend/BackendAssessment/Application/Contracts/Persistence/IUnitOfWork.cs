namespace Application.Contracts.Persistence;


public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository{ get; }
    IProductRepository ProductRepository{ get; }
    ICategoryRepository CategoryRepository{ get; }
    IBookingRepository BookingRepository{ get; }
    Task<int> Save();

}