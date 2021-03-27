using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.ProductCategories.Exceptions;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.WarehouseItems.Contracts;
using OnlineShop.Services.WarehouseItems.Exceprions;
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
        private readonly WarehouseItemRepository _warehouseItemRepository;

        public ProductAppServices(
            UnitOfWork unitOfWork,
            ProductRepository repository,
            ProductCategoryRepository productCategoryRepository,
            WarehouseItemRepository warehouseItemRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productCategoryRepository = productCategoryRepository;
            _warehouseItemRepository = warehouseItemRepository;
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
                throw new ProductCategoryNotFoundException();
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
            var product = await _repository.FindById(id);
            CheckedExistsProduct(product);

            GetByIdProductDto dto = new GetByIdProductDto()
            {
                Id = product.Id,
                Code = product.Code,
                MinimumStack = product.MinimumStack,
                ProductCategoryId = product.ProductCategoryId,
                Title = product.Title
            };

            return dto;
        }

        private void CheckedExistsProduct(Product prdouct)
        {
            if (prdouct == null)
            {
                throw new ProductNotFoundException();
            }
        }

        public async Task Delete(int id)
        {
            var prdouct = await _repository.FindById(id);
            CheckedExistsProduct(prdouct);

            CheckedProductSubsetByCount(prdouct.ProductEntries.Count);
            CheckedProductSubsetByCount(prdouct.SalesItems.Count);

            var warehouseItem = await _warehouseItemRepository.FindByProductCode(prdouct.Code);
            _warehouseItemRepository.Delete(warehouseItem);

            _repository.Delete(prdouct);

            await _unitOfWork.ComplateAysnc();
        }

        private void CheckedProductSubsetByCount(int subsetCount)
        {
            if (subsetCount > 0)
            {
                throw new ProdcutHasSubsetNotDeleteException();
            }
        }
    }
}
