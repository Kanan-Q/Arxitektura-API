using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(UserCreateDto dto);
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task UpdateUserAsync(UserUpdateDto dto);
        Task DeleteUserAsync(int id);
    }
}
