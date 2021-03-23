using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductCategories.Exceptions
{
    class ProductCategoryNotFoundException:Exception
    {
        public override string Message => "دسته بندی ، با این شناسه  وجود ندارد";
    }
}
