using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Exceptions
{
     class DuplicateProductCodeException:Exception
    {
        public override string Message => "این کد محصول تکراری است";
    }
}
