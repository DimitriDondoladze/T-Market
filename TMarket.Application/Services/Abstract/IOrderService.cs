using System.Collections.Generic;
using System.Threading.Tasks;
using TMarket.Application.DomainModels;
using TMarket.Persistence.DbModels;

namespace TMarket.Application.Services.Abstract
{
    public interface IOrderService : IService
    {
        IEnumerable<OrderDTO> GetAllAsyncWithNoTracking();
        Task<bool> InsertOrderAsync(OrderDomain order);
    }
}
