using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class WarehouseItem
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
