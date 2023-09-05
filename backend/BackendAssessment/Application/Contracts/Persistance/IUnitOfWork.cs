namespace Application.Contracts.Persistance;

public interface IUnitOfWork : IDisposable{
    ICategoryRepository CategoryRepository{ get;  }
    IProductRepository ProductRepository{ get; }
    Task<int> Save();
    
}