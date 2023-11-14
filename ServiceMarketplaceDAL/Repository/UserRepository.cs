using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public string getUser()
        {
            return "User DAL";
        }
    }
}
