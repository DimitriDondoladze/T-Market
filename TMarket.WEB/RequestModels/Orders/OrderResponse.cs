using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TMarket.WEB.RequestModels.Orders
{
    public class OrderResponse
    {
        [DisplayName("პროდუქტის აიდ")]
        public ICollection<ProductOrderResponse> OrderProducts { get; set; }
        [DisplayName("იუზერის აიდ")]
        public int UserId { get; set; }
        public decimal OrderTotalPrice
        {
            get => OrderProducts.Sum(x => x.TotalPrice);
        }
    }
}
