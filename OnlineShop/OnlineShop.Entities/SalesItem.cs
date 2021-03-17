namespace OnlineShop.Entities
{
    public class SalesItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public int SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}