using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public async Task<bool> Register(NewUserDTO user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            if (user.Username.Length<=3)
            {
                return false;
            }

            bool result = await _userRepository.Register(new User()
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt

            });
            return result;
        }

        public async Task<bool> Login(UserDTO user) 
        {
            User ?dbUser = await _userRepository.GetUserByEmail(user.Email);

            if (dbUser != null && string.Equals(user.Email, dbUser.Email) && VerifyPasswordHash(user.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
