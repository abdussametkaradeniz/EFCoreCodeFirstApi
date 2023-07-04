using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, Name = "kalem 1", CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now });
            builder.HasData(new Product { Id = 2, Name = "kalem 3", CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now });
            builder.HasData(new Product { Id = 3, Name = "kitap 1", CategoryId = 2, Price = 100, Stock = 20, CreatedDate = DateTime.Now });
            builder.HasData(new Product { Id = 4, Name = "kitap 2", CategoryId = 2, Price = 100, Stock = 20, CreatedDate = DateTime.Now });
        }
    }
}
