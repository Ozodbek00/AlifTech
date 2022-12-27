using AlifTech.Data.IRepositories;
using AlifTech.Domain.DBEntities;
using AlifTech.Service.Exceptions;
using AlifTech.Service.Extensions;
using AlifTech.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlifTech.Service.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly IRepository<User> userRepository;
        private readonly IConfiguration configuration;

        public AuthService(IRepository<User> userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        /// <summary>
        /// Generates Token for a valid User.
        /// </summary>
        public async Task<string> GenerateTokenAsync(string login, string password)
        {
            // Check for validation
            var user = await userRepository.GetAsync(x =>
                x.Login == login && x.Password == password.HashPassword());

            if (user is null)
                throw new EWalletException(400, "Login or password is incorrect!");


            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("X-UserId", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}
