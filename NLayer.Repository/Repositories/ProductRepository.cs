﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext){

        }

        /// <summary>
        /// Ürünün bağlı olduğu kategorileri getirir.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProductsWithCategory() {
            return await _appDbContext.Products.Include(p => p.Category).ToListAsync();
            //eager loading: datayı çekerken kategorilerin de alınmasını istedik
        }
    }
}
