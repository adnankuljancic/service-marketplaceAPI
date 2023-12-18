using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;

namespace ServiceMarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController (IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("review")]
        public async Task<ActionResult<bool>> addReview(CreateReviewDTO review)
        {
            return Ok(await _reviewService.addReview(review));
        }
    }
}
