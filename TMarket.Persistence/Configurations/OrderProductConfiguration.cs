using TMarket.Persistence.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TMarket.Persistence
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProductDTO>
    {
        public void Configure(EntityTypeBuilder<OrderProductDTO> builder)
        {
            builder.HasKey(op => new {op.ProductId, op.OrderId});
        }
    }
}