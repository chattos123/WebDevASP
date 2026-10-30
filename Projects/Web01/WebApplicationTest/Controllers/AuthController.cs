using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.Services;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserProfile login)
        {
            var user = _userService.GetUser(login.Username, login.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // For demo: return a fake JWT string
            var fakeJwt = $"FAKE-JWT-TOKEN-FOR-{user.Username}-{user.Role}";
            return Ok(new { token = fakeJwt });
        }
    }
}
