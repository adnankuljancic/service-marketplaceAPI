using ServiceMarketplaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> Register(User user);

        public Task<User?> GetUserByEmail(string email);
    }
}
