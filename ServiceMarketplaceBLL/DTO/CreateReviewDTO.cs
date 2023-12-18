using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.DTO
{
    public class CreateReviewDTO
    {
        public string ReviewContent { get; set; } = "";
        public int Rating { get; set; }
        public int ServiceId { get; set; }

    }
}
