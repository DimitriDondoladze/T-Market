using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMarket.Persistence.DbModels;
using TMarket.WEB.Helpers.Constants;
using TMarket.WEB.RequestModels;
using TMarket.WEB.Services.Abstract;

namespace TMarket.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBaseService<UserDTO> _userService;
        private readonly IMapper _mapper;

        public UsersController(IBaseService<UserDTO> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllAsyncWithNoTracking();

            return _mapper.Map<List<User>>(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound(string.Format(ModelConstants.PropertyNotFoundFromController, "იუზერი"));
            }

            return _mapper.Map<User>(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, User user)
        {
            var users = await _userService.GetAllAsyncWithNoTracking();
            if (id != user.Id || !users.Any(x => x.Id == id))
            {
                return BadRequest(string.Format(ModelConstants.PropertyNotFoundFromController, "იუზერი"));
            }

            await _userService.UpdateAsync(_mapper.Map<UserDTO>(user));
            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userService.InsertAsync(_mapper.Map<UserDTO>(user));

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return BadRequest(string.Format(ModelConstants.PropertyNotFoundFromController, "იუზერი"));
            }

            await _userService.DeleteAsync(id);
            return _mapper.Map<User>(user);
        }

        // api/Users/GetPaginatedResult?{query}
        [HttpGet("GetPaginatedResult")]
        public async Task<ActionResult<IEnumerable<User>>> GetPaginatedResult
            (int currentPage = 1, int pageSize = 5, string sortBy = "Id", bool isAsc = true)
        {
            if (currentPage < 1 || pageSize < 1 || typeof(User).GetProperty(sortBy) == null)
            {
                return BadRequest(ModelConstants.InvalidQuery);
            }

            IEnumerable<UserDTO> users = await _userService
                .GetPaginatedResultAsyncAsNoTracking(currentPage, pageSize, sortBy, isAsc);
            return _mapper.Map<List<User>>(users);
        }
    }
}
