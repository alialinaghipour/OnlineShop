using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Exceptions
{
    public class ProductTitleDuplicateToProductCategoryException:Exception
    {
        public override string Message => "عنوان محصول تکراری است";
    }
}
