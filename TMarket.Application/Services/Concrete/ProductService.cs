using System.Collections.Generic;
using TMarket.Persistence.DbModels;
using WebApplication2.DAL.DAL.DapperRepo;
using WebApplication2.Services.Abstract;

namespace WebApplication2.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductProcessor productProccesor;
        public ProductService (IProductProcessor productProccesor)
        {
            this.productProccesor = productProccesor;
        }
        
        public IEnumerable<ProductDTO> get(int id)
        {
            return productProccesor.get(id);
        }
    }
}
