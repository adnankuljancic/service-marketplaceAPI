using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketplaceBLL.Interfaces;

namespace ServiceMarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.getUser());
        }
    }
}
