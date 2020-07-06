using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Supplier.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Data.Supplier>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Data.Supplier> builder)
        {
            builder
                .HasKey(c => c.ID);

            builder
                .Property(c => c.NrIntern)
                .IsRequired();

            builder
                .Property(c => c.Name)
                .IsRequired();
        }
    }
}
