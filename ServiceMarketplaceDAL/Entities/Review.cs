using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string ReviewContent { get; set; } = "";
        public int Rating { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set;}
        public User? User {  get; set; } 

        [ForeignKey("Service")]
        public int ServiceId {  get; set; }
        public Service Service { get; set; }


    }
}
