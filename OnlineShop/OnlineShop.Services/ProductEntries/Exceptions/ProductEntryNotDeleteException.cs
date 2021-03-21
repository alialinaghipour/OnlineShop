using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductEntries.Exceptions
{
    class ProductEntryNotDeleteException:Exception
    {
        public override string Message => "این تعداد کالا در انبار موجود نیست";
    }
}
