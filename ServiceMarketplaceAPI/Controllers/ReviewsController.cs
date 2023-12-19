using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace ServiceMarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("review"), Authorize]
        public async Task<ActionResult<bool>> addReview(CreateReviewDTO review)
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            review.UserId = Int32.Parse(userId);
            return Ok(await _reviewService.addReview(review));
        }

    }
}
