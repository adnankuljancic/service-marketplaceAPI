using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string ReviewContent { get; set; } = "";
        public int Rating { get; set; }
        public int ServiceId { get; set; }
        public int UserId {  get; set; }
    }
}
