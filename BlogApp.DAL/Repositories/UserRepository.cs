using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogApp.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user) => await _context.Users.AddAsync(user);
        public async Task<User?> GetUserByIdAsync(int id) => await _context.Users.FindAsync(id);
        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();
        public void UpdateUser(User user) => _context.Users.Update(user);
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public async Task RemoveUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new Exception("User not found");

            _context.Users.Remove(user);
        }

        public async Task<User> GetByUsernameAsync(RegisterDto dto)
        {
            return await _context.Set<User>().Where(u => u.Username == dto.Username).FirstOrDefaultAsync();
        }
    }
}
