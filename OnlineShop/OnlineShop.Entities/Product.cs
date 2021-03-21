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
            ProductEntries = new HashSet<ProductEntry>();
            SalesItems = new HashSet<SalesItem>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumStack { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public HashSet<WarehouseItem> WarehouseItems { get; set; }
        public HashSet<ProductEntry> ProductEntries { get; set; }
        public HashSet<SalesItem> SalesItems { get; set; }

    }
}
