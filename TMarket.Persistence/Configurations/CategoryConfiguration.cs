using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TMarket.Persistence.DbModels;

namespace TMarket.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryDTO>
    {
        public void Configure(EntityTypeBuilder<CategoryDTO> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}
