using OnlineShop.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
        Task<IList<GetAllProductCategoryDto>> GetAll();
    }
}
