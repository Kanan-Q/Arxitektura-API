using BlogApp.Core.Repositories.CategoryRepository;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Repositories;
using Jose;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;




namespace BlogApp.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
          
            return services;
        }
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Core.Entites.JWT.JwtOptions>(configuration.GetSection(Core.Entites.JWT.JwtOptions.Jwt));
            return services;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            Core.Entites.JWT.JwtOptions Jwtopt = new Core.Entites.JWT.JwtOptions();

            Jwtopt.Issuer = configuration.GetSection("JwtOptions")["Issuer"];
            Jwtopt.Audience = configuration.GetSection("JwtOptions")["Audience"];
            Jwtopt.SecretKey = configuration.GetSection("JwtOptions")["SecretKey"];
            var signInkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwtopt.SecretKey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signInkey,
                    ValidAudience = Jwtopt.Audience,
                    ValidIssuer = Jwtopt.Issuer,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }



    }
}
