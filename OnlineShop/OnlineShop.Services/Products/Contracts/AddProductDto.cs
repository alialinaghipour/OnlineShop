using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.Products.Contracts
{
    public class AddProductDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        public int MinimumStack { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }
    }
}