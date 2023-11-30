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
        /// <summary>
        /// Registration method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> Register(NewUserDTO user);

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> Login(UserDTO user);
    }
}
