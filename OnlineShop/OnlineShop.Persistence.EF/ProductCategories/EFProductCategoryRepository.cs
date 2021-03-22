using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCategoryRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductCategory> _set;

        public EFProductCategoryRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductCategories;
        }

        public void Add(ProductCategory productCategory)
        {
            _set.Add(productCategory);
        }

        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllProductCategoryDto()
            {
                Id = _.Id,
                Title = _.Title
            }).ToListAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);
        }
    }
}
