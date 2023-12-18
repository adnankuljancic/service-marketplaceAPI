using AutoMapper;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService (IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<ReviewDTO> addReview(CreateReviewDTO review)
        {
            Review result = await _reviewRepository.AddReview(_mapper.Map<Review>(review));
            return _mapper.Map<ReviewDTO>(result);
        }

        public int addNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
