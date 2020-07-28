using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Common.Messages.Supplier
{
    public class SupplierCreatedMessage
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid SupplierID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
