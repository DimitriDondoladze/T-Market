using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using TMarket.Persistence.DbModels;

namespace WebApplication2.DAL.DAL.DapperRepo.Concrete
{
    public class ProductProccesor : IProductProcessor

    {
        private readonly string connectionString;
        public ProductProccesor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        IEnumerable<ProductDTO> IProductProcessor.get(int id)
        {
            IEnumerable<ProductDTO> ProductDtOs = null;
            using (var connection = new SqlConnection(connectionString))
            {
                ProductDtOs = connection.Query<ProductDTO>("SELECT [Id], [Name], [Price], [IsAvailable], [expiredate], [AvailableCount] FROM[MarketDb].[dbo].[Products]");
            }
            return ProductDtOs;
        }
    }
}
