using Ecommerce.Product.Data.Models;
using ECommerce.Common.Data;
using ECommerce.Product.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ecommerce.Product.Data
{
    public class ProductDbContext : MessageDbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) :base(options)
        {

        }

        public DbSet<ProductItem> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductItemList> ProductItemList { get; set; }

        protected override Assembly ConfigureAssembly => Assembly.GetExecutingAssembly();
    }
}
