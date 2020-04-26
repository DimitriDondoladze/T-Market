using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMarket.Persistence.DbModels.Interfaces;

namespace TMarket.Application.Services.Abstract
{
    public interface IBaseService<T> : IService where T : class, IDbEntity
    {
        Task<IEnumerable<T>> GetAllAsyncWithNoTracking();
        Task<IEnumerable<T>> GetPaginatedResultAsyncAsNoTracking(int currentPage, int pageSize, string sortBy, bool isAsc);
        Task<IEnumerable<T>> FindAllAsyncWithNoTracking(Func<T, bool> predicate);
        Task<T> GetByIdAsync(object id);
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> DeleteAsync(object id);
    }
}
