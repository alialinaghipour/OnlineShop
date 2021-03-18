using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.ProductCategories.Exceptions;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products
{
    public class ProductAppServices : ProductServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _repository;
        private readonly ProductCategoryRepository _productCategoryRepository;

        public ProductAppServices(UnitOfWork unitOfWork,ProductRepository repository,ProductCategoryRepository productCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<int> Add(AddProductDto dto)
        {
            await CheckedDuplicateByCode(dto.Code);

            await CheckedExistsProductCategory(dto.ProductCategoryId);

            await CheckedExistsTitleToProdcutCategory(dto.Title, dto.ProductCategoryId);

            Product product = new Product()
            {
                ProductCategoryId = dto.ProductCategoryId,
                MinimumStack = dto.MinimumStack,
                Code = dto.Code,
                Title = dto.Title
            };

            var warehouseItem = new HashSet<WarehouseItem>()
            {
                new WarehouseItem()
                {
                    ProductId=product.Id,
                    Count=0
                }
            };

            product.WarehouseItems = warehouseItem;

            _repository.Add(product);

            
           await _unitOfWork.ComplateAysnc();

            return product.Id;
        }

        private async Task CheckedExistsProductCategory(int productCategoryId)
        {
            if(!await _productCategoryRepository.IsExistsById(productCategoryId))
            {
                throw new NotExistByProductCategoryIdException();
            }
        }

        private async Task CheckedDuplicateByCode(string code)
        {
            if(await _repository.IsExistsByCode(code))
            {
                throw new DuplicateProductCodeException();
            }
        }

        private async Task CheckedExistsTitleToProdcutCategory(string title,int productCategoryId)
        {
            if(await _repository.IsExistsTitleToProductCategory(title, productCategoryId))
            {
                throw new ProductTitleDuplicateToProductCategoryException();
            }
        }

        public async Task<GetByIdProductDto> GetById(int id)
        {
            await CheckedExistsById(id);
            return await _repository.GetById(id);
        }

        private async Task CheckedExistsById(int id)
        {
            if(!await _repository.IsExistsById(id))
            {
                throw new ProductNotFoundException();
            }
        }
    }
}
