using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entites;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository( SocialMediaDbContext _Context) : base(_Context){}
    }
}