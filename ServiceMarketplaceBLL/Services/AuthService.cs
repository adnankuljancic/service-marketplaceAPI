using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Services
{
    public class AuthService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public AuthService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string getUser()
        {
            return _userRepository.getUser();
        }
    }
}
