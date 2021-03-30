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

    public class SalesItemDto
    {
        [Required]
        [MaxLength(20)]
        public string ProductCode { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}