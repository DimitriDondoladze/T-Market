using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMarket.Application.DomainModels;
using TMarket.Application.Services.Abstract;
using TMarket.Persistence.DbModels;

namespace TMarket.Application.Services
{
   public interface ICartService : IService
    {
        IEnumerable<CartDTO> GetAllAsyncWithNoTracking();
        Task<bool> InsertOrderAsync(CartDomain cart);
    }
}
