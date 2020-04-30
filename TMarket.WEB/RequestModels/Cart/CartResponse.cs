using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TMarket.WEB.RequestModels.Cart;

namespace TMarket.WEB.RequestModels
{
    public class CartResponse
    {
        public int Id { get; set; }
        [Display(Name = "პროდუქტის აიდ")]
        public ICollection<ProductCartResponse> CartProducts { get; set; }
        [Display(Name = "იუზერის აიდ")]
        public int UserId { get; set; }
        public decimal OrderTotalPrice
        {
            get => CartProducts.Sum(x => x.TotalPrice);
        }
    }
}
