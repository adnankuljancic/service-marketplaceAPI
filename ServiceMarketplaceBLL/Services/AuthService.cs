using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Exceptions;
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
        private readonly IMapper _mapper;

        public AuthService (IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> Register(CreateUserDTO user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            if(string.IsNullOrEmpty(user.Username))
            {
                throw new BadRequestException("Username is required.");
            }
            if (user.Username.Length<=3)
            {
                throw new BadRequestException("Username must have at least 3 characters.");
            }
            if(user.Username.Length>50)
            {
                throw new BadRequestException("Username can not be longer than 50 characters.");
            }

            bool result = await _userRepository.Register(_mapper.Map<User>(user));
            return result;
        }

        /// <inheritdoc/>
        public async Task<string> Login(UserDTO user) 
        {
            if(user.Password.Length<=3)
            {
                throw new BadRequestException("Password must be longer than 3 char");
            }
            User ?dbUser = await _userRepository.GetUserByEmail(user.Email);

            if (dbUser != null && string.Equals(user.Email, dbUser.Email) && VerifyPasswordHash(user.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                var jwt = CreateToken(dbUser);
                return jwt;
            } else
            {
                throw new System.UnauthorizedAccessException("Invalid email or password.");
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
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
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
