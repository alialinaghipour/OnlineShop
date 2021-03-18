namespace OnlineShop.Services.Products.Contracts
{
    public class GetByIdProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumStack { get; set; }
        public int ProductCategoryId { get; set; }
    }
}