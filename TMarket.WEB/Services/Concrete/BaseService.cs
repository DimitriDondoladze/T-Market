﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TMarket.Persistence.DbModels.Interfaces;
using TMarket.Persistence.Repositories.Abstract;
using TMarket.WEB.Services.Abstract;

namespace TMarket.WEB.Services.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : class, IDbEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(object id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsyncWithNoTracking(Func<T, bool> predicate)
        {
            var items = await _repository.GetAllAsyncWithNoTracking();

            return items.Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsyncWithNoTracking()
        {
            return await _repository.GetAllAsyncWithNoTracking();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetPaginatedResultAsyncAsNoTracking(int currentPage, int pageSize, string sortBy, bool isAsc)
        {
            var products = await _repository.GetAllAsyncWithNoTracking();
            var sortedProducts = isAsc ? products.AsQueryable().OrderBy(sortBy) :
                products.AsQueryable().OrderBy(sortBy + " descending");

            return sortedProducts.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task InsertAsync(T obj)
        {
            await _repository.InsertAsync(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            await _repository.UpdateAsync(obj);
        }
    }
}
