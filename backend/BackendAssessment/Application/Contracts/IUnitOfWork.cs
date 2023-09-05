using  Application.Contracts;
namespace Application.Contracts;

public interface IUnitOfWork : IDisposable
{ 
    IUserRepository userRepository{ get; }
    IProductRepository productRepository{ get;  }
    ICategoryRepository categoryRepository{ get;  }

    Task<int> Save();

}