using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using Persistence.Data;

namespace Persistence.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Category> AddCategory(Category category)
        {
           _context.Categories.Add(category);
            if (_context.SaveChanges() <= 0)
            {
            return Task.FromResult<Category>(null);
            }
            return Task.FromResult(category);

        }

        public Task<bool> Exists(int id)
        {
            return Task.FromResult(_context.Categories.Find(id) != null);
        }

        public Task<List<Category>> GetAllCategories()
        {
            return Task.FromResult(_context.Categories.ToList());
        }

        public Task<Category> GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            return Task.FromResult(category);
        }

        public Task<Category> GetCategoryByName(string name)
        {
            return Task.FromResult(_context.Categories.FirstOrDefault(x => x.Name == name));
        }

        public Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            if (_context.SaveChanges() <= 0)
            {
                return Task.FromResult<Category>(null);
            }
            return Task.FromResult(category);
        }
    }
}