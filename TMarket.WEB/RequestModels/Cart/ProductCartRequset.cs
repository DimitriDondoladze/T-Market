using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMarket.WEB.RequestModels.Cart
{
    public class ProductCartRequset
    {
        [Display(Name = "პროდუქტის აიდ")]
        public int ProductId { get; set; }
        [Display(Name = "პროდუქტის რაოდენობ")]
        public int Quantity { get; set; }
    }
}
