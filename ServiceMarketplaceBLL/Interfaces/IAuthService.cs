using ServiceMarketplaceBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> register(NewUserDTO user);
    }
}
