using ECommerce.Product.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Supplier> builder)
        {
            builder
                .HasKey(c => c.ID);

            builder
                .Property(c => c.Email);

            builder
                .Property(c => c.Name)
                .IsRequired();
        }
    }
}
