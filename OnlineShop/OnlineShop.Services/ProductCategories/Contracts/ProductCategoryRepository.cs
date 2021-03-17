using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
    }
}
