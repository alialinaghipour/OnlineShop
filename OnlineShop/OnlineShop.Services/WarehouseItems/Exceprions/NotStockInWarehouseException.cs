using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.WarehouseItems.Exceprions
{
    class NotStockInWarehouseException:Exception
    {
        public override string Message => "موجودی کم است";
    }
}
