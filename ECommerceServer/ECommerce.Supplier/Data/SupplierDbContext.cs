using ECommerce.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ECommerce.Supplier.Data
{
    public class SupplierDbContext : MessageDbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override Assembly ConfigureAssembly => Assembly.GetExecutingAssembly();

    }
}
