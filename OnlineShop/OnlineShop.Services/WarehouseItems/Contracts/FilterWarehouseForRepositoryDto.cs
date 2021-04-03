using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public class FilterWarehouseForRepositoryDto
    {
        public string Filter { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsAscending { get; set; }
    }
}
