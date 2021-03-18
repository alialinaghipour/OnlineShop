using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        public override string Message => "محصولی یافت نشد";
    }
}
