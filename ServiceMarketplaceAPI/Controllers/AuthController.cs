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
        public async Task<ActionResult<bool>> Register(CreateUserDTO request)
        {
            return Ok(await _userService.Register(request));

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            return Ok(await _userService.Login(request));
        }
    }
}
