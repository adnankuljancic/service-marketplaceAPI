using ServiceMarketplaceBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Interfaces
{
    public interface IReviewService
    {
        /// <summary>
        /// Method used for adding a review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public Task<bool> addReview(NewReviewDTO review);
    }
}
