using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void Add(Product product);
        Task<bool> IsExistsTitleToProductCategory(string title, int productCategoryId);
        Task<bool> IsExistsByCode(string code);
    }
}
