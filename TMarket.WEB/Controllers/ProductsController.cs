using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMarket.Persistence.DbModels;
using TMarket.WEB.Helpers.Constants;
using TMarket.WEB.Helpers.Extensions;
using TMarket.WEB.RequestModels;
using TMarket.Application.Services.Abstract;

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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string name, [FromQuery] decimal minPrice,
            [FromQuery] decimal maxPrice)
        {
            Func<ProductDTO, bool> predicate = p => p.Name.ToUpper().StartsWithOrNull(name.ToUpper()) &&
                p.Price >= minPrice && p.Price.LessOrEmptyInput(maxPrice);

            var products = await _productService.FindAllAsyncWithNoTracking(predicate);

            return _mapper.Map<List<Product>>(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound(string.Format(ModelConstants.PropertyNotFoundFromController, "პროდუქტი"));
            }

            return _mapper.Map<Product>(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var products = await _productService.GetAllAsyncWithNoTracking();
            if (id != product.Id || !products.Any(x => x.Id == id))
            {
                return BadRequest(string.Format(ModelConstants.PropertyNotFoundFromController, "პროდუქტი"));
            }

            await _productService.UpdateAsync(_mapper.Map<ProductDTO>(product));

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _productService.InsertAsync(_mapper.Map<ProductDTO>(product));

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return BadRequest(string.Format(ModelConstants.PropertyNotFoundFromController, "პროდუქტი"));
            }

            await _productService.DeleteAsync(id);
            return _mapper.Map<Product>(product);
        }

        [HttpGet("GetPaginatedResult")]
        public async Task<ActionResult<IEnumerable<Product>>> GetPaginatedResult
            (int currentPage = 1, int pageSize = 5, string sortBy = "Id", bool isAsc = true)
        {
            if (currentPage < 1 || pageSize < 1 || typeof(Product).GetProperty(sortBy) == null)
            {
                return BadRequest(ModelConstants.InvalidQuery);
            }

            IEnumerable<ProductDTO> products = await _productService
                .GetPaginatedResultAsyncAsNoTracking(currentPage, pageSize, sortBy, isAsc);
            return _mapper.Map<List<Product>>(products);
        }
    }
}
