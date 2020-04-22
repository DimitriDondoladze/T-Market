using System.Collections.Generic;
using System.Threading.Tasks;
using TMarket.Persistence.DbModels;
using TMarket.WEB.RequestModels.Orders;

namespace TMarket.WEB.Services.Abstract
{
    public interface IOrderService : IService
    {
        IEnumerable<OrderDTO> GetAllAsyncWithNoTracking();
        Task<bool> InsertOrderAsync(OrderRequest order);
    }
}
