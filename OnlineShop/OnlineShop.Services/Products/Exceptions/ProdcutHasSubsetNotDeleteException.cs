using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Exceptions
{
    class ProdcutHasSubsetNotDeleteException:Exception
    {
        public override string Message => "این محصول قابلیت حذف ندارد";
    }
}
