using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Product.Data
{
    public class ProductDbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
