using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class ProductEntry
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string NumberFactor { get; set; }
        public DateTime CreateDate { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }
    }
}
