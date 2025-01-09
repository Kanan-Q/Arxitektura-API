using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }
        public Task AddUserAsync(UserCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }


        Task IUserRepository.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
