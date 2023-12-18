using ServiceMarketplaceBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceAPI.Tests.BLL
{
    public class ReviewServiceTests
    {
        [Fact]
        public void ReviewService_addNumbers_returnSum()
        {
            //Arrange
            ReviewService reviewService = new ReviewService();

            //Act
            int result = reviewService.addNumbers(5, 3);

            //Assert
            Assert.Equal(8, result);
        }
    }
}
