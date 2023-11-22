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
        public Task<bool> register(User user);
    }
}
