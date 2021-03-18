using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public class AddProductCategoryDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}