using System.ComponentModel;

namespace TMarket.WEB.RequestModels.Orders
{
    public class ProductOrderRequest
    {
        [DisplayName("პროდუქტის აიდ")]
        public int ProductId { get; set; }
        [DisplayName("პროდუქტის რაოდენობ")]
        public int Quantity { get; set; }
    }
}
