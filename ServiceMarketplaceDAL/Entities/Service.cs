using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Entities
{
    public class Service
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
