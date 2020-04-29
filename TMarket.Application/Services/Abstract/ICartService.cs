using System.Collections.Generic;
using System.Threading.Tasks;
using TMarket.Application.DomainModels;
using TMarket.Application.Services.Abstract;
using TMarket.Persistence.DbModels;

namespace TMarket.Application.Services
{
    public interface ICartService : IService
    {
        IEnumerable<CartDTO> GetAllWithNoTracking();
        Task<bool> InsertOrderAsync(CartDomain cart);
        Task DeleteCart(int id);
    }
}
