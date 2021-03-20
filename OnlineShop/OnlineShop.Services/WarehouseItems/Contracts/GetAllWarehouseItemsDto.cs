namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public class GetAllWarehouseItemsDto
    {
        public string ProductCode { get; set; }
        public string productName { get; set; }
        public string ProductCategroy { get; set; }
        public int Stock { get; set; }
        public int MinimumStock { get; set; }
        public string Status 
        {
            get
            {
                if (Stock > MinimumStock)
                {
                  return  "Available";
                }else if (Stock == MinimumStock)
                {
                    return "Ready to order";
                }
                else
                {
                    return "No-Avalable";
                }
            }
        }
    }
}