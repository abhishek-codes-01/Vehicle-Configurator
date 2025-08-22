using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            // Await async user fetch
            var userResult = await _userRepository.GetByUsername(model.Username);

            var user = userResult.Value;

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Validate password (consider hashing in real app)
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return Unauthorized("Invalid username or password.");
            }


            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] User newUser)
        {
            // Check if username already exists
            var existingUser = await _userRepository.GetByUsername(newUser.Username);
            if (existingUser.Result is OkObjectResult)
            {
                return Conflict("Username already exists");
            }

            // Hash the password before saving
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await _userRepository.Add(newUser);

            return Ok(new { message = "User registered successfully" });
        }



    }
}
