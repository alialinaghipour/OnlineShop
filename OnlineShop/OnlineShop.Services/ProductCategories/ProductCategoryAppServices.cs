using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories
{
    public class ProductCategoryAppServices : ProdcutCategoryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductCategoryRepository _repository;

        public ProductCategoryAppServices(UnitOfWork unitOfWork,ProductCategoryRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Add(AddProductCategoryDto dto)
        {
            ProductCategory productCategory = new ProductCategory()
            {
                Title = dto.Title
            };

            _repository.Add(productCategory);

            await _unitOfWork.ComplateAysnc();

            return productCategory.Id;
        }
    }
}
