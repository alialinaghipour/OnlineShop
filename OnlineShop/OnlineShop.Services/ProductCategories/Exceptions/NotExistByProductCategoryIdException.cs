using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductCategories.Exceptions
{
    public class NotExistByProductCategoryIdException:Exception
    {
        public override string Message => "دسته بندی ، با این شناسه  وجود ندارد";
    }
}
