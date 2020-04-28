using System.Collections.Generic;
using TMarket.Persistence.DbModels;

namespace WebApplication2.DAL.DAL.DapperRepo
{
    public interface IProductProcessor
    {
        IEnumerable<ProductDTO> get(int id);
    }
}
