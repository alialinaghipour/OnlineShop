using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductEntries.Contracts;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.WarehouseItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductEntries
{
    public class ProductEntryAppServices : ProductEntryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductEntryRepository _repository;
        private readonly WarehouseItemRepository _warehouseRepository;

        public ProductEntryAppServices
            (UnitOfWork unitOfWork,
            ProductEntryRepository repository,
            WarehouseItemRepository warehouseRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<int> Add(AddProductEntryDto dto)
        {
            var warehouse = await _warehouseRepository.FindByProductCode(dto.ProductCode);

            CheckedWarehouseByProductCode(warehouse);

            ProductEntry productEntry = new ProductEntry()
            {
                Count = dto.Count,
                ProductId = warehouse.ProductId,
                CreateDate = DateTime.Now,
                NumberFactor = dto.NumberFactor,
            };

            _repository.Add(productEntry);

            warehouse.Count += productEntry.Count;

            await _unitOfWork.ComplateAysnc();

            return productEntry.Id;
        }

        private void CheckedWarehouseByProductCode(WarehouseItem warehouse)
        {
            if (warehouse == null)
            {
                throw new ProductNotFoundException();
            }
        }
    }
}
