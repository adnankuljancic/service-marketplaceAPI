using Microsoft.EntityFrameworkCore;
using ServiceMarketplaceDAL.Entities;
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
        DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                _dataContext.Users.Add(user);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
