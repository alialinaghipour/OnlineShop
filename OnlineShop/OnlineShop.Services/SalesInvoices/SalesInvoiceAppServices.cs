using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.SalesInvoices.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesInvoices
{
    public class SalesInvoiceAppServices : SalesInvoiceServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SalesInovoiceRepository _repository;

        public SalesInvoiceAppServices(
            UnitOfWork unitOfWork,
            SalesInovoiceRepository salesInovoiceRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = salesInovoiceRepository;
        }

        public async Task<int> Add(AddSalesInvoiceDto dto)
        {
            await CheckedExistsByNumber(dto.Number);

            SalesInvoice salesInvoice = new SalesInvoice()
            {
                CreateDate = DateTime.Now,
                CustomerName = dto.CustomerName,
                Number = dto.Number
            };

            var accounting = new HashSet<AccountingDocument>()
            {
                 new AccountingDocument()
                {
                SalesInvoiceId = salesInvoice.Id,
                CreateDate = DateTime.Now,
                Number = DateTime.Now.ToString(),
                NumberInvoice = salesInvoice.Number,
                TotalPrice = 0
                }
            };

            salesInvoice.AccountingDocuments = accounting;

            _repository.Add(salesInvoice);

            _unitOfWork.Complate();

            return salesInvoice.Id;
        }

        private async Task CheckedExistsByNumber(string number)
        {
            if (await _repository.IsExistsByNumber(number))
            {
                throw new DuplicateInvoiceNumberException();
            }
        }
    }
}
