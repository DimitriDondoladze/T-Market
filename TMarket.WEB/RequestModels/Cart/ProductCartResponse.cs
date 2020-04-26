using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMarket.WEB.RequestModels.Cart
{
    public class ProductCartResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get => ProductPrice * Quantity;
        }
    }
}
