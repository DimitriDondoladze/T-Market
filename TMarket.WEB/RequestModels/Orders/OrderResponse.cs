﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TMarket.WEB.RequestModels.Orders
{
    public class OrderResponse
    {
        [Display(Name="პროდუქტის აიდ")]
        public ICollection<ProductOrderResponse> OrderProducts { get; set; }
        [Display(Name="იუზერის აიდ")]
        public int UserId { get; set; }
        public decimal OrderTotalPrice
        {
            get => OrderProducts.Sum(x => x.TotalPrice);
        }
    }
}
