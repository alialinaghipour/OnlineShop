using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Exceptions
{
    class ProductNotFoundException:Exception
    {
        public override string Message => "محصولی یافت نشد";
    }
}
