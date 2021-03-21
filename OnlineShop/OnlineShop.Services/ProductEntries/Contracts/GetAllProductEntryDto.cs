using System;

namespace OnlineShop.Services.ProductEntries.Contracts
{
    public class GetAllProductEntryDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public string NumberFactor { get; set; }
        public DateTime CreateDate { get; set; }
    }
}