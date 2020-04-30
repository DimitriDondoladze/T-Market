using System.Collections.Generic;
using TMarket.Persistence.DbModels;

namespace WebApplication2.Services.Abstract
{
    public interface IProductService
    {
        ProductDTO get(object id);
        void Create(ProductDTO productDTO);

        void Update(ProductDTO productDTO, int id);
        void Delete(int Id);
    }
}
