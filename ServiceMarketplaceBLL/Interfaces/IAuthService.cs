using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Register(NewUserDTO user);
        public Task<bool> Login(UserDTO user);
    }
}
