using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMarket.Persistence.DbModels;
using TMarket.WEB.Helpers.Constants;
using TMarket.WEB.Helpers.Extensions;
using TMarket.Application.Services.Abstract;
using TMarket.WEB.RequestModels.Products;
using System.Linq.Expressions;

namespace TMarket.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseService<ProductDTO> _productService;
        private readonly IMapper _mapper;

        public ProductsController(IBaseService<ProductDTO> productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductRespond>> GetProducts(
            [FromQuery] string name, [FromQuery] decimal minPrice,
            [FromQuery] decimal maxPrice)
        {
            //Expression<Func<ProductDTO, bool>> predicate = p => p.Name.ToUpper().StartsWithOrNull(name.ToUpper()) &&
            //    p.Price >= minPrice && p.Price.LessOrEmptyInput(maxPrice);
            Expression<Func<ProductDTO, bool>> predicate = Predicate(minPrice, maxPrice, name);

            var products =  _productService.FindAllAsyncWithNoTracking(predicate);

            return _mapper.Map<List<ProductRespond>>(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRespond>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound(string.Format(ModelConstants.PropertyNotFoundFromController, "პროდუქტი"));
            }

            return _mapper.Map<ProductRespond>(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductRequest product)
        {
            var products = await _productService.GetAllAsyncWithNoTracking();
            if (!products.Any(x => x.Id == id))
            {
                return BadRequest(string.Format(ModelConstants.PropertyNotFoundFromController, "პროდუქტი"));
            }

            await _productService.UpdateAsync(_mapper.Map<ProductDTO>(product));

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductRespond>> PostProduct(ProductRequest product)
        {
            await _productService.InsertAsync(_mapper.Map<ProductDTO>(product));

            return CreatedAtAction("GetProduct", product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductRespond>> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return BadRequest(string.Format(ModelConstants.PropertyNotFoundFromController, "პროდუქტი"));
            }

            await _productService.DeleteAsync(id);
            return _mapper.Map<ProductRespond>(product);
        }

        [HttpGet("GetPaginatedResult")]
        public async Task<ActionResult<IEnumerable<ProductRespond>>> GetPaginatedResult
            (int currentPage = 1, int pageSize = 5, string sortBy = "Id", bool isAsc = true)
        {
            if (currentPage < 1 || pageSize < 1 || typeof(ProductRespond).GetProperty(sortBy) == null)
            {
                return BadRequest(ModelConstants.InvalidQuery);
            }

            IEnumerable<ProductDTO> products = await _productService
                .GetPaginatedResultAsyncAsNoTracking(currentPage, pageSize, sortBy, isAsc);
            return _mapper.Map<List<ProductRespond>>(products);
        }

        private Expression<Func<ProductDTO, bool>> Predicate(decimal minPrice, decimal maxPrice, string name)
        {
            ParameterExpression pe = Expression.Parameter(typeof(ProductDTO), "predicate");

            MemberExpression me = Expression.Property(pe, "Price");

            ConstantExpression constant = Expression.Constant(minPrice, typeof(decimal));
            
            BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

            var ExpressionTree = Expression.Lambda<Func<ProductDTO, bool>>(body, new[] { pe });

            return ExpressionTree;
        }

    }
}
