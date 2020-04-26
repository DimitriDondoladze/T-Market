using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TMarket.Persistence.DbModels.Interfaces;

namespace TMarket.Persistence.DbModels
{
   public class CartProductDTO : IDbEntity
    {
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }

        public int CartId { get; set; }
        public CartDTO Cart { get; set; }

        [NotMapped]
        public bool IsDeleted { get => ((IDbEntity)Cart).IsDeleted; set => ((IDbEntity)Cart).IsDeleted = value; }
        [NotMapped]
        public DateTime InsertDate { get => ((IDbEntity)Cart).InsertDate; set => ((IDbEntity)Cart).InsertDate = value; }
        [NotMapped]
        public DateTime UpdateDate { get => ((IDbEntity)Cart).UpdateDate; set => ((IDbEntity)Cart).UpdateDate = value; }
        [NotMapped]
        public DateTime DeleteDate { get => ((IDbEntity)Cart).DeleteDate; set => ((IDbEntity)Cart).DeleteDate = value; }
        
    }
}
