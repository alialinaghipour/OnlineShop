using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class Product
    {
        public Product()
        {
            WarehouseItems = new HashSet<WarehouseItem>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumStack { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public HashSet<WarehouseItem> WarehouseItems { get; set; }

    }
}
