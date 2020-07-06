using Ecommerce.Product.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Data.Configuration
{
    internal class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder
                .HasKey(c => c.ID);

            builder
                .Property(c => c.PricePerPQ)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(c => c.NrIntern)
                .IsRequired();

            builder
                .Property(c => c.Title)
                .IsRequired();

        }
    }
}
