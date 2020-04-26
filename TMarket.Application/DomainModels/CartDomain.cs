using System;
using System.Collections.Generic;
using System.Text;

namespace TMarket.Application.DomainModels
{
   public class CartDomain
    {
        public ICollection<CartProductDomain> CartProducts { get; set; }
        public int UserId { get; set; }
    }
}
