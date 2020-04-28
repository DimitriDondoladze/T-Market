using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TMarket.Persistence.DbModels;
using TMarket.WEB.RequestModels.Products;

namespace TMarket.WEB.Infrastructure
{
    public class ControllerExtensions
    {
		//public async Task<ActionResult<IEnumerable<ProductRespond>>> GetProducts([FromQuery] decimal minPrice)
		//{
		//	ParameterExpression pe = Expression.Parameter(typeof(ProductDTO), "predicate");

		//	MemberExpression me = Expression.Property(pe, "Price");

		//	ConstantExpression constant = Expression.Constant(minPrice, typeof(decimal));

		//	BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

		//	var ExpressionTree = Expression.Lambda<Func<ProductDTO, bool>>(body, new[] { pe });


		//}
		
	}
}
