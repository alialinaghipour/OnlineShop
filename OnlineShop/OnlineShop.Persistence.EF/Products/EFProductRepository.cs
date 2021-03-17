using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Products
{

    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<Product> _set;

        public EFProductRepository(EFDataContext context)
        {
            _context = context;
            _set = context.Products;
        }

        public void Add(Product product)
        {
            _set.Add(product);
        }

        public async Task<bool> IsExistsByCode(string code)
        {
            return await _set.AnyAsync(_ => _.Code==code);
        }

        public async Task<bool> IsExistsTitleToProductCategory(string title, int productCategoryId)
        {
            return await _set.AnyAsync(_ => _.Title == title && _.ProductCategoryId == productCategoryId);
        }
    }
}
