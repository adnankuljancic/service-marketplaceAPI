using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;

namespace ServiceMarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(NewUserDTO request)
        {
            bool result = await _userService.Register(request);
            if(result)
            {
                return Ok("Registration successful!");
            }
            else
            {
                return BadRequest("Registration failed!");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO request)
        {
            bool result = await _userService.Login(request);
            if (result)
            {
                return Ok("Login successful!");
            }
            else
            {
                return BadRequest("Login failed!");
            }
        }
    }
}
