using AlifTech.Data.IRepositories;
using AlifTech.Data.Repositories;
using AlifTech.Domain.DBEntities;
using AlifTech.Service.Interfaces;
using AlifTech.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AlifTech.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // add repositories.
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Wallet>, Repository<Wallet>>();
            services.AddScoped<IRepository<Transaction>, Repository<Transaction>>();

            // add services.
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ITransactionService, TransactionService>();
        }

        public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(p =>
            {
                var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
                p.SaveToken = true;
                p.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
