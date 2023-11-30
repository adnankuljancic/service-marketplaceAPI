using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService (IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<string> Login(UserDTO user) 
        {
            User ?dbUser = await _userRepository.GetUserByEmail(user.Email);

            if (dbUser != null && string.Equals(user.Email, dbUser.Email) && VerifyPasswordHash(user.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                var jwt = CreateToken(dbUser);
                return jwt;
            } else
            {
                return "error";
            }
        }

        /// <summary>
        /// Creates password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Verifies password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /// <summary>
        /// Creates JWT token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
