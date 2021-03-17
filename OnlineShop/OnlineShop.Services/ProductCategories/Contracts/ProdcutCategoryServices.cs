using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProdcutCategoryServices
    {
        Task<int> Add(AddProductCategoryDto dto);
    }
}
