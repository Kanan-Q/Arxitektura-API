using BlogApp.BL.DTO.User;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entites.User;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories;
using BlogBL.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddUserAsync(UserCreateDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = dto.Password,
                Email = dto.Email
            };

            await _repo.AddUserAsync(user);
            await _repo.SaveAsync();
            return user.Id;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _repo.GetAllUsersAsync();
            return users.Select(u => new User
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            });
        }

        public async Task UpdateUserAsync(UserUpdateDto dto)
        {
            var user = await _repo.GetUserByIdAsync(dto.Id);
            if (user == null) throw new Exception("User not found");

            user.Username = dto.Username;
            user.PasswordHash = dto.Password;
            user.Email = dto.Email;

            _repo.UpdateUser(user);
            await _repo.SaveAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            await _repo.RemoveUserAsync(id);
            await _repo.SaveAsync();
        }
    }
}

