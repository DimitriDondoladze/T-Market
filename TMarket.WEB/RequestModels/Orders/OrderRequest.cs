using System.Collections.Generic;
using System.ComponentModel;

namespace TMarket.WEB.RequestModels.Orders
{
    public class OrderRequest
    {
        [DisplayName("პროდუქტის ლისტ")]
        public ICollection<ProductOrderRequest> OrderProducts { get; set; }
        [DisplayName("იუზერის აიდ")]
        public int UserId { get; set; }
    }
}
