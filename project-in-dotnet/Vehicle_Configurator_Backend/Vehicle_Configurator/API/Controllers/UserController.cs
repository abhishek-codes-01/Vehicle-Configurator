using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user/by-username/{username}
        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user with the specified username, or NotFound if not found.</returns>
        [HttpGet("by-username/{username}")]
        public async Task<ActionResult<User>> GetByUsername(string username)
        {
            var userResult = await _userRepository.GetByUsername(username);
            var user = userResult.Value;

            if (user == null)
            {
                return NotFound($"No user found with username: {username}");
            }

            return Ok(user);
        }
    }
}
