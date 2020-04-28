using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using TMarket.Persistence.DbModels;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace WebApplication2.DAL.DAL.DapperRepo.Concrete
{
    public class ProductProccesor : IProductProcessor

    {
        private readonly string connectionString;
        public ProductProccesor(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

     public  ProductDTO get(int id)
        {
            IEnumerable<ProductDTO> ProductDtOs = null;
            using (var connection = new SqlConnection(connectionString))
            {
                ProductDtOs = connection.Query<ProductDTO>($"SELECT [Id], [Name], [Price], [IsAvailable], [UsefulnessTerm], [AvailableCount] FROM[MarketDb].[dbo].[Products] Where dbo.Products.Id = {id}");
            }
            return ProductDtOs.FirstOrDefault();
        }
    }
}
