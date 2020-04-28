using System.Collections.Generic;
using TMarket.Persistence.DbModels;

namespace WebApplication2.Services.Abstract
{
    public interface IProductService
    {
        ProductDTO get(int id);
    }
}
