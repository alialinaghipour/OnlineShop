using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.SalesInvoices.Exceptions;
using OnlineShop.Services.SalesItems.Contracts;
using OnlineShop.Services.WarehouseItems.Contracts;
using OnlineShop.Services.WarehouseItems.Exceprions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesItems
{
    public class SalesItemAppServices : SalesItemServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SalesItemsRepository _repository;
        private readonly SalesInovoiceRepository _salesInovoiceRepository;
        private readonly WarehouseItemRepository _warehouseItemRepository;

        public SalesItemAppServices(
            UnitOfWork unitOfWork,
            SalesItemsRepository repository,
            SalesInovoiceRepository salesInovoiceRepository,
            WarehouseItemRepository warehouseItemRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _salesInovoiceRepository = salesInovoiceRepository;
            _warehouseItemRepository = warehouseItemRepository;
        }

        public async Task<int> Add(AddSalesItemDto dto)
        {
            var salesInvoice =await _salesInovoiceRepository.FindByNumber(dto.NumberInvoice);
            CheckedExistsSalesInvoice(salesInvoice);

            var warehouse = await _warehouseItemRepository.FindByProductCode(dto.ProductCode);
            CheckedExistsProduct(warehouse);

            CheckedStockInWarehouse(warehouse.Count, dto.Count);

            SalesItem salesItem = new SalesItem()
            {
                Count = dto.Count,
                SalesInvoiceId = salesInvoice.Id,
                ProductId = warehouse.ProductId,
                Price = dto.Price
            };


            foreach(var item in  salesInvoice.AccountingDocuments)
            {
                item.TotalPrice += dto.Price * dto.Count;
            }

            warehouse.Count -= salesItem.Count;

            _repository.Add(salesItem);

            await _unitOfWork.ComplateAysnc();

            return salesItem.Id;
        }

        private void CheckedStockInWarehouse(int warehouseCount,int salesCount)
        {
            if (warehouseCount < salesCount || warehouseCount==0)
            {
                throw new NotStockInWarehouseException();
            }
        }

        private void CheckedExistsProduct(WarehouseItem warehouse)
        {
            if (warehouse == null)
            {
                throw new ProductNotFoundException();
            }
        }

        private void CheckedExistsSalesInvoice(Entities.SalesInvoice salesInvoice)
        {
            if (salesInvoice == null)
            {
                throw new SalesInvoiceNotFoundException();
            }
        }
    }
}
