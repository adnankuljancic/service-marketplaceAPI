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
        /// <summary>
        /// Adds user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> Register(User user);

        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<User?> GetUserByEmail(string email);
    }
}
