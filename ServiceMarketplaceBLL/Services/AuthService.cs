using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> register(NewUserDTO user)
        {
            if (user.Username.Length<=3)
            {
                return false;
            }
            return await _userRepository.register(new User()
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email, 
                Password = user.Password
            });
        }
    }
}
