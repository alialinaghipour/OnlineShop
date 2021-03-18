using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.ProductEntries.Contracts
{
    public class AddProductEntryDto
    {
        [Required]
        [Range(1,1000)]
        public int Count { get; set; }

        [Required]
        [StringLength(20)]
        public string NumberFactor { get; set; }

        [Required]
        [StringLength(20)]
        public string ProductCode { get; set; }
    }
}