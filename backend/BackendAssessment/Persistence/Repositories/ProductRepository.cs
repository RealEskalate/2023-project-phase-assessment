﻿using Application.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository 
    {

        public ProductRepository(ProductListingServiceDbContext dbContext) : base(dbContext)
        {

        }
    }
}
