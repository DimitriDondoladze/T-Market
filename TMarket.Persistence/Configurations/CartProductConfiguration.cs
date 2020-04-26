using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TMarket.Persistence.DbModels;

namespace TMarket.Persistence.Configurations
{
    class CartProductConfiguration : IEntityTypeConfiguration<CartProductDTO>
    {
        public void Configure(EntityTypeBuilder<CartProductDTO> builder)
        {
            builder.HasKey(op => new { op.ProductId, op.CartId });
        }
    }
}
