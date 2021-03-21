using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.WarehouseItems.Exceprions
{
    class ThisProductIsToWarehouseItemException:Exception
    {
        public override string Message => "این محصول در انبار دارای موجودی است";
    }
}
