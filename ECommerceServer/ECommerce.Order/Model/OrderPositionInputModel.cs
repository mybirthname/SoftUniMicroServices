using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Ordering.Model
{
    public class OrderPositionInputModel
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string PositionNr { get; set; }

        public string ProductNr { get; set; }

        public Guid ArticleID { get; set; }

        public decimal PricePerPQ { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }


    }
}
