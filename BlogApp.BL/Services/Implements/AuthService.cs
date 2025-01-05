
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using BlogBL.Exceptions.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;

namespace BlogApp.BL.Services.Implements
{
    public class AuthService(IUserRepository _repo, IMapper _mapper) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var data = await _repo.GetAllUsersAsync();
            var user = data.Where(x => x.Username == dto.UsernameorEmail || x.Email == dto.UsernameorEmail).FirstOrDefault();


            if (user == null)
            {
                throw new NotFoundException<User>();
            }
            List<Claim> claims = [
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
                new Claim("Fullename",user.Name+""+user.Surname)

                ];


            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hello"));

            SigningCredentials cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSec = new JwtSecurityToken(
                issuer: "https://localhost:7192",
                audience: "https://localhost:7192",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials:cred
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.WriteToken(jwtSec);

            return HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password).ToString();
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var data = await _repo.GetAllUsersAsync();
            var user = data.Where(x => x.Username == dto.Username || x.Email == dto.Email).FirstOrDefault();
            if (user != null)
            {
                if (user.Email == dto.Email)
                {
                    throw new ExistException("mail already using by another user");
                }
            }
            else
            {
                throw new ExistException("Username already using by another user");

            }
            user = _mapper.Map<User>(dto);
            await _repo.AddUserAsync(user);
            await _repo.SaveAsync();

        }
    }
}
