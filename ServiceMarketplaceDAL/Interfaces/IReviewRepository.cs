using ServiceMarketplaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Interfaces
{
    public interface IReviewRepository
    {
        /// <summary>
        /// Adds review to db
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public Task<Review> AddReview(Review review);
    }
}
