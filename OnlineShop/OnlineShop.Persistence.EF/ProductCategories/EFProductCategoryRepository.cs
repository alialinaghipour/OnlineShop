using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnlineShop.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCategoryRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductCategory> _set;

        public EFProductCategoryRepository(EFDataContext context)
        {
            _context = context;
            _set = context.ProductCategories;
        }

        public void Add(ProductCategory productCategory)
        {
            _set.Add(productCategory);
        }
    }
}
