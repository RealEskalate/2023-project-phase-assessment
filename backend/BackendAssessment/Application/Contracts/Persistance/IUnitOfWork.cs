using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IProductRepository productRepository { get; }
        ICategoryRepository categoryRepository { get; }
        IProductCategoryRepository productCategoryRepository { get; }
        Task<int> Save();
    }
}
