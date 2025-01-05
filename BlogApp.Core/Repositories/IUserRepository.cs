using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        void UpdateUser(User user);
        Task RemoveUserAsync(int id);
        Task<int> SaveAsync();
        Task<User> GetByUsernameAsync(RegisterDto dto);
    }
}
