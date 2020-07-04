using ECommerce.Order.Data.Models;
using ECommerce.Ordering.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ECommerce.Ordering.Data
{
    public class OrderingDbContext : DbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options)
        {

        }

        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderPosition> OrderPosition { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartPosition> ShoppingCartPosition { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
