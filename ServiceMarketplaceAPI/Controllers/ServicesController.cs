using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceMarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServicesController (IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("services")]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetServices()
        {
            return Ok(await _serviceService.getServices());

        }
    }
}
