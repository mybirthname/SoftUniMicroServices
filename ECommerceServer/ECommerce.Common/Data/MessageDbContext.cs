using ECommerce.Common.Data.Configuration;
using ECommerce.Common.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ECommerce.Common.Data
{
    public abstract class MessageDbContext: DbContext
    {
        public MessageDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }

        protected abstract Assembly ConfigureAssembly { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(this.ConfigureAssembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
