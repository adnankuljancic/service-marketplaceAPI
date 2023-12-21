using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dataContext;

        public ReviewRepository (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <inheritdoc/>
        public async Task<Review> AddReview(Review review)
        {
            await _dataContext.Reviews.AddAsync(review);
            await _dataContext.SaveChangesAsync();
            return review;

        }
    }
}
