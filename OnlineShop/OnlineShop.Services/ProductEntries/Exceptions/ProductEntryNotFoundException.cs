using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductEntries.Exceptions
{
    class ProductEntryNotFoundException:Exception
    {
        public override string Message => "این ورودی موجود نیست";
    }
}
