using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.SalesInvoices.Contracts
{
    public class AddSalesInvoiceDto
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Number { get; set; }

        public HashSet<SalesItemDto> SalesItemDtos { get; set; }
    }
}