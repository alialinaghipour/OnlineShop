using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.SalesItems.Contracts
{
    public class AddSalesItemDto
    {
        [Required]
        [MaxLength(20)]
        public string NumberInvoice { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProductCode { get; set; }

        [Required]
        [Range(1,1000)]
        public int Count { get; set; }

        
        public decimal Price { get; set; }
    }
}