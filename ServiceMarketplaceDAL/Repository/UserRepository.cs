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

        public async Task<bool> register(User user)
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
    }
}
