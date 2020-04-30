using System.Collections.Generic;

namespace TMarket.Application.DomainModels
{
    public class OrderDomain
    {
        public int Id { get; set; }
        public ICollection<OrderProductDomain> OrderProducts { get; set; }
        public int UserId { get; set; }
    }
}