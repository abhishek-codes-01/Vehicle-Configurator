using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Configurator.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // This action requires a valid JWT token.
        [HttpGet]
        public IActionResult GetProtectedData()
        {
            var userName = User.Identity?.Name ?? "Unknown user";
            return Ok($"Hello {userName}, you have access to protected data!");
        }
    }
}
